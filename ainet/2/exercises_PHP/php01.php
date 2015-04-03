<!--
Created by: Joaquim Ley

This is a open source project that I created to share all the college info I can.
You are free to use it to study/modify etc. I would only ask you to refere the source.

www.joaquimley.com
-->

<!DOCTYPE html>

<html>
 <head>
    <meta charset="UTF-8">
    <title>PHP: Using vars</title>
    <!--[if lt IE 9]>
        <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
 </head>

 <body>
    <header>
        <h1>Exercise 1</h1>
     </header>
    <?php

    $a = "hello";
    $$a = "world";
    $b = 12;
    $c = 5.8;
    $bo = true;

    echo "String: $a ${$a} <br />";
    echo "Integer: $b <br />";
    echo "Float: $c <br />";
    echo "Boolean: $bo (true = 1, false=0) <br />";

    ?>

 </body>
</html>
