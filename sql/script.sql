USE sys;
DROP DATABASE IF EXISTS TreasureHuntAdventure;
CREATE DATABASE TreasureHuntAdventure;
USE TreasureHuntAdventure;

SET SQL_SAFE_UPDATES = 0;
SET GLOBAL log_bin_trust_function_creators = 1;

DROP TABLE IF EXISTS tb_Game; 
DROP TABLE IF EXISTS tb_Player;
DROP TABLE IF EXISTS tb_Map;
DROP TABLE IF EXISTS tb_Tile;
DROP TABLE IF EXISTS tb_Item;
DROP TABLE IF EXISTS tb_ItemType;
DROP TABLE IF EXISTS tb_ChatSession;
DROP TABLE IF EXISTS tb_Tile_Item;
DROP TABLE IF EXISTS tb_Game_Player;
DROP TABLE IF EXISTS tb_Chat_Player;
DROP TABLE IF EXISTS tb_Inventory_Item;

-- Create all required table
CREATE TABLE tb_Game (
    GameID INT(10) PRIMARY KEY AUTO_INCREMENT,
    StartTime DATETIME,
    EndTime DATETIME,
    State VARCHAR(32) DEFAULT 'Running' 
);

CREATE TABLE tb_Map (
	MapID INT(10) PRIMARY KEY AUTO_INCREMENT,
	GameID INT(10),
	MaxRow INT(10),
	MaxColumn INT(10),
	FOREIGN KEY (GameID) REFERENCES tb_Game(GameID)
);

CREATE TABLE tb_Player (
	PlayerID INT(10) PRIMARY KEY AUTO_INCREMENT,
	Username VARCHAR(255),
	Email VARCHAR(255),
	Password VARCHAR(255),
	LockState BIT DEFAULT 0,
	LoginState BIT DEFAULT 0,
	GameState BIT DEFAULT 0,
	IsAdministrator BIT DEFAULT 0,
	Attempt INT DEFAULT 0
);

CREATE TABLE tb_Tile (
	TileID INT(10) PRIMARY KEY AUTO_INCREMENT,
	MapID INT(10),
	TileRow INT(10),
	TileCol INT(10),
    IsEmptied BIT DEFAULT 1,
    IsOccupied BIT DEFAULT 0,
	FOREIGN KEY (MapID) REFERENCES tb_Map(MapID)
);

CREATE TABLE tb_ItemType (
    ItemTypeID INT(10) PRIMARY KEY AUTO_INCREMENT,
    Type VARCHAR(255),
    Deduction INT(10),
    `Point` INT(10)
);

CREATE TABLE tb_Item (
	ItemID INT(10) PRIMARY KEY AUTO_INCREMENT,
    ItemTypeID INT(10),
    FOREIGN KEY (ItemTypeID) REFERENCES tb_ItemType(ItemTypeID)    
);

CREATE TABLE tb_Inventory_Item (
    PlayerID INT(10),
    ItemTypeID INT(10),
    Quantity INT(10) DEFAULT 0,
    PRIMARY KEY (PlayerID, ItemTypeID),
    FOREIGN KEY (PlayerID) REFERENCES tb_Player(PlayerID),
    FOREIGN KEY (ItemTypeID) REFERENCES tb_ItemType(ItemTypeID)
);

CREATE TABLE tb_Tile_Item (
	TileID INT(10),
    ItemID INT(10),
    PRIMARY KEY (TileID, ItemID),
    FOREIGN KEY (TileID) REFERENCES tb_Tile(TileID),
    FOREIGN KEY (ItemID) REFERENCES tb_Item(ItemID)
);

CREATE TABLE tb_Game_Player (
    GameID INT(10),
    PlayerID INT(10),
    TileID INT(10),
    Score INT(10) DEFAULT 0,
    PRIMARY KEY (GameID, PlayerID),
    FOREIGN KEY (GameID) REFERENCES tb_Game(GameID),
    FOREIGN KEY (PlayerID) REFERENCES tb_Player(PlayerID),
    FOREIGN KEY (TileID) REFERENCES tb_Tile(TileID)
);

CREATE TABLE tb_ChatSession (
    ChatID INT(10) PRIMARY KEY AUTO_INCREMENT
);

CREATE TABLE tb_Chat_Player (
    ChatID INT(10),
    PlayerID INT(10),
    MessageContent VARCHAR(255),
    ChatTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ChatID, PlayerID),
    FOREIGN KEY (ChatID) REFERENCES tb_ChatSession(ChatID),
    FOREIGN KEY (PlayerID) REFERENCES tb_player(PlayerID)
);

-- 1. Player login, including lock out. [4]
DROP PROCEDURE IF EXISTS login;
DELIMITER //
CREATE PROCEDURE login(IN pEmail VARCHAR(255), IN pPassword VARCHAR(255))
main_code: BEGIN
	-- Check if player exists
    IF NOT EXISTS (SELECT 1 FROM tb_Player p WHERE Email = pEmail)
    THEN
		SELECT 'This account does not exist' AS Message;
        LEAVE main_code;
	END IF;
    
    -- Check if player is locked
    IF EXISTS (SELECT 1 FROM tb_Player p WHERE p.Attempt >= 5 AND Email = pEmail)
    THEN
		UPDATE tb_Player
		SET LockState = 1
		WHERE Email = pEmail;
		SELECT 'Your account has been locked out' AS Message;
        LEAVE main_code;
	END IF;
    
	-- Check if login credentials is valid
    IF EXISTS (SELECT 1 FROM tb_Player p WHERE Email = pEmail AND Password = pPassword)
    THEN
		-- Valid credentials
		UPDATE tb_Player
		SET Attempt = 0, LoginState = 1
		WHERE Email = pEmail;                
		SELECT 'You have Logged in successfully' AS Message;		
	ELSE
		-- Invalid credentials
        UPDATE tb_Player
		SET Attempt = Attempt + 1
		WHERE Email = pEmail;
		SELECT 'Invalid credentials! Attempt + 1' AS Message;
	END IF;
END//
DELIMITER ;

-- 2. Player registration,[4]
DROP PROCEDURE IF EXISTS register;
DELIMITER //
CREATE PROCEDURE register(IN pUsername VARCHAR(255), IN pEmail VARCHAR(255), IN pPassword VARCHAR(255))
BEGIN
	-- If account already exist in database
	IF EXISTS (SELECT `Email` FROM tb_Player p WHERE p.Email = pEmail)
	THEN 
		SELECT 'Register failed! This account alreadt exists' AS Message;    
	-- Register successfully
	ELSE
		INSERT INTO tb_Player (`Username`, `Email`, `Password`) VALUES (pUsername, pEmail, pPassword);
	END IF;
END//
DELIMITER ;

-- 3. Laying out tiles on a game board. [4]
DROP PROCEDURE IF EXISTS make_a_board;
DELIMITER //
CREATE PROCEDURE make_a_board(IN pMaxRow INT, IN pMaxCol INT)
BEGIN	
    DECLARE new_game_id INT;
	DECLARE new_map_id INT;
    DECLARE current_row INT DEFAULT 0;
    DECLARE current_col INT DEFAULT 0;
    
    INSERT INTO tb_game (StartTime, EndTIme) VALUES (current_timestamp, DATE_ADD(current_timestamp, INTERVAL 1 DAY));
    -- Get the GameID from the last insert
    SET new_game_id = LAST_INSERT_ID();

	INSERT INTO tb_Map (GameID, MaxRow, MaxColumn) VALUES (new_game_id, pMaxRow, pMaxCol);
    -- Get the MapID from the last insert
	SET new_map_id = LAST_INSERT_ID();
	SET new_map_id = LAST_INSERT_ID();
    
    -- Use WHILE loop to traverse each row and col
    WHILE current_row < pMaxRow DO
		WHILE current_col < pMaxCol DO
            -- Insert data into tb_Tile
            INSERT INTO tb_Tile (MapID, TileROW, TileCol, IsEmptied) VALUES (new_map_id, current_row, current_col, 1);
            SET current_col = current_col + 1;            
		END WHILE;
        -- Initial current_col and plus current_row
        SET current_col = 0;
		SET current_row = current_row + 1;
	END WHILE;
	-- SELECT 'Add tile successfully!' AS Message;
END//
DELIMITER ;

-- 4. Placing an item on a tile. [4]
-- This stored function for assigning type for each Tile
DROP FUNCTION IF EXISTS assign_item_type;
DELIMITER //
CREATE FUNCTION assign_item_type() RETURNS INT
NOT DETERMINISTIC
BEGIN
    -- item_type = 2 is bomb
    IF FLOOR(RAND() * 3) % 3 = 2 THEN
        RETURN 2;
    -- item_type = 1 is diamond
    ELSEIF FLOOR(RAND() * 3) % 3 = 1 THEN
        RETURN 1;
    ELSE
    -- item_type = 0 is empty
        RETURN 0;
    END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS placing_item_on_tile;
DELIMITER //
CREATE PROCEDURE placing_item_on_tile(IN pMapID INT)
BEGIN
    DECLARE total_row INT;
    DECLARE total_col INT;
    DECLARE current_row INT DEFAULT 0;
    DECLARE current_col INT DEFAULT 0;
	DECLARE item_type INT DEFAULT 0;
    DECLARE temp_tile_id INT;
    DECLARE temp_item_id INT;
	
    -- Insert data into tb_ItemType
    IF NOT EXISTS (SELECT * FROM tb_ItemType)
    THEN		
		INSERT INTO tb_ItemType (Type, Deduction, `Point`) VALUES ('diamond', 0, 10);
		INSERT INTO tb_ItemType (Type, Deduction, `Point`) VALUES ('bomb', 5, 0);
	END IF;
    
	-- Get max row and col size of board
	SELECT MAX(TileRow), MAX(TileCol) INTO total_row, total_col
    FROM tb_Tile 
    WHERE MapID = pMapID;

	-- Check if the MapID is valid
    IF EXISTS (SELECT 1 FROM tb_map WHERE MapID = pMapID) 
    THEN    
		-- Traverse the whole board
		WHILE current_row <= total_row DO
			WHILE current_col <= total_col DO
				-- Get current TileID (Temporary)
				SELECT TileID INTO temp_tile_id
				FROM tb_tile
				WHERE MapID = pMapID AND
					TileRow = current_row AND 
					TileCol = current_col;
            
				-- Assign item type
                SET item_type = assign_item_type();
                -- When ItemType is 1
                IF item_type = 1
                THEN					
					INSERT INTO tb_Item (ItemTypeID) VALUES (1);
                    -- Get last insert ItemID
					SET temp_item_id = LAST_INSERT_ID();
                    
                    INSERT INTO tb_Tile_Item (TileID, ItemID) VALUES (temp_tile_id, temp_item_id);
                    
					-- Update tile IsEmptied state in tb_tile
                    UPDATE tb_Tile
                    SET IsEmptied = 0
                    WHERE MapID = pMapID AND
						TileRow = current_row AND 
                        TileCol = current_col;
				-- When ItemType is 2
				ELSEIF item_type = 2
                THEN
					INSERT INTO tb_Item (ItemTypeID) VALUES (2);
                    -- Get last insert ItemID
					SET temp_item_id = LAST_INSERT_ID();
                    
                    INSERT INTO tb_Tile_Item (TileID, ItemID) VALUES (temp_tile_id, temp_item_id);
                    
					-- Update tile IsEmptied state in tb_tile
                    UPDATE tb_Tile
                    SET IsEmptied = 0
                    WHERE MapID = pMapID AND
						TileRow = current_row AND 
                        TileCol = current_col;
				END IF;
				SET current_col = current_col + 1;     
			END WHILE;
            -- Initial current_col and plus current_row
			SET current_col = 0;
			SET current_row = current_row + 1;
		END WHILE;
	ELSE
		SELECT 'Invalid MapID, please check again!' AS Message;
    END IF;
END//
DELIMITER ;

-- 5. Player game play movement [4]
DROP PROCEDURE IF EXISTS player_movement;
DELIMITER //
CREATE PROCEDURE player_movement(IN pGameID INT, IN pPlayerID INT, IN pTargetID INT)
BEGIN
	DECLARE current_tile_id INT;
    DECLARE current_tile_row INT;
    DECLARE current_tile_col INT;
    DECLARE current_tile_state INT;
    
    DECLARE target_tile_row INT;
    DECLARE target_tile_col INT;
    DECLARE target_tile_state BIT;

	START TRANSACTION;
    -- Get current tile info (from tb_Game_Tile)
    SELECT gp.TileID, t.TileRow, t.TileCol, t.IsOccupied into current_tile_id, current_tile_row, current_tile_col, current_tile_state
    FROM tb_game_player gp
    LEFT JOIN tb_Tile t ON gp.TileID = t.TileID
    WHERE gp.GameID = pGameID AND gp.PlayerID = pPlayerID;
    
    -- Get target tile info
    SELECT TileRow, TileCol, IsOccupied INTO target_tile_row, target_tile_col, target_tile_state
    FROM tb_Tile
    WHERE TileID = pTargetID;
    
	-- WHen target tile is legal and absolute valud equal to 1
	IF target_tile_state = 0 AND 
		( (ABS(target_tile_row - current_tile_row) = 1 AND target_tile_col = current_tile_col ) OR
		( target_tile_row = current_tile_row AND ABS(target_tile_col - current_tile_col) = 1) )
    THEN
		-- Update original tile state
        UPDATE tb_tile
        SET IsOccupied = 0
        WHERE TileID = current_tile_id;
                
		-- Update player position data
		UPDATE tb_game_player
        SET TileID = pTargetID
        WHERE GameID = pGameID AND
			PlayerID = pPlayerID;
        
        -- Update target tile state after movement
        UPDATE tb_tile
        SET IsOccupied = 1
        WHERE TileID = pTargetID;
        
		COMMIT;
        SELECT "Player movement successfully" AS Message;
	ELSE
		SELECT "Player movement fail" AS Message;
        ROLLBACK;    
    END IF;
END//
DELIMITER ;

-- 6. Game play scoring. How do players gain and lose points? [4]
DROP PROCEDURE IF EXISTS game_play_scoring;
DELIMITER //
CREATE PROCEDURE game_play_scoring(IN pGameID INT, IN pPlayerID INT, IN pTargetID INT)
BEGIN
    DECLARE current_item_id INT;
    DECLARE current_item_type INT;

	START TRANSACTION;
	-- Check if tile is emptied
	IF (SELECT IsEmptied FROM tb_Tile WHERE TileID = pTargetID) = 0
	THEN
		-- Check the ItemType on the target tile
		SELECT ItemID INTO current_item_id
		FROM tb_Tile_Item 
		WHERE TileID = pTargetID;
            
		IF current_item_id IS NOT NULL
		THEN
			-- Get current ItemTypeID from tb_Item
			SELECT ItemTypeID INTO current_item_type
			FROM tb_Item
			WHERE ItemID = current_item_id;
                
			IF current_item_type = 1
			THEN
				-- Player gains 10 points for picking up a Diamond
				UPDATE tb_game_player
				SET Score = Score + 10
				WHERE PlayerID = pPlayerID;
                
				-- Update IsEmptied state
				UPDATE tb_Tile
				SET IsEmptied = 1
				WHERE TileID = pTargetID;
				SELECT 'You get the Diamond! Score + 10' AS Message;
			ELSEIF current_item_type = 2
			THEN				
				-- Player loses 5 points for picking up a Bomb
				UPDATE tb_game_player
				SET Score = Score - 5
				WHERE PlayerID = pPlayerID;
			
				-- Update IsEmptied state
				UPDATE tb_Tile
				SET IsEmptied = 1
				WHERE TileID = pTargetID;
				SELECT 'You get the Bomb! Score - 5' AS Message;
			END IF;
		END IF;
		COMMIT;
	ELSE
        ROLLBACK;    
    END IF;
END//
DELIMITER ;

-- 7. Player game play acquiring inventory
DROP PROCEDURE IF EXISTS acquire_item_to_inventory;
DELIMITER //
CREATE PROCEDURE acquire_item_to_inventory(IN pGameID INT, IN pPlayerID INT, IN pTargetID INT)
BEGIN
    DECLARE current_item_id INT;    
    DECLARE current_item_type INT;

	START TRANSACTION;
	-- Check if tile is emptied
	IF (SELECT IsEmptied FROM tb_Tile WHERE TileID = pTargetID) = 0
	THEN
		-- Check the ItemType on the target tile
		SELECT ItemID INTO current_item_id
		FROM tb_Tile_Item 
		WHERE TileID = pTargetID;
            
		IF current_item_id IS NOT NULL
		THEN
			-- Get current ItemTypeID from tb_Item
			SELECT ItemTypeID INTO current_item_type
			FROM tb_Item
			WHERE ItemID = current_item_id;
                
			IF current_item_type = 1
			THEN
				-- Player gains 10 points for picking up a Diamond
				UPDATE tb_game_player
				SET Score = Score + 10
				WHERE PlayerID = pPlayerID;
                
				-- Update IsEmptied state
				UPDATE tb_Tile
				SET IsEmptied = 1
				WHERE TileID = pTargetID;
				-- SELECT 'You get the Diamond! Score + 10' AS Message;
                
				IF EXISTS (SELECT 1 FROM tb_Inventory_Item WHERE PlayerID = pPlayerID AND ItemTypeID = current_item_type)
				THEN
					-- If item already exists, the number of quantity + 1
					UPDATE tb_Inventory_Item
					SET Quantity = Quantity + 1
					WHERE PlayerID = pPlayerID AND 
						ItemTypeID = current_item_type;
					SELECT "Diamond stock + 1" AS Message;
				ELSE
					-- If item not exists, insert new data into the inventory
					INSERT INTO tb_Inventory_Item (PlayerID, ItemTypeID, Quantity) VALUES (pPlayerID, current_item_type, 1);
                    SELECT "Diamond has been stored in inventory" AS Message;
				END IF;
                
			ELSEIF current_item_type = 2
			THEN				
				-- Player loses 5 points for picking up a Bomb
				UPDATE tb_game_player
				SET Score = Score - 5
				WHERE PlayerID = pPlayerID;
			
				-- Update IsEmptied state
				UPDATE tb_Tile
				SET IsEmptied = 1
				WHERE TileID = pTargetID;
				-- SELECT 'You get the Bomb! Score - 5' AS Message;

				IF EXISTS (SELECT 1 FROM tb_Inventory_Item WHERE PlayerID = pPlayerID AND ItemTypeID = current_item_type)
				THEN
					-- If item already exists, the number of quantity + 1
					UPDATE tb_Inventory_Item
					SET Quantity = Quantity + 1
					WHERE PlayerID = pPlayerID AND 
						ItemTypeID = current_item_type;
					SELECT "Bomb stock + 1" AS Message;
				ELSE
					-- If item not exists, insert new data into the inventory
					INSERT INTO tb_Inventory_Item (PlayerID, ItemTypeID, Quantity) VALUES (pPlayerID, current_item_type, 1);
                    SELECT "Bomb has been stored in inventory" AS Message;
				END IF;                
			END IF;
		END IF;
		COMMIT;
	ELSE
        ROLLBACK;    
    END IF;
END//
DELIMITER ;

-- 8. Move an Item (NPC effect). [4]
DROP PROCEDURE IF EXISTS move_an_item;
DELIMITER //
CREATE PROCEDURE move_an_item(IN pMapID INT, IN pTileID INT, IN pTargetTileID INT)
BEGIN
	DECLARE current_tile_emptied_state INT;
    DECLARE current_tile_item INT;
	DECLARE target_tile_emptied_state INT;

	START TRANSACTION;
	-- Get current tile IsEmptied state
	SELECT IsEmptied INTO current_tile_emptied_state
    FROM tb_Tile
    WHERE TileID = pTileID;
    
	SELECT ItemID INTO current_tile_item
    FROM tb_Tile_Item
    WHERE TileID = pTileID;
    
    -- Get current tile IsEmptied state
	SELECT IsEmptied INTO target_tile_emptied_state
    FROM tb_Tile 
    WHERE TileID = pTargetTileID;
    
    IF (current_tile_emptied_state = 0 AND target_tile_emptied_state = 1)
    THEN
		-- Update target tile state
		UPDATE tb_Tile
        SET IsEmptied = 1
		WHERE TileID = pTileID;
    
		-- Update target tile state
		UPDATE tb_Tile
        SET IsEmptied = 0
		WHERE TileID = pTargetTileID;
            
		UPDATE tb_Tile_Item
        SET TileID = pTargetTileID
        WHERE TileID = pTileID;
        COMMIT;
        SELECT "Move item successfully" AS Message;
	ELSE
		SELECT "The target tile is illegal" AS Message;
        ROLLBACK;
    END IF;
END//
DELIMITER ;

-- 9. Kill running games. [4]
DROP PROCEDURE IF EXISTS kill_running_game;
DELIMITER //
CREATE PROCEDURE kill_running_game(IN pGameID INT)
BEGIN 
	IF EXISTS (SELECT 1 FROM tb_Game WHERE GameID = pGameID AND State = 'Running')
    THEN
		UPDATE tb_Game
		SET State = 'Terminated'
		WHERE GameID = pGameID;
	ELSE
		SELECT 'Kill running game fail' AS Message;
    END IF;
END//
DELIMITER ;

-- 10. Add new players. [4]
DROP PROCEDURE IF EXISTS add_player;
DELIMITER //
CREATE PROCEDURE add_player(
	IN pUsername VARCHAR(255), 
    IN pEmail VARCHAR(255), 
    IN pPassword VARCHAR(255), 
    IN pLockState BIT,
    IN pIsAdministrator BIT)
BEGIN 
	IF NOT EXISTS (SELECT 1 FROM tb_Player WHERE Email = pEmail)
	THEN
		-- Add new player
		INSERT INTO tb_Player (Username, Email, Password, LockState, IsAdministrator) VALUES (pUsername, pEmail, pPassword, pLockState, pIsAdministrator);
        -- SELECT 'Add player successfully' AS Message;
	ELSE
		SELECT 'This player already exisits' AS Message;
	END IF;
END//
DELIMITER ;

-- 11. Update data of a player. [4]
DROP PROCEDURE IF EXISTS update_player;
DELIMITER //
CREATE PROCEDURE update_player(
	IN pEmail VARCHAR(255),
	IN pUsername VARCHAR(255),
    IN pPassword VARCHAR(255),
    IN pLockState BIT,
    IN pIsAdministrator BIT
)
BEGIN 
	IF EXISTS (SELECT 1 FROM tb_Player WHERE Email = pEmail)
	THEN
		UPDATE tb_Player
        SET
			Username = pUsername,
			Password = pPassword,
			LockState = pLockState,
			IsAdministrator = pIsAdministrator
		WHERE
			Email = pEmail;
	ELSE
        SELECT 'This player does not exist' AS Message;
	END IF;
END//
DELIMITER ;

-- 12. Delete a player. [4]
DROP PROCEDURE IF EXISTS delete_player;
DELIMITER //
CREATE PROCEDURE delete_player(IN pEmail VARCHAR(255))
BEGIN 
	IF EXISTS (SELECT 1 FROM tb_Player WHERE Email = pEmail)
	THEN
		DELETE FROM tb_Player WHERE Email = pEmail;
	ELSE
        SELECT 'This player does not exists' AS Message;
	END IF;
END//
DELIMITER ;

-- Add player to exist game map
DROP PROCEDURE IF EXISTS add_player_to_game;
DELIMITER //
CREATE PROCEDURE add_player_to_game(IN pGameID INT, IN pPlayerID INT, IN pTileID INT)
code_block: BEGIN
	START TRANSACTION;
    
	-- Check if game is exists    
	IF NOT EXISTS (SELECT 1 FROM tb_game WHERE GameID = pGameID)
	THEN 
		SELECT "The game doesn't exists";
        ROLLBACK;
        -- I got LEAVE() from here: https://dev.mysql.com/doc/refman/8.4/en/leave.html and 
        -- https://tutorialspoint.com/mysql/mysql_leave_statement.htm
        LEAVE code_block;
    END IF;
    
    -- Check if the tile is exists
    IF NOT EXISTS (SELECT 1 FROM tb_tIle WHERE TileID = pTileID)
	THEN
		SELECT "The tile doesn't exists";
        ROLLBACK;
		LEAVE code_block;
    END IF;
            
    -- Check if the player is exists
	IF NOT EXISTS (SELECT 1 FROM tb_game_player WHERE GameID = pGameID AND PlayerID = pPlayerID)
	THEN
		-- Insert data into tb_Game_Player
		INSERT INTO tb_game_player (GameID, PlayerID, TileID) VALUES (pGameID, pPlayerID, pTileID);
        
        UPDATE tb_Tile
        SET IsOccupied = 1
        WHERE TileID = pTileID;
        COMMIT;
    END IF;
END//

-- 2. Player registration,[4]
-- 1) Register account successfully
CALL register('Bozhi Chen', 'bozhi.chen@example.com', '112233');
CALL register('TESTER', 'TESTER@example.com', '666666');
CALL register('LOCK', 'LOCK@LOCK.com', 'aabbcc');
-- 2) Register account fail
CALL register('Bozhi Chen', 'bozhi.chen@example.com', '112233');

-- 1. Player login, including lock out. [4]
-- 1) Login successfully
CALL login('bozhi.chen@example.com', '112233');
-- 2) Login fail (attempt + 1)
CALL login('TESTER@example.com', 'djhedjcvy');
CALL login('TESTER@example.com', 'djhedjcvy');
-- 3) Account locked out
CALL login('LOCK@LOCK.com', 'xxxxx');
CALL login('LOCK@LOCK.com', 'xxxxx');
CALL login('LOCK@LOCK.com', 'xxxxx');
CALL login('LOCK@LOCK.com', 'xxxxx');
CALL login('LOCK@LOCK.com', 'xxxxx');
CALL login('LOCK@LOCK.com', 'xxxxx');

-- 3. Laying out tiles on a game board. [4]
CALL make_a_board(5, 5);

-- 4. Placing an item on a tile. [4]
CALL placing_item_on_tile(1);

-- Add player to game
CALL add_player_to_game(1, 1, 1);

-- 5. Player game play movement, i.e., moving a player to a “legal” tile. [4]
-- 1) Play movement successful
CALL player_movement(1, 1, 2);
-- 2) Play movement fail
CALL player_movement(1, 1, 99);
CALL player_movement(1, 99, 3);
CALL player_movement(99, 1, 3);

-- 6. Game play scoring. How do players gain and lose points? [4]
-- 1) Game play scoring successful
CALL game_play_scoring(1, 1, 3);
CALL game_play_scoring(1, 1, 4);
CALL game_play_scoring(1, 1, 5);
-- 2) Game play scoring fail
CALL game_play_scoring(99, 1, 888);
CALL game_play_scoring(1, 1, 99);

-- 7. Player game play acquiring inventory, e.g., picking up items off a tile and putting them in an inventory (bag?) [4]
-- 1) Item added to inventory successfully
CALL acquire_item_to_inventory(1, 1, 6);
CALL acquire_item_to_inventory(1, 1, 7);
CALL acquire_item_to_inventory(1, 1, 8);
-- 2) Item added to inventory failure
CALL acquire_item_to_inventory(99, 1, 999);
CALL acquire_item_to_inventory(1, 1, 999);

-- 8. Move an Item (NPC effect). [4]
/*
NOTE: 
For this procedure, you may need to according tb_tile and execute it.
(pTileID is the tile you want to move the item to, pTargetTileID is the destination tile)
Thank you.	
*/
-- Foramt: move_an_item(IN pMapID INT, IN pTileID INT, IN pTargetTileID INT)
-- 1) Mve an item successfully
CALL move_an_item(1, 1, 2);
-- 2) Mve an item failure
CALL move_an_item(1, 1, 99);
CALL move_an_item(1, 99, 1);

-- 9. Kill running games. [4]
CALL kill_running_game(1);

-- 10. Add new players. [4]
-- 	1) Add new player successfully
CALL add_player('BATMAN', 'BATMAN@qq.com', '111@qq.com', 0, 0);
-- 	2) Add new player failure
CALL add_player('Bozhi Chen', 'bozhi.chen@example.com', '112233', 0, 0);

-- 11. Update data of a player. [4]
-- 1) Update data of a player successfully
CALL update_player('bozhi.chen@example.com', 'UPDATEDEMAIL', 'UPDATEDPWD', 1, 1);
-- 2) Update data of a player failure
CALL update_player('THISINVALID@qq.com', 'UPDATEDEMAIL', 'UPDATEDPWD', 1, 1);

-- 12. Delete a player. [4]
-- 1) Delete a player successfully
CALL delete_player("TESTER@example.com");
-- 2) Delete a player failure
CALL delete_player("AABBCC@example.com");