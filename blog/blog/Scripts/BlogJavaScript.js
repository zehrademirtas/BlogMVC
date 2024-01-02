$(document).ready(function () {
   
    var blogId = $('#blogId').data('blogid');

   
    if (blogId) {
        $.ajax({
            url: '/Blog/OkunmaArttir',
            data: { blogid: blogId },
            type: 'POST',
            success: function (response) {
                console.log('Success:', response);
             
            },
            error: function (xhr, status, error) {
                console.log('Error:', error);
              
            }
        });
    }
});