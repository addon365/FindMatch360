(function($) {
	"use strict";
	
    $(function () {
		
	
    $('#world-map-markers').vectorMap({
            map : 'us_aea_en',
            backgroundColor : 'transparent',
            zoomOnScroll: false,
            regionStyle : {
                initial : {
                    fill : '#c9d6de'
                }
            },
            markers: [{
                    latLng : [40.70, -78.00],
                    name : 'Newyork: 175'
                    , style: {fill: '#4b71fa'}
                },{
                    latLng : [39.00, -98.48],
                    name : 'Kansas: 386'
                    , style: {fill: '#f4516c'}
                },
              {
                latLng : [37.00, -122.05],
                name : 'Vally : 450'
                , style: {fill: '#F6BB42'}
              }]
        });

		

		var donut = c3.generate({
			bindto: '#donut',
			data: {
				columns: [
					['Other',15],
					['Desktop',45],
					['Tablet', 15],
					['Mobile', 25],
				],
				type : 'donut',
				onclick: function (d, i) { console.log("onclick", d, i); },
				onmouseover: function (d, i) { console.log("onmouseover", d, i); },
				onmouseout: function (d, i) { console.log("onmouseout", d, i); }
			},
			donut: {
				label: {
					show: false
				  },
				title:"Our Visits",
				width:20,
				
			},
			
			legend: {
			  hide: true
			},
			color: {
				  pattern: ['#909fa7', '#967ADC', '#00c5dc', '#5867dd']
			}
		});	
  });
})(jQuery);