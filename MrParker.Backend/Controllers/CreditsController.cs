using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.Controllers
{
    [ApiController]
    public class CreditsController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/raw")]
        public string GetCreditsString()
        {
            return @"  __  __         _____              _                
 |  \/  |       |  __ \            | |               
 | \  / | _ __  | |__) |__ _  _ __ | | __ ___  _ __  
 | |\/| || '__| |  ___// _` || '__|| |/ // _ \| '__| 
 | |  | || | _  | |   | (_| || |   |   <|  __/| |    
 |_|  |_||_|(_) |_|    \__,_||_|   |_|\_\\___||_|    
                                                      
 Digital Parking Spaces Solution
 Developed by WeAreRoot @YB Hackathon 2021, Wankdorf Stadium Bern									 

 WeAreRoot Team Members:
  > Anja Jentzsch
  > Gerhard Hausammann
  > Martin Käser
  > Matthias Schneeberger
  > Rolf Nyffenegger
 
                                     `$/              
           __                        O$               
       _.-""  )                        $'              
    .-""`. .-"":        o      ___     ($o              
 .-"".-  .'   ;      ,st+.  .' , \    ($               
:_..-+""""    :       T   ""^T==^;\;;-._ $\              
   """"""""-,   ;       '    /  `-:-// / )$/              
        :   ;           /   /  :/ / /dP               
        :   :          /   :    )^-:_.l               
        ;    ;        /    ;    `.___, \           .-,
       :     :       :  /  ;.q$$$$$$b   \$$$p,    /  ;
       ;   :  ;      ; :   :$$$$$$$$$b   T$$$$b .'  / 
       ;   ;  :      ;   _.:$$$$$$$$$$    T$$P^""   /l 
       ;.__L_.:   .q$;  :$$$$$$$$$$$$$;_   TP .-"" / ; 
       :$$$$$$;.q$$$$$  $$$$$$$$$$$$$$$$b  / /  .' /  
        $$$$$$$$$$$$$;  $$$$$$$$P^"" ""^Tb$b/   .'  :   
        :$$$$$$$$$$$$;  $$$$P^jp,      `$$_.+'    ;   
        $$$$$$$$$$$$$;  :$$$.d$$;`- _.-d$$ /     :    
        '^T$$$$$P^^""/   :$$$$$$P      d$$;/      ;    
                   :    $$$$$$P""-. .--$$P/      :     
                   ;    $$$$P'( ,    d$$:b     .$     
                   :    :$$P .-dP-'  $^'$$bqqpd$$     
                    `.   """" ' s"")  .'  d$$$$$$$$'     
                      \           /;  :$$$$$$$P'      
                    _  ""-, ;       '.  T$$$$P'        
                   / ""-.'  :    .--.___.`^^'          
                  /      . :  .'                      
                  ),sss.  \  :                        
                 : TP""""Tb. ; ;                        
                 ;  Tb  dP   :                        
                 :   TbdP    ;                        
                  \   $P    /                         
                   `-.___.-'                          


We all have secrets: the ones we keep... and the ones that are kept from us
Peter Parker (Spider-Man - The Amazing Spider-Man)

>_";
        }

        [HttpGet]
        [Route("[controller]")]
        public ContentResult GetCreditsHtml()
        {
            var template = $@"<!doctype html>
<html lang=""en"">
<head>
    <meta charset=""utf-8"">
    <title>WeAreRoot - Credits | Hackathon 2021</title>
    <style>
    body{{
        background: #001064;
        color: #f00;
    }}
    </style>
</head>
<body>
    <pre>
{GetCreditsString()}
    </pre>
</body>
</html>";

            return base.Content(template, "text/html; charset=utf-8");
        }
    }
}
