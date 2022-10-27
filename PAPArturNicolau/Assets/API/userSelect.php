<?php
include('connection.php');

$sql = "SELECT UserName, PassWord, Email FROM user;"
$result = mysqli_query($connect, $sql);

if (mysql_num_row($result) > 0) {
    while ($row = mysqli_fetch_assoc($result)) {
        echo "username:".$row['username']."|email:".$row['email']."|password:".$row['PassWord'].";";
    }
}

?>