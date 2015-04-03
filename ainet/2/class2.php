<!DOCTYPE html>
<!--
Created by: Joaquim Ley

This is a open source project that I created to share all the college info I can.
You are free to use it to study/modify etc. I would only ask you to refere the source.

www.joaquimley.com
-->

<html>
 <head>

    <meta charset="UTF-8">
    <title>Class 2 PHP</title>

    <!--[if lt IE 9]>
 <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js">
 </script>
 <![endif]-->

 </head>

 <body>
    <?php
    $a = "hello";
    $$a = "world";
    echo "$a ${$a} <br />";
    echo "$a $hello <br />";
    // têm o mesmo output

    $productPrices['clothing']['shirt'] = 20.00;
    $productPrices['clothing']['pants'] = 22.50;
    $productPrices['linens']['blanket'] = 25.00;
    $productPrices['linens']['bedspread'] = 50.00;
    $productPrices['furniture']['lamp'] = 44.00;
    $productPrices['furniture']['rug'] = 75.00;
    $shirtPrice = $productPrices['clothing']['shirt'];

    echo "<table border=1>";

    foreach ($productPrices as $category) {
            foreach ($category as $product => $price) {
                $f_price = sprintf("%01.2f", $price);
                echo "<tr>";
                echo "<td>$product</td>";
                echo "<td>$f_price</td>";
                echo "</tr>";
            }
    }
        echo "</table>";

    ?>

 </body>
</html>
