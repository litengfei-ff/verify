
(function(canvas, img, failOver, callBack) {

    //初始化变量
    canvas.width = 300;
    canvas.height = 200;
    var myctx = canvas.getContext("2d");
    var randomPosition = new Object();  //随机小方块坐标
    var length = 40;                    //随机小方块的宽度
    var isIn = false, isDown = false;      //鼠标是否在方块中，鼠标是否按下
    var currentPostion = new Object();  //随机小方块的当前坐标

    //图片加载完成时执行Canvas初始化	
    img.onload = function() {
        InitPaint();
    }

    canvas.onmousemove = function(e) {
        if (e.offsetX >= currentPostion.x
		    && e.offsetX <= currentPostion.x + length
			&& e.offsetY >= currentPostion.y
			&& e.offsetY <= currentPostion.y + length) {
            this.style.cursor = "move";
            isIn = true;
        }
        else {
            this.style.cursor = "";
            isIn = false;
        }

        if (isDown) {
            this.style.cursor = "move";
            Repaint(this, e.offsetX, e.offsetY);
        }
    }

    canvas.onmousedown = function() {
        if (isIn) { isDown = true; }
    }

    canvas.onmouseup = function(e) {
        this.style.cursor = "";
        if (isDown) {
            currentPostion.x = e.offsetX - length / 2;
            currentPostion.y = e.offsetY - length / 2;
            isDown = false;
            if (Math.abs(currentPostion.x - randomPosition.x) <= failOver && Math.abs(currentPostion.y - randomPosition.y) <= failOver) {
                Repaint(this, randomPosition.x + length / 2, randomPosition.y + length / 2);
                callBack();
            }
        }

    }
    //初始化Canvas
    function InitPaint() {
        randomPosition.x = parseInt(Math.random() * 200)
        randomPosition.y = parseInt(Math.random() * 100)

        currentPostion.x = 0;
        currentPostion.y = 160;

        myctx.fillStyle = "#ddd";
        myctx.fillRect(0, 0, canvas.width, canvas.height);
        myctx.drawImage(img, 0, 0, img.width, img.height);
        myctx.drawImage(img, randomPosition.x, randomPosition.y, length, length, currentPostion.x, currentPostion.y, length, length);
        myctx.fillRect(randomPosition.x, randomPosition.y, length, length);
    }
    //重绘Canvas
    function Repaint(obj, desX, desY) {
        myctx.fillStyle = "#ddd";
        myctx.fillRect(0, 0, obj.width, obj.height);
        myctx.drawImage(img, 0, 0, img.width, img.height);
        myctx.fillRect(randomPosition.x, randomPosition.y, length, length);
        myctx.drawImage(img, randomPosition.x, randomPosition.y, length, length, desX - length / 2, desY - length / 2, length, length);
    }

    window.refresh = InitPaint;
})(vertifyCanvas, vertifyImg, failOver, callBack)
  
