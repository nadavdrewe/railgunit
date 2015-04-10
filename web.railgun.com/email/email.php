<?php
$ccr_subject = ' Ajax HTML Contact Form : Demo'; // Subject of your email
$to = $_REQUEST['contact_email'];  //Recipient's E-mail, exlample, $to = "yourid@site.com";

$headers  = 'MIME-Version: 1.0' . "\r\n";
$headers .= "From: " . $_REQUEST['contact_email'] . "\r\n"; // Sender's E-mail
$headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";

$ccr_message .= 'Name: ' . $_REQUEST['full_name'] . "<br>";
$ccr_message .= 'Subject: ' . $_REQUEST['msg_subject'] . "<br>";
$ccr_message .= 'Website: ' . $_REQUEST['website'] . "<br>";
$ccr_message .= $_REQUEST['your_message'];

if (@mail($to, $ccr_subject, $ccr_message, $headers)) {
	// Transfer the value 'sent' to ajax function for showing success message.
	echo 'sent';
}
else
{
	// Transfer the value 'failed' to ajax function for showing error message.
	echo 'failed';
}
?>