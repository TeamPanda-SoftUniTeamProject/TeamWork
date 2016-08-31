/**
 * Created by ivan on 8/28/16.
 */
var Point = function (_x, _y)
{
    this.x = _x;
    this.y = _y;

    this.draw = function (size, color)
    {
        gfx.beginPath();
        gfx.arc(this.x, this.y, 0, 2 * Math.PI, true);
        gfx.fillStyle = color;
        gfx.fill();
        gfx.strokeStyle = color;
        gfx.stroke();

    }

};