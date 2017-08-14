$(function () {
    var connectionId = null;
    // Declare a proxy to reference the hub.
    var pr = $.connection.visualizationHub;
    // Create a function that the hub can call to broadcast messages.
    pr.client.visualizeVad = function (percentage) {
        //update visual part
        console.log("HELLO");
    };


    //// Start the connection.
    //$.connection.hub.start({ waitForPageLoad: false }).done(function () {
    //    connectionId = $.connection.hub.id;
    //    console.log(connectionId);
    //});
    //$.connection.hub.disconnected(function () {
    //    //Not sure about this
    //    setTimeout(function () {
    //        $.connection.hub.start();
    //    }, 5000); // Restart connection after 5 seconds.
    //    console.log(connection.hub.id, 'visual hub: client disconnected');
    //});

});