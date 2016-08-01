$(document).ready(function () {

    $('.flexslider').flexslider({
        animation: "slide",
        animationLoop: true,
        itemWidth: 100,
        itemMargin:0,
        minItems: 1,
        maxItems: 3,
        move:1,
        controlNav: false,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
        directionNav: true,
        slideshowSpeed: 3000,           //Integer: Set the speed of the slideshow cycling, in milliseconds
        animationSpeed: 600,
        pauseOnHover: true,
    });

    $('.flexslider1').flexslider({
        animation: "slide",
        animationLoop: true,
        itemWidth: 100,
        itemMargin:0,
        minItems: 1,
        maxItems: 3,
        move:1,
        controlNav: true,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
        directionNav: true,
        slideshowSpeed: 3000,           //Integer: Set the speed of the slideshow cycling, in milliseconds
        animationSpeed: 600,
        pauseOnHover: true,
    });
});