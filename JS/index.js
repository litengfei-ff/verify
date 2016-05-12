//-------------第一个验证码的验证方法
$("#imgVer1").on("click", function() {
$("#imgVer1").attr("src", "Handles/GetVertify.ashx?ver=alphasVertify&t=" + (new Date).getTime());
});

$("#submitVer1").on("click", function() {
    var text = $("#txtVer1").val();
    if (text == "") return false;
    $.ajax({
        type: "GET",
        data: { "alphasVertify": text, "t": new Date().getTime() },
        url: "Handles/Auth.ashx",
        success: function(data) {

            if (data == "OK") { $("#resultVer1").text("OK"); }
            else { $("#resultVer1").text("NO"); }
        }



    });
});
//-------------第二个验证码的验证方法
$("#imgVer2").on("click", function() {

$("#imgVer2").attr("src", "Handles/GetVertify.ashx?ver=chineseVertify&t=" + (new Date).getTime());
});

$("#submitVer2").on("click", function() {
    var text = $("#txtVer2").val();
    if (text == "") return false;
    $.ajax({
        type: "GET",
        data: { "chineseVertify": text, "t": new Date().getTime() + "1" },
        url: "Handles/Auth.ashx",
        success: function(data) {

            if (data == "OK") { $("#resultVer2").text("OK"); }
            else { $("#resultVer2").text("NO"); }
        }



    });
});

//-------------第三个验证码的验证方法
$("#imgVer3").on("click", function() {

$("#imgVer3").attr("src", "Handles/GetVertify.ashx?ver=mathVertify&t=" + (new Date).getTime());
});

$("#submitVer3").on("click", function() {
    var text = $("#txtVer3").val();
    if (text == "") return false;
    $.ajax({
        type: "GET",
        data: { "mathVertify": text, "t": new Date().getTime() + "2" },
        url: "Handles/Auth.ashx",
        success: function(data) {

            if (data == "OK") { $("#resultVer3").text("OK"); }
            else { $("#resultVer3").text("NO"); }
        }



    });
});

//---拖拽验证-----
var vertifyImg = new Image();
vertifyImg.width = 300;
vertifyImg.height = 150;
vertifyImg.src = "./Images/index/1.jpg";

var vertifyCanvas = document.getElementById("vertifyCanvas");
//容错量
var failOver = 8;
var vertifyOK = false;
$("#canvasChange").on("click", function() {
    refresh();
    $("#canvasResult").text("");
})
function callBack() {
    $("#canvasResult").text("Yes");
}


//---12306验证--------------

$("#changeImg").on("click", function() {

$("#imgVer5").attr("src", "Handles/GetVertify.ashx?ver=imagesVertify&t=" + (new Date).getTime());
    $("#ver5").find("div").remove();
    $("#resultVer5").text("");
    return false;
});


$("#ver5").on("click", function(e) {

    if (e.offsetY >= 35 && e.offsetX <= 290) {
        var $select = $("<div style='left:" + (e.offsetX - 13) + "px;top:" + (e.offsetY - 13) + "px; width: 27px;height: 27px;background-image: url(./Images/index/captcha.png); background-position: 0 -96px; position:absolute' ></div>");
        $(this).append($select);

        $select.click(function() {
            $(this).remove();
            return false;
        });
    }
})

var result = "";
$("#submitVer5").on("click", function() {
    result = "";
    var $divs = $("#ver5").find("div");

    for (var i = 0; i < $divs.length; i++) {
        result += IsContain($($divs[i]).position().left + 13, $($divs[i]).position().top + 13);
    }
})


$("#submitVer5").on("click", function() {
    if (result == "") return false;
    $.ajax({
        type: "GET",
        data: { "imagesVertify": result, "t": new Date().getTime() },
        url: "Handles/Auth.ashx",
        success: function(data) {

            if (data == "OK") { $("#resultVer5").text("OK"); }
            else { $("#resultVer5").text("NO"); }
        }

    });
});

function IsContain(x, y) {

    if (x >= 10
	        && y >= 35
	        && x <= 100
	        && y <= 115)
    { return 1; }

    if (x >= 105
	        && y >= 35
	        && x <= 195
	        && y <= 115)
    { return 2; }

    if (x >= 200
	        && y >= 35
	        && x <= 290
	        && y <= 115)
    { return 3; }

    if (x >= 10
	        && y >= 120
	        && x <= 100
	        && y <= 200)
    { return 4; }

    if (x >= 105
	        && y >= 120
	        && x <= 195
	        && y <= 200)
    { return 5; }

    if (x >= 200
	        && y >= 120
	        && x <= 290
	        && y <= 200)
    { return 6; }
    return 0;
}


//-----Gif验证码--------

function CreateGif() {
    $.ajax({
        type: "GET",
        data: { "t": new Date().getTime() },
        url: "Handles/GetVertify.ashx?ver=gifVertify",
        success: function() {

            $("#imgVer6").attr("src", "Images/index/ver.gif");
        }

    });


}

CreateGif();

$("#imgVer6").on("click", function() {

    CreateGif();
});


$("#submitVer6").on("click", function() {
    var text = $("#txtVer6").val();
    if (text == "") return false;
    $.ajax({
        type: "GET",
        data: { "gifVertify": text, "t": new Date().getTime() },
        url: "Handles/Auth.ashx",
        success: function(data) {

            if (data == "OK") { $("#resultVer6").text("OK"); }
            else { $("#resultVer6").text("NO"); }
        }



    });
});


