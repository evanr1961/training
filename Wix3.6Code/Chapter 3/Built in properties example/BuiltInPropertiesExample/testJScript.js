var shell = new ActiveXObject("WScript.Shell");
var ARPCOMMENTS = Session.Property("ARPCOMMENTS")
shell.Popup("This is a jscript dialog...ARPCOMMENTS = ".concat(ARPCOMMENTS));