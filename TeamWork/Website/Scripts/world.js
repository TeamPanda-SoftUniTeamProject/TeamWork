/**
 * Created by ivan on 8/27/16.
 */

function DrawMap()
{
    mapIndex = 0;

    for (var y = 0; y < 13; y++) {

        for (var x = 0; x < 26; x++, mapIndex++) {

            var tile_x = x * BLOCK_W;
            var tile_y = y * BLOCK_H;

            var tileType = map[mapIndex];

            if (tileType == 0)
                grass.draw(tile_x, tile_y, 4);
            if(tileType == 1)
                ground.draw(tile_x, tile_y, 5);
            if(tileType == 2)
                mushroom.draw(tile_x, tile_y, 6);
            if(tileType == 3)
                spikes.draw(tile_x, tile_y, 7);
        }

    }
};