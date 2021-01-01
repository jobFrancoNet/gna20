<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

<link href="css/gnacss.css" rel="stylesheet" type="text/css" />

<TITLE>AspJpeg - scrivo testo al volo su immagine</TITLE>
</HEAD>
<BODY>
<h3>AspJpeg - scrivo testo al volo su immagine</h3>

<%
	Set Jpeg = Server.CreateObject("Persits.Jpeg")

	' Open source image
	Jpeg.Open Server.MapPath("images/dodge_viper.jpg")

	' Resizing is optional. None in this code sample.

	' Draw text
	Jpeg.Canvas.Font.Color = &HFF0000 ' red
	Jpeg.Canvas.Font.Family = "Courier New"
	Jpeg.Canvas.Font.Bold = True
	Jpeg.Canvas.Font.Quality = 4 ' antialiased
	Jpeg.Canvas.Font.BkMode = "Opaque" ' to make antialiasing work

	Jpeg.Canvas.Print 55, 372, Jpeg.Open Server.MapPath("images/close.gif")

	' Draw frame: black, 2-pixel width
	Jpeg.Canvas.Pen.Color = &H000000 ' Black
	Jpeg.Canvas.Pen.Width = 2
	Jpeg.Canvas.Brush.Solid = False ' or a solid bar would be drawn
	Jpeg.Canvas.DrawBar 1, 1, Jpeg.Width, Jpeg.Height


	Jpeg.Save Server.MapPath("/public/dodge_viper_framed.jpg")
%>

<IMG SRC="/public/dodge_viper_framed.jpg">

</BODY>
</HTML>
