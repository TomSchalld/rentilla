$(document).ready(function() {
    
    $(".buttonsearch").css( 'cursor', 'pointer' );
    $(".buttonsearch").click(
        function () {
            
             if( $("#searchRow:visible").length > 0 )
            {
                
                $("#searchRow").slideUp("slow");
            }
               else
            {
               
                $("#searchRow").slideDown("normal");
                
            }
            
            
            $("#searchRow").toggleClass("searchHidden");
            $(".buttonsearch").toggleClass("buttonsearch90");
                
        }
    );
 
});