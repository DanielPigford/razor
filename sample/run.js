console.log('Hello World');

/*
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/handlebars.js/2.0.0/handlebars.js"></script>

  <!--This is our template. -->
  <!--Data will be inserted in its according place, replacing the brackets.-->
  <script id="address-template" type="text/x-handlebars-template" src="template.hbs"></script>

<script>
$(function () {
  // Grab the template script
  var theTemplateScript = $("#address-template").html();

  // Compile the template
  var theTemplate = Handlebars.compile(theTemplateScript);

  // Define our data object
  var context={
    "city": "London",
    "street": "Baker Street",
    "number": "221B"
  };

  // Pass our data to the template
  var theCompiledHtml = theTemplate(context);

  // Add the compiled html to the page
  $('.content-placeholder').html(theCompiledHtml);
});
</script>

</head>
<body><div class="content-placeholder"></div></body>
</html>
*/