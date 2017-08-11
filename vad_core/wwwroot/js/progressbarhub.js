$(function () {
    var connectionId = null;
    // Declare a proxy to reference the hub.
    var pr = $.connection.progressHub;
    // Create a function that the hub can call to broadcast messages.
    pr.client.addProgress = function (percentage) {
        var bar1 = document.getElementById('myBar').ldBar;
        bar1.set(parseInt(percentage));
    };


    // Start the connection.
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        connectionId = $.connection.hub.id;
        console.log(connectionId);
    });
    $.connection.hub.disconnected(function () {
        //Not sure about this
        setTimeout(function () {
            $.connection.hub.start();
        }, 5000); // Restart connection after 5 seconds.
        console.log(connection.hub.id, 'disconnected');
    });
});