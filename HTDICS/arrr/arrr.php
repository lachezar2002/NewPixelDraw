<!DOCTYPE html> 
<html> 
<head> 
    <meta charset="UTF-8" /> 
    <title>PHP курс Kabinata.com 2015</title> 
</head> 
<body> 
<form method="post" enctype="multipart/form-data" action="arrr.php"> 
    <input type="file" name="userfile"> 
    <input type="Submit" value='Send this file'> 
</form> 
<pre> 
<?php 
$alowed_ext = array('jpg', 'png', 'gif', 'doc', 'txt', 'zip', 'pdf'); 


if(isset($_FILES['userfile']) && $_FILES['userfile']['error']==0){ 
    $fileinfo = pathinfo($_FILES['userfile']['name']); 
    if(array_search($fileinfo['extension'], $alowed_ext)!== false) { 
        move_uploaded_file($_FILES['userfile']['tmp_name'], './upload/'.$_FILES['userfile']['name']); 
    }else{ 
        echo "Bad file extension"; 
    } 
} 


$directory = dir('./upload'); 
echo "Handle: " . $directory->handle . "<br>"; 
echo "Path: " . $directory->path . "<br>"; 
echo "<ul>"; 
while( ($entry=$directory->read()) !== false){ 
    if($entry == "." || $entry == "..") continue; 
    echo "<li>"; 
    if(is_dir('./upload/'.$entry)){ 
        echo "[D] "; 
    } 
    if(is_file('./upload/'.$entry)){ 
        echo "[F] "; 
        echo "<a href='9download.php?f=$entry'>"; 
        echo $entry; 
        echo "</a>"; 
    }else{ 
        echo $entry; 
    } 
    $size = filesize('./upload/'.$entry); 
    if($size>1024){ 
        $fsize = round($size/1024)."KB"; 
    } 
    if($size>1048576){ 
        $fsize = round($size/1048576)."MB"; 
    } 
    if($size>1073741824){ 
        $fsize = round($size/1073741824)."GB"; 
    } 
     
    echo "[".$fsize."]"; 
    echo "</li>"; 
} 
echo "</ul>"; 
?> 
</pre> 
</body>