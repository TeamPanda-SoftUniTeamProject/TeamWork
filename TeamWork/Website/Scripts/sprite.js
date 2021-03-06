/**
 * Created by ivan on 8/27/16.
 */


var Sprite = function(fn) {

    this.TO_RADIANS = Math.PI/180;
    this.image = null;
    this.is_pattern = false;
    this.pattern = null;
    this.pattern_x_times = 0;

    this.load = function(filename) { this.image = new Image(); this.image.src = filename; return this; };
    this.to_pattern = function(x_times) { this.pattern_x_times = x_times; this.pattern = Context.context.createPattern(this.image, 'repeat'); this.is_pattern = true; };

    this.image = null;
    this.spritesheet = null;


    /* Tutorial 7 Code Start */
    //this.animationDelay = 0;
    //this.animationIndexCounter = 0;
    //this.animationCurrentFrame = 0;
    /* Tutorial 7 Code End */

    // Load from spritesheet
    if (fn instanceof Spritesheet)
    {
        this.spritesheet = fn;
        this.image = this.spritesheet.image;
    }
    else
    // Load from sprite
    if (fn !== undefined && fn != "" && fn != null)
    {
        this.load(fn);
        console.log("Loaded sprite " + fn);
    }
    else
    {
        console.log("Unable to load sprite. Filename '" + fn + "' is undefined or null.");
    }

    // Normal draw
    this.drawOldVersion = function(x, y) {
        Context.context.drawImage(this.image, x, y, BLOCK_W, BLOCK_H);
    };

    this.draw = function(x, y, various)
    {
        // Draw regular sprite
        if (various === undefined)
        {
            Context.context.drawImage(this.image, x, y, BLOCK_W, BLOCK_H);
        } else

        // If various is a single numeric frame id
        if ($.isNumeric(various) && various >= 0) {

            var res = i2xy(various, 8);

            Context.context.drawImage(this.image, res[0]*64, res[1]*64, 64, 64, x, y, 64, 64);

        } else

        // if various is Animation Sequence - an array like [1,2,3,4] or [17,18,19,20];
        if (various.length !== undefined && various.length > 0)
        {
            if (AnimationCounter[AnimationCounterIndex].animationDelay++ >= 3) {
                AnimationCounter[AnimationCounterIndex].animationDelay = 0;
                AnimationCounter[AnimationCounterIndex].animationIndexCounter++;
                if (AnimationCounter[AnimationCounterIndex].animationIndexCounter >= various.length)
                    AnimationCounter[AnimationCounterIndex].animationIndexCounter = 0;
                AnimationCounter[AnimationCounterIndex].animationCurrentFrame = various[AnimationCounter[AnimationCounterIndex].animationIndexCounter];
            }
            res = i2xy(AnimationCounter[AnimationCounterIndex].animationCurrentFrame, 8);
            Context.context.drawImage(this.image, res[0]*64, res[1]*64, 64, 64, x, y, 64, 64);

            AnimationCounterIndex++;
        }
    };

    //Draw from spritesheet

    // this.drawAnimated = function (x, y, spriteSheetIndex) {
    //   if (spriteSheetIndex.length != undefined)
    //   {
    //       if(this.animationDelay++ >= 3)
    //       {
    //           this.animationDelay = 0;
    //           this.animationIndexCounter++;
    //           if (this.animationIndexCounter >= spriteSheetIndex.length)
    //               this.animationIndexCounter = 0;
    //           this.animationCurrentFrame = spriteSheetIndex[this.animationIndexCounter];
    //       }
    //
    //       var res = i2xy(this.animationCurrentFrame, 8);
    //
    //       Context.context.drawImage(this.image, res[0]*32, res[1]*32, 32, 32, x, y, 32, 32);
    //   }
    // };


    this.rotAnim = function(x, y, sequence, angle)
    {
        if (AnimationCounter[AnimationCounterIndex].animationDelay++ >= 3) {
            AnimationCounter[AnimationCounterIndex].animationDelay = 0;
            AnimationCounter[AnimationCounterIndex].animationIndexCounter++;
            if (AnimationCounter[AnimationCounterIndex].animationIndexCounter >= sequence.length)
                AnimationCounter[AnimationCounterIndex].animationIndexCounter = 0;
            AnimationCounter[AnimationCounterIndex].animationCurrentFrame = sequence[AnimationCounter[AnimationCounterIndex].animationIndexCounter];
        }
        var res = i2xy(AnimationCounter[AnimationCounterIndex].animationCurrentFrame, 8);

        Context.context.save();
        Context.context.translate(x+32, y+32);    // Translate sprite to its center
        Context.context.rotate(angle * this.TO_RADIANS);    // Rotate sprite around its center
        Context.context.drawImage(this.image, res[0]*64, res[1]*64, 64, 64,
            -32, -32,                         // Translate sprite back to its original position
            64, 64);
        Context.context.restore();

        AnimationCounterIndex++;
    };

    // Stretched draw
    this.draw2 = function(x, y, w, h) {
        if (this.is_pattern) {
            //Context.context.fillStyle = Context.context.createPattern(this.image, 'repeat');;
            //Context.context.fillRect(x, y, w, h);
            for (var i = 0; i < this.pattern_x_times; i++) {
                Context.context.drawImage(this.image, x + w*i, y, w, h);
            }
        } else {
            Context.context.drawImage(this.image, x, y, w, h);
        }
    };

    // Rotated draw
    this.rot = function(x, y, angle) {
        Context.context.save();
        Context.context.translate(x, y);
        Context.context.rotate(angle * this.TO_RADIANS);
        Context.context.drawImage(this.image, -(this.image.width/2), -(this.image.height/2));
        Context.context.restore();
    };
};