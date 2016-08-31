/**
 * Created by ivan on 8/28/16.
 */
var Vector = function (_x, _y)
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

    this.add = function (vector)
    {
        return new Vector(this.x += vector.x, this.y += vector.y);

    }

    this.subtract = function (vector)
    {
        return new Vector(this.x -= vector.x, this.y -= vector.y);

    }

    this.multiply = function (multiplier)
    {
        return new Vector(this.x *= multiplier, this.y *= multiplier)

    }

    this.length = function ()
    {
       return Math.sqrt(this.x * this.x + this.y * this.y);

    }

    this.cross = function (vector)
    {
        return this.x * vector.y - this.y * vector.x;

    }

    this.dot = function (vector)
    {
        return this.x * vector.x + this.y * vector.y;

    }

};