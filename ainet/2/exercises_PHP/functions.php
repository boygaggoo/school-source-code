<!--
Created by: Joaquim Ley

This is a open source project that I created to share all the college info I can.
You are free to use it to study/modify etc. I would only ask you to refere the source.

www.joaquimley.com
-->

<?php
// EXERCISE 2
function times_table_view(){

    $str = "<table><thead><tr><th>*</th>";

    for ($i = 1; $i <= 10; $i++) {
        $str .= "<th>$i</th>";
    }

    $str .= "</thead></tr>";

    for ($i = 1; $i < 11; $i++) {
        $str .= "<tr><td class=\"mlt-numb\">$i</td>";

        for ($j = 1; $j < 11; $j++) {
            if($i == $j){
                $tbs = $i * $j;
                $str .="<td class=\"diag\">$tbs</td>";
            }else{
                $tbs = $i * $j;
                $str .="<td>$tbs</td>";
            }
        }
        $str .="</tr>";
    }
    $str .="</table>";
    return $str;
}

// EXERCISE 3
function prime_numbers($n){
    $number = 2; // possiveis numeros que podem ser primos
    $count_div = 0; // contador de divisoes que verifica se divisel apenas por 1 e o proprio numero
    $primes_array = array(); // array nao inicializado

    while ($number <= $n) {
        for($i = 1; $i <= $number; $i++){
            if (($number % $i) == 0) {
                $count_div++;
            }
        }
        if($count_div == 2){
            $primes_array[] = $number;
        }
        $number++;
        $count_div = 0;
    }

    return $primes_array;
}
function prime_numbers_view($n){

    $primes = prime_numbers($n);

    $htm = "<p>";
    foreach ($primes as $item) {
        $htm .= "$item ";
    }
    $htm .= "</p>";

    return $htm;
}

// or
// function prime_numbers_view($limit= $n){
//    return "<p>".implode(", ",prime_number($limit);
// }

// EXERCISE 4
function mistery_sentence(){
    $nouns = [
        "earth",
        "pin",
        "rhythm",
        "silver",
        "market",
        "snakes",
        "knee",
        "cushion",
        "ticket",
        "bee",
        "bait",
        "cub",
        "camera",
        "sink",
        "crowd",
        "grain",
        "bikes",
        "sense",
        "cannon",
        "cobweb",
        "nose",
        "river",
        "grass",
        "experience",
        "rock",
        "church",
        "connection",
        "arch",
        "harmony",
        "zoo",
        "store",
        "waves",
        "mitten",
        "hate",
        "boy",
        "competition",
        "floor",
        "taste",
        "cattle",
        "fly",
        "servant",
        "price",
        "self",
        "smoke",
        "birth",
        "structure",
        "kiss",
        "vest",
        "spade",
        "kitty",
        "steam",
        "level",
        "society",
        "stream",
        "card",
        "scale",
        "relation",
        "shoe",
        "cover",
        "cough",
        "stick",
        "trains",
        "playground",
        "event",
        "touch",
        "partner",
        "tail",
        "stitch",
        "yoke",
        "argument",
        "recess",
        "education",
        "ray",
        "song",
        "stretch",
        "bed",
        "eggs",
        "crow",
        "low",
        "dirt",
        "hope",
        "page",
        "wound",
        "vessel",
        "sister",
        "window",
        "vegetable",
        "expansion",
        "record",
        "cows",
        "woman",
        "gun",
        "wall",
        "rake",
        "ink",
        "writer",
        "transport",
        "guide",
        "bird",
        "horse",
    ];

    $verbs = [
        "tie",
        "reproduce",
        "stop",
        "deceive",
        "melt",
        "entertain",
        "screw",
        "smile",
        "peck",
        "book",
        "yell",
        "walk",
        "yawn",
        "return",
        "wriggle",
        "rely",
        "warm",
        "open",
        "change",
        "receive",
        "order",
        "soak",
        "exercise",
        "stuff",
        "print",
        "ask",
        "pause",
        "arrange",
        "share",
        "shelter",
        "crush",
        "wink",
        "file",
        "stitch",
        "bat",
        "flower",
        "decorate",
        "arrive",
        "drown",
        "provide",
        "number",
        "level",
        "travel",
        "found",
        "inform",
        "love",
        "deserve",
        "press",
        "interfere",
        "prepare"
    ];

    $objects = [
        "bread",
        "candle",
        "toothbrush",
        "chocolate",
        "hanger",
        "tissue box",
        "couch",
        "street lights",
        "mirror",
        "playing card",
        "conditioner",
        "bracelet",
        "ring",
        "greeting card",
        "washing machine",
        "grid paper",
        "bowl",
        "sharpie",
        "mp3 player",
        "rusty nail",
        "stop sign",
        "drill press",
        "tree",
        "USB drive",
        "shampoo",
        "soda can",
        "face wash",
        "paint brush",
        "bed",
        "zipper",
        "hair tie",
        "radio",
        "socks",
        "buckel",
        "drawer",
        "chalk",
        "soap",
        "rug",
        "brocolli",
        "window",
        "toothpaste",
        "hair brush",
        "milk",
        "house",
        "cork",
        "sketch pad",
        "candy wrapper",
        "bottle cap",
        "door",
        "fridge",
        "clock",
        "eye liner",
        "spoon",
        "cell phone",
        "nail clippers",
        "towel",
        "water bottle",
        "cat",
        "shoe lace",
        "newspaper",
        "chair",
        "coasters",
        "sandal",
        "balloon",
        "sun glasses",
        "air freshener",
        "lamp",
        "paper",
        "knife",
        "blouse",
        "wallet",
        "headphones",
        "stockings",
        "ipod",
        "checkbook",
        "watch",
        "shirt",
        "tooth picks",
        "mop",
        "outlet",
        "clothes",
        "deodorant",
        "shovel",
        "book",
        "glasses",
        "lamp shade",
        "remote",
        "pen",
        "desk",
        "plastic fork",
        "beef",
        "table",
        "leg warmers",
        "tv",
        "thermometer",
        "phone",
        "key chain",
        "soy sauce packet",
        "cinder block",
        "floor"
    ];

    return $sentence = $nouns[rand(0,count($nouns) - 1)]." ".$verbs[rand(0,count($verbs) - 1)]." ".$objects[rand(0,count($objects) - 1)];
}

//EXERCICIO 5
function letter_histogram($text){
    echo "$text";
    $init = 0;
    $strarr = str_split($text);
    $letter_counter = array();

    foreach ($strarr as $letter) {
        if($init == 0){
            $letter_counter[] = array($letter => 1);
            $init=1;
            //echo key($letter_counter[0]);
        }
        else{
            $trigger = 0;
            $i = 0;
            while ($i < (count($letter_counter)) && $trigger == 0) {
                if ($letter == key($letter_counter[$i])) {
                    $val = $letter_counter[$i];
                    $v = $val[key($val)]+1;
                    $letter_counter[$i] = array($letter => $v);
                    $trigger = 1;
                }else{
                    if ($i == (count($letter_counter)-1)) {
                        $letter_counter[] = array($letter => 0);
                        //$letter_counter[] = array($letter => 1);
                    }
                }
                $i++;
            }
        }
    }

    // echo var_dump($letter_counter);

    $htm = "<table border =1px>";
    foreach ($letter_counter as $letter => $numb) {
        $htm .= "<tr><td>".key($numb)."</td><td>". $numb[key($numb)]."</td></tr>";
    }
    $htm .= "</table>";

    return $htm;
}
?>
