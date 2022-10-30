<?php
include('connection.php');

$sql = "select UserName, PassWord, Email from user;";
$result = mysqli_query($connect, $sql);

if (mysqli_num_rows($result) > 0) {
    while ($row = mysqli_fetch_assoc($result)) {
        echo "username:".$row['UserName']."|email:".$row['Email']."|password:".$row['PassWord'].";";
    }
}

?>