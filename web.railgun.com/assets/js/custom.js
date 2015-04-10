(function($) {
  "use strict";
  jQuery(document).ready(function(){

    /*------------  Preloader  ---------------*/
    jQuery(".preloader-box").hide(); 


    /*------------  FitVids  ---------------*/
    jQuery(".container").fitVids(); 


    /*------------ Circliful ---------------*/
    jQuery('.circliful-skill-item').circliful();


    /*------------ Boxer -------------------*/
    jQuery(".boxer").boxer({ 
      margin:100
    }); 

    /*------------ WOW Aniation -------------*/
    new WOW().init();


    /*------------ Hero Banner BG ---------*/ 
    var  heroBannerBG = jQuery('.hero-banner-bg').data('hero-banner-bg');
    jQuery('.hero-banner-bg').css({ 'background-image': 'url("'+ heroBannerBG +'")'});
  });
  //Document Ready end


  var windowHeight = jQuery(window).height();
  jQuery('.hero-banner').css({ "height" : windowHeight });
  jQuery('.hero-banner-bg').css({ "height" : windowHeight });


  jQuery(window).on("load resize",function(e){
    /*------------ Hero banner Height ------*/
    var windowHeight = jQuery(window).height();
    jQuery('.hero-banner').css({ "height" : windowHeight });
    jQuery('.hero-banner-bg').css({ "height" : windowHeight });


    /*------------  Parallax  ---------------*/
    jQuery(".parallax-bg").parallax("50%", 0.5);
    jQuery(".hero-banner-bg").parallax("50%", 0.5);
  });
  //Window on load resize end



  /*------------  Skill Progress bar  ---------------*/
  jQuery( '.progress-bar' ).each(function() { 
    var  barWidth = jQuery(this).data('progress-value');
    jQuery(this).css({ 'width': barWidth });
  });



/*------------  Next Section  ---------------*/
  jQuery( '.next-section' ).each(function() { 
    var  nextSection = jQuery(this).data('next-section');
    jQuery(this).click(function() {
      jQuery('html,body').animate({scrollTop:$( nextSection ).offset().top }, 1000);
    });
  });



  /*------------------------- Owl Carousel -------------------------*/
  var  sliderRuntime = jQuery('.owl-container');
  sliderRuntime.each(function() {
    var  sliderInit = jQuery(this).children('.owl-carousel');  
    var  sliderNext = jQuery(this).find('.carousel-navigator > .next');
    var  sliderPrev = jQuery(this).find('.carousel-navigator > .prev');

    // Create an Object
    var options = {};

    // Responsive items
    if (sliderInit.data('screenitems')){
      options.itemsCustom = sliderInit.data('screenitems');
    };

    // Default items
    if (sliderInit.data('items')){
      options.items = sliderInit.data('items');
    };
    // Set Autoplay
    if (sliderInit.data('autoplay')){
      options.autoPlay = sliderInit.data('autoplay');
    };

    // Set Stop On hover
    if (sliderInit.data('onhover')){
      options.stopOnHover = sliderInit.data('onhover');
    };

    // Paginations
    if (sliderInit.data('pagination')){
      options.pagination = sliderInit.data('pagination');
    };
    
    //  Run the owl carousel
    sliderInit.owlCarousel(options);

    sliderNext.click(function(){
      sliderInit.trigger('owl.next');
    });
    sliderPrev.click(function(){
      sliderInit.trigger('owl.prev');
    });
    
  });
  /*------------------------- End Owl Carousel -----------------*/



  /*-------------------------- Isotope Init --------------------*/
  jQuery(window).on("load resize",function(e){

    var $container = $('.isotope-items'),
    colWidth = function () {
      var w = $container.width(), 
      columnNum = 1,
      columnWidth = 0;
      if (w > 1040)     { columnNum  = 4; }  
      else if (w > 850) { columnNum  = 3; }  
      else if (w > 768) { columnNum  = 2; }  
      else if (w > 480) { columnNum  = 2; }
      columnWidth = Math.floor(w/columnNum);

      //Isotop Version 1
      var $containerV1 = $('.isotope-items.v1');
      $containerV1.find('.item').each(function() {
        var $item = $(this),
        multiplier_w = $item.attr('class').match(/item-w(\d)/),
        multiplier_h = $item.attr('class').match(/item-h(\d)/),
        width = multiplier_w ? columnWidth*multiplier_w[1]-10 : columnWidth,
        height = multiplier_h ? columnWidth*multiplier_h[1]*0.7-10 : columnWidth*0.7-10;
        $item.css({ width: width, height: height });
      });

      //Isotop Version 2
      var $containerV2 = $('.isotope-items.v2');
      $containerV2.find('.item').each(function() {
        var $item = $(this),
        multiplier_w = $item.attr('class').match(/item-w(\d)/),
        multiplier_h = $item.attr('class').match(/item-h(\d)/),
        width = multiplier_w ? columnWidth*multiplier_w[1]-10 : columnWidth,
        height = multiplier_h ? columnWidth*multiplier_h[1]*0.9-10 : columnWidth*1.15-10;
        $item.css({ width: width, height: height });
      }); 

      return columnWidth;
    },
    isotope = function () {
      $container.isotope({
        resizable: true,
        itemSelector: '.item',
        masonry: {
          columnWidth: colWidth(),
          gutterWidth: 10
        }
      });
    };
    isotope();



    // bind filter button click
    $('.isotope-filters').on( 'click', 'button', function() {
      var filterValue = $( this ).attr('data-filter');
      $container.isotope({ filter: filterValue });
    });

      // change active class on buttons
      $('.isotope-filters').each( function( i, buttonGroup ) {
        var $buttonGroup = $( buttonGroup );
        $buttonGroup.on( 'click', 'button', function() {
          $buttonGroup.find('.active').removeClass('active');
          $( this ).addClass('active');
        });
      }); 


    // Masonry Isotope
    var $masonryIsotope = jQuery('.isotope-masonry-items').isotope({
      itemSelector: '.item',
    });
    
    // bind filter button click
    $('.isotope-filters').on( 'click', 'button', function() {
      var filterValue = $( this ).attr('data-filter');
      $masonryIsotope.isotope({ filter: filterValue });
    });
    
    // change active class on buttons
    $('.isotope-filters').each( function( i, buttonGroup ) {
      var $buttonGroup = $( buttonGroup );
      $buttonGroup.on( 'click', 'button', function() {
        $buttonGroup.find('.active').removeClass('active');
        $( this ).addClass('active');
      });
    });
  });


  (function($,sr){
    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
      var timeout;
      return function debounced () {
        var obj = this, args = arguments;
        function delayed () {
          if (!execAsap)
            func.apply(obj, args);
          timeout = null; 
        };

        if (timeout)
          clearTimeout(timeout);
        else if (execAsap)
          func.apply(obj, args);

        timeout = setTimeout(delayed, threshold || 100); 
      };
    }
    // smartresize 
    jQuery.fn[sr] = function(fn){  return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };
  })(jQuery,'smartresize');


  // usage:
  $(window).smartresize(function(){  
    // code that takes it easy...
  });

  //  Isotope Init  End




  /*------------ Overflow y Scroll Fix ---*/ 
  jQuery(window).on("load resize",function(e){
    jQuery('.overflow-yscroll').jScrollPane(); 
  });



  /*-------------------------- Superfish Menu -----------------------*/
  if ( jQuery().superfish ) {
    jQuery('body #primary-menu > ul, body #primary-menu > div > ul,.top-links > ul').superfish({
      popUpSelector: 'ul,.mega-menu-content,.top-link-section',
      delay: 250,
      speed: 350,
      animation: {opacity:'show'},
      animationOut:  {opacity:'hide'},
      cssArrows: false
    });
    jQuery( '#primary-menu ul li:has(ul)' ).addClass('sub-menu');
  }



  /*-------------------------- Top Search and Cart -----------------------*/
  jQuery("#top-search-trigger").click(function(e){
    jQuery('body').toggleClass('top-search-open');
    jQuery('#top-cart').toggleClass('top-cart-open', false);
    e.stopPropagation();
    e.preventDefault();
  });

  jQuery("#top-cart-trigger").click(function(e){
    jQuery('#pagemenu').toggleClass('pagemenu-active', false);
    jQuery('#top-cart').toggleClass('top-cart-open');
    e.stopPropagation();
    e.preventDefault();
  });

  jQuery('#primary-menu-trigger').click(function() {
    jQuery( '#primary-menu > ul, #primary-menu > div > ul' ).toggleClass("show");
    return false;
  });
  jQuery('#page-submenu-trigger').click(function() {
    jQuery('body').toggleClass('top-search-open', false);
    jQuery('#pagemenu').toggleClass("pagemenu-active");
    return false;
  });
  jQuery('#pagemenu').find('nav').click(function(e){
    jQuery('body').toggleClass('top-search-open', false);
    jQuery('#top-cart').toggleClass('top-cart-open', false);
  });



  /*----------------------- Main Menu Apper --------------------------*/
  jQuery(window).on('scroll', function (){
    var firstMenuHeight = 120;
    var secondMenuHeight = 600;
    var findAclassHas = $('#hero-banner');
    if( findAclassHas.hasClass('hero-banner') ){
      var firstMenuHeight = $('.hero-banner').height() + 120; 
      var secondMenuHeight = firstMenuHeight;
    }

    if (jQuery(window).scrollTop() > firstMenuHeight ){
      jQuery('#top-menu-container').addClass('navbar-fixed-top');
    } else {
      jQuery('#top-menu-container').removeClass('navbar-fixed-top');
    } 
    if (jQuery(window).scrollTop() > secondMenuHeight ){
      jQuery('#top-menu-container').addClass('fix-menu');
    } else {
      jQuery('#top-menu-container').removeClass('fix-menu');
    } 
  });



  /*------------  Mega Menu Container Dynamic Width --------------------*/ 
  var windowWidth = jQuery(window).width();
  if ( windowWidth > 950 & windowWidth < 1200) {
    jQuery("#primary-menu ul li.mega-menu .mega-menu-content").css({"width" : windowWidth - 30});
  }



  /*---------------  Browser Detection --------------------*/ 
  if ( jQuery.browser.webkit ) { jQuery('body').addClass('webkit'); }
  if ( jQuery.browser.mozilla ) { jQuery('body').addClass('mozilla'); }
  if ( jQuery.browser.safari ) { jQuery('body').addClass('safari'); }
  if ( jQuery.browser.msie ) { jQuery('body').addClass('msie'); }
  if ( jQuery.browser.opera ) { jQuery('body').addClass('opera'); }

})(jQuery);