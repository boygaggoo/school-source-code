<!--
Created by: Joaquim Ley

This is a open source project that I created to share all the college info I can.
You are free to use it to study/modify etc. I would only ask you to refere the source.

www.joaquimley.com
-->
<?php
    require('functions.php');
?>

<!DOCTYPE html>

<html>
 <head>
    <title>PHP: Letter histogram</title>
 </head>

 <body>
     <header>
        <h1> EXERCICIO 5</h1>
     </header>

     <?=
        letter_histogram(mistery_sentence())
     ?>

 </body>
</html>
