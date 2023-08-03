function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {

            //statistics are hidden
            $.get('https://localhost:7165/api/statistics', function (data) {
                $('#total_trips').text(data.totalTrips + " Trips");
                $('#total_available_trips').text(data.totalTripsAvailableToJoin + " Trips Available");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide Statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show Statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
       
    })
}

/*function displayAdditionalFields() {  
    console.log('in script');
    $('#test_btn').on('click',function(e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('additional_info').hasClass('d-none')) {
            //display section
            console.log('here2');
            $('additional_info').removeClass('d-none');
        } else {
            //hide section
            console.log('here3');
            $('additional_info').addClass('d-none');
        }
        console.log('here1');

        //$('#test_div').addClass('d-none');
        //$('#test_btn').text = "fuck";
        
    })
}*/