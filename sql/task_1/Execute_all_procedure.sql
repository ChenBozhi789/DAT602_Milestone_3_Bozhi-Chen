USE DAT602m2t1db;

-- 2. Player registration,[4]
CALL register('Alice Smith', 'alice.smith@example.com', '234567890');
CALL register('Bob Johnson', 'bob.johnson@example.com', '345678901');
CALL register('Emily Davis', 'emily.davis@example.com', '456789012');
CALL register('Michael Brown', 'michael.brown@example.com', '567890123');
-- SELECT * FROM tb_Player;

-- 1. Player login, including lock out. [4]
-- 	1) Player credential invalid't -> Attempt + 1
CALL login('alice.smith@example.com', '666666');
CALL login('alice.smith@example.com', '666666');
CALL login('alice.smith@example.com', '666666');
-- 	2) Player credential valid't -> Login successfully
CALL login('bob.johnson@example.com', '345678901');

-- 3. Laying out tiles on a game board. [4]
CALL make_a_board(5, 5);
-- SELECT * FROM tb_map;

-- 4. Placing an item on a tile. [4]
CALL placing_item_on_tile(1);
-- SELECT * FROM tb_tile_item;

-- Add player to game
CALL add_player_to_game(1, 1, 1);
-- SELECT * FROM dat602m2t1db.tb_game_player;

/*
Just reminder:
1. Requirement 5 implements the player's ability to move between "legal" tiles (and is also the basis for requirements 6 and 7)

2. Requirement 6 builds on requirement 5 to implement the game's scoring logic, 
allowing players to gain or lose points when moving to specific grids.

3. Requirement 7 builds on requirement 6 to implement the player's ability to pick up items 
at a target grid and put them in their backpack (inventory).

Therefore, requirements 6 and 7 both rely on the movement logic in requirement 5, so you can implement 
requirements 5, 6, and 7 at the same time by calling the acquire_item_to_inventory stored procedure.
 */
 
-- 5. Player game play movement, i.e., moving a player to a “legal” tile. [4]
-- 1) The target tile is legal
-- CALL player_movement(1, 0, 1);
-- 2) The target tile is illegal
CALL player_movement(1, 99, 99);

-- 6. Game play scoring. How do players gain and lose points? [4]
-- game_play_scoring(IN pPlayerID INT, IN pTileRow INT, IN pTileCol INT)
-- CALL game_play_scoring(1, 0, 2);
-- CALL game_play_scoring(1, 0, 3);
-- CALL game_play_scoring(1, 1, 3);
-- CALL game_play_scoring(1, 2, 3);
-- CALL game_play_scoring(1, 3, 3);
-- SELECT * FROM tb_game_player;

-- 7. Player game play acquiring inventory, e.g., picking up items off a tile and putting them in an inventory (bag?) [4]
-- game_play_scoring(IN pPlayerID INT, IN pTileRow INT, IN pTileCol INT)
CALL acquire_item_to_inventory(1, 0, 1);
CALL acquire_item_to_inventory(1, 0, 2);
CALL acquire_item_to_inventory(1, 0, 3);
CALL acquire_item_to_inventory(1, 1, 3);
CALL acquire_item_to_inventory(1, 2, 3);

-- 8. Move an Item (NPC effect). [4]
/*
NOTE: 
For this procedure, you may need to according tb_tile and execute it.
(pTileID is the tile you want to move the item to, pTargetTileID is the destination tile)
Thank you.	
*/
-- Foramt: move_an_item(IN pMapID INT, IN pTileID INT, IN pTargetTileID INT)
-- 1) The target tile is legal
CALL move_an_item(1, 1, 2);
-- 2) The target tile is illegal
CALL move_an_item(1, 99, 99);

-- 9. Kill running games. [4]
CALL kill_running_game(1);

-- 10. Add new players. [4]
-- 	1) Player doesn't exists -> Insert new player
CALL add_player('Tester1', '111@qq.com', '5588465');
-- 	2) Player already exists -> Prompt pops up
CALL add_player('Tester1', '111@qq.com', '5588465');
-- SELECT * FROM tb_Player;

-- 11. Update data of a player. [4]
-- 1) Player doesn't exists -> Prompt pops up
CALL update_player(20, 'updateEMAIL', 'updatePASSWORD', 1, 1, 1, 1);
-- 2) Player exists -> Update data normally
CALL update_player(1, 'UPDATEEMAIL', 'UPDATEPASSWORD', 1, 1, 1, 1);
-- SELECT * FROM tb_Player;

-- 12. Delete a player. [4]
-- 1) Player doesn't exists -> Prompt pops up
CALL delete_player(100);
-- 2) Player exists -> Delete player normally
CALL delete_player(2);
-- SELECT * FROM tb_Player;