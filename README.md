# verify
验证码大全

1.文档结构
	-index.html           演示主页面
	-JS                   
	   --index.js         进行验证码切换和验证需要调用的JS文件
	   --canvasVertigy.js 拖拽验证需要使用的JS
	   --jquery.min.js.js JQuery文件
	-Images               存放图片文件		
	-Handles
	   --GetVertify.ashx  使用它来获取验证码  
	   --Auth.ashx        使用它来进行验证码验证  

	-App_Code             
	   --Gif                  此文件夹存放进行Gif合成需要用到的类文件
	   --AbstractVertify.cs   验证码抽象类
	   --CharsVertify.cs      字符型验证码类
	   --MathVertify.cs       数学计算验证码类
	   --ImagesVertify.cs     多图片选择验证类(12306)
	   --GifVertify.cs        Gif动画验证类
	-Vertify.mdf              进行多图选择验证需要用到的数据文件	   

2.使用方法
	本文实现了6种形式的验证码：
            a 数字字母组成的验证码
            b 汉字验证码
            c 数学计算验证码
            d 拖拽验证码
            e 12306验证码
            f Gif动画验证码

	使用时只需对img标签src属性的值进行修改即可
	<img id="img" alt="验证码" src="Handles/GetVertify.ashx?ver=chineseVertify" />        
	ver=alphasVertify    使用字符验证码 
	ver=chineseVertify   使用汉字验证码
	ver=mathVertify	     使用数学计算验证码
	ver=imagesVertify    使用多图选择验证码（12306）

	拖拽验证和Gif动画验证不需要进行上述操作，具体使用请参考主页面。

3.实现原理
	在抽象类AbstractVertify中实现验证码的大部分方法，针对不同验证码的需要在派生类中进行重写。
	
