/**
 * Created by ivan on 8/28/16.
 */

var Keyboard = function () {
    this.leftArrow = false;
    this.rightArrow = false;
    this.upArrow = false;
    this.downArrow = false;
    this.spaceBar = false;

};

var KEY_LEFT = 37;
var KEY_RIGHT = 39;
var KEY_UP = 38;
var KEY_DOWN = 40;
var KEY_SPACE = 32;


// Key state for four keys
//var kstate = [false, false, false, false, false];
window.key = null;


function InitializeKeyboard() {

    window.key = new Keyboard();

    $(document).keydown(function (e) {

       if(e.keyCode == KEY_LEFT) { key.leftArrow = true; }

       if(e.keyCode == KEY_RIGHT) { key.rightArrow = true; }

       if(e.keyCode == KEY_UP) { key.upArrow = true; }

       if(e.keyCode == KEY_DOWN) { key.downArrow = true;}

       if(e.keyCode == KEY_SPACE) { key.spaceBar = true; }
    });

    $(document).keyup(function (e) {

        if(e.keyCode == KEY_LEFT) { key.leftArrow = false; }

        if(e.keyCode == KEY_RIGHT) { key.rightArrow = false; }

        if(e.keyCode == KEY_UP) { key.upArrow = false; }

        if(e.keyCode == KEY_DOWN) { key.downArrow = false; }

        if(e.keyCode == KEY_SPACE) { key.spaceBar = false; }
    });
}