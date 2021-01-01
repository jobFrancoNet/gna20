<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="slideshowcorsi.aspx.vb" Inherits="GNAVBMForm.slideshowcorsi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="javascript/jquery.js"></script>

 <script type="text/javascript">
               
        
     var conta = 0;

     var array_immagini_corso = new Array();
     array_immagini_corso[0] = "slideshow/locandina1.jpg";
     array_immagini_corso[1] = "slideshow/Locandina2.jpg";
     array_immagini_corso[2] = "slideshow/Locandina3.jpg";
     array_immagini_corso[3] = "slideshow/Locandina4.jpg";
     array_immagini_corso[4] = "slideshow/Locandina5.jpg";
     array_immagini_corso[5] = "slideshow/Locandina6.jpg";

     var cnt2 = array_immagini_corso.length;


        $(document).ready(function () {


            
             $(function() {
                 setInterval(SlideCorso, 5000);
            });

                
     });

     function SlideCorso()
     {
          $("#imgslidecorsi").show("slow", function() {
        $(this).attr("src", array_immagini_corso[(array_immagini_corso.length++) % cnt2]).show();

        conta = conta + 1;
              if (conta == 2)
              {

                  $("#link2").attr("href", "DetailsPageCorso.aspx");
              }
              if (conta == 3)
              {
                  $("#link2").attr("href", "DetailsPageCorso.aspx");
              }

              if (conta == 4)
              {
                  $("#link2").attr("href", "DetailsPageCorso.aspx");
              }
              if (conta == 5)
              {
                  $("#link2").attr("href", "DetailsPageCorso.aspx");
              }
              if (conta == 6)
              {
                  $("#link2").attr("href", "DetailsPageCorso.aspx");
              }
                          
        

        if (conta ==6)
        {
            conta = 0
           
        }

    });
        
       }

        

      
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="scopri-gna-testo"><div id="fade-uno"><a href="http://www.guardianazionaleambientale.net/DetailsPageCorso.aspx" target="_blank" id="link2"><img id="imgslidecorsi" alt="" src="slideshow/locandina1.jpg" /></a>
                    </div>

                    </div>
            </div>
    </form>
</body>
</html>
