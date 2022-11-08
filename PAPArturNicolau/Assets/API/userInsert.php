<?php
include('connection.php');

$username = $_POST['addUsername'];
$email = $_POST['addEmail'];
$password = $_POST['addPassword'];

$sql = "insert into `User`(UserName, PassWord, Email) values('".$username."', aes_encrypt('".$password."', 'shrek'), aes_encrypt('".$email."', 'shrek'));";
$result = mysqli_query($connect, $sql);
?>