function MapHelper()
{
    this.Polygon = 1;
    this.Polyline = 2;
    this.Marker = 3;
    this.InfoWindow = 4;

    this.createOverlay = function(type, options)
    {
        switch(type)
        {
            case this.Polygon: return new google.maps.Polygon(options);
            case this.Polyline: return new google.maps.Polyline(options);
            case this.Marker: return new google.maps.Marker(options);
            case this.InfoWindow: return new google.maps.InfoWindow(options);
        }
    }
    this.getMapTypeIdConfig = function (mapType)
    {
        switch (parseInt(mapType))
        {
            case 2: return google.maps.MapTypeId.SATELLITE;
            default: return google.maps.MapTypeId.ROADMAP;
        }
    }
    this.getMapTypeId = function (mapTypeId)
    {
        switch (mapTypeId)
        {
            case google.maps.MapTypeId.SATELLITE: return 2;
            default: return 1;
        }
    }
    this.getMapTypeId2 = function (map) { return this.getMapTypeId(map.getMapTypeId()); };
    this.getLatLng = function (lat, lng) { return new google.maps.LatLng(parseFloat(lat), parseFloat(lng)); }
    this.getPoint = function (x, y) { return new google.maps.Point(x, y); }
    this.bindEvent = function (marker, ev, action) { return google.maps.event.addListener(marker, ev, function (e) { action(e); }); };
    this.getAddress = function(lat,lng, callback)
    {
        var geocoder = new google.maps.Geocoder();
        var latlng = { lat: parseFloat(lat), lng: parseFloat(lng) };

        var findByType = function (components, type) 
        {
            for(var i = 0; i < components.length;i++)
            {
                for(var j = 0; j < components[i].types.length; j++)
                {
                    if (type == components[i].types[j])
                        return components[i].long_name;
                }
            }
            return "";
        };

        var join = function(address, value)
        {
            if (value == "") return address;
            else
            {
                if (address == "") return value;
                else return address = address + ", " + value;
            }
        }

        geocoder.geocode({ 'location': latlng }, function (results, status) 
        {
            if (status === google.maps.GeocoderStatus.OK)
                if (results[0] && callback != null)
                {
                    var address = "";
                    var components = results[0].address_components;
                    var street_number = findByType(components, "street_number"); address = join(address, street_number);
                    var sublocality_level_1 = findByType(components, "sublocality_level_1"); address = join(address, sublocality_level_1);
                    var administrative_area_level_2 = findByType(components, "administrative_area_level_2"); address = join(address, administrative_area_level_2);
                    var administrative_area_level_1 = findByType(components, "administrative_area_level_1"); address = join(address, administrative_area_level_1);
                    var country = findByType(components, "country"); address = join(address, country);
                    callback(address);
                }
        });
    }
    this.inputVal = function(latInput, lngInput, latlng)
    {
        latInput.val(latlng.lat());
        lngInput.val(latlng.lng());
    }

    this.new = function (container, loadConfig, afterInit)
    { 
        var mapper = new ViMapControl(); 
        mapper.elementCanvas = container[0];
        mapper.init(loadConfig, afterInit);
        return mapper;
    };

    this.setPosition = function(marker, lat, lng, panto)
    {
        var position = this.getLatLng(lat, lng);
        this.setPosition2(marker, position, panto);
    }
    this.setPosition2 = function(marker, position, panto)
    {
        marker.setPosition(position);
        if (panto == true)
            marker.getMap().panTo(position);
    }
    this.panTo = function(marker)
    {
        marker.getMap().panTo(marker.getPosition());
    }
    this.trigger = function(marker, event)
    {
        new google.maps.event.trigger(marker, event);
    }
}

var Mapper = new MapHelper();

function ViMapControl()
{
    this.elementCanvas = 'map-canvas';
    this.map = null;
    this.configMap = null;
    this.layers = {};

    this.init = function (loadConfig, afterInit)
    {
        var $this = this;

        // Load Config
        $this.configMap = { Latitude: 20.922699, Longitude: 105.833162, MapType: 1, MapZoom: 12 };

        // option cho map
        var options =
        {
            center: Mapper.getLatLng($this.configMap.Latitude, $this.configMap.Longitude),
            disableDefaultUI: true,
            zoom: $this.configMap.MapZoom,
            minZoom: 2, maxZoom: 20,
            mapTypeId: Mapper.getMapTypeIdConfig($this.configMap.MapType),
            streetViewControl: false,
            mapTypeControl: true,
            mapTypeControlOptions:
            {
                mapTypeIds: [google.maps.MapTypeId.ROADMAP, google.maps.MapTypeId.SATELLITE],
                style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
                position: google.maps.ControlPosition.TOP_RIGHT
            },
            zoomControl: true,
            zoomControlOptions:
            {
                style: google.maps.ZoomControlStyle.LARGE,
                position: google.maps.ControlPosition.RIGHT_TOP
            },
            panControl: true,
            panControlOptions: { position: google.maps.ControlPosition.RIGHT_TOP },
            scaleControl: true,
            scaleControlOptions: { position: google.maps.ControlPosition.BOTTOM_RIGHT }
        }

        // 
        var elementMap = typeof ($this.elementCanvas) == "string" ? document.getElementById($this.elementCanvas) : $this.elementCanvas;

        var funcLoadMap = function()
        {
            $this.map = new google.maps.Map(elementMap, options);
            google.maps.event.addListenerOnce($this.map, 'idle', function () { if (afterInit != null) setTimeout(function () { afterInit(); }, 100); });
        }

        if (!loadConfig) funcLoadMap();
        
        else
        {
            var ajax = new CoreAjax();
            ajax.typeAction = "Main";
            ajax.post("LoadMapConfig", {}, function (res)
            {
                if (res.Data.MapConfig.MapCenterLat != 0 && res.Data.MapConfig.MapCenterLng != 0)
                    options.center = Mapper.getLatLng(res.Data.MapConfig.MapCenterLat, res.Data.MapConfig.MapCenterLng);

                if (res.Data.MapConfig.MapZoom != 0) options.zoom = res.Data.MapConfig.MapZoom;
                if (res.Data.MapConfig.MapTypeId != 0) options.mapTypeId = Mapper.getMapTypeIdConfig(res.Data.MapConfig.MapTypeId);

                funcLoadMap();
            });
        }
    }

    this.getCenter = function () { return this.map.getCenter(); }
    this.panTo = function (position) { this.map.panTo(position); }
    this.panToMarker = function (marker) { this.panTo(marker.getPosition()); };
    this.setAnimationBounce = function(marker, timeout)
    {
        marker.setAnimation(google.maps.Animation.BOUNCE);
        setTimeout(function () { marker.setAnimation(null); }, timeout);
    }

    this.onLayerOrCreate = function(layerName, action)
    {
        if (layerName == null || layerName == "") layerName = "All_All_All";
        var layer = this.layers[layerName];
        if (layer == null) this.layers[layerName] = layer = [];
        return action(layer);
    }
    this.onLayer = function(layerName, action)
    {
        var layer = this.layers[layerName];
        if (layer != null) action(layer);
    }
    this.visibleLayer = function(layerName, show)
    {
        var $this = this;
        this.onLayer(layerName, function (layer)
        {
            Enumerable.From(layer).ForEach(function (overlay) { overlay.setMap(show ? $this.map : null); });
        });
    }
    this.deleteLayer = function(layerName)
    {
        this.visibleLayer(layerName, false);
        this.onLayer(layerName, function (layer) { layer = []; });
    }
    this.createOverlay = function(type, options, layerName)
    {
        var $this = this;
        return this.onLayerOrCreate(layerName, function (layer)
        {
            var overlay = Mapper.createOverlay(type, options);
            overlay.setMap($this.map);
            layer.push(overlay);
            return overlay;
        });
    }

    // Tạo marker
    this.createMarker = function (options, layerName) { return this.createOverlay(Mapper.Marker, options, layerName); };
    this.createInfoWindow = function (options, layerName) { return this.createOverlay(Mapper.InfoWindow, options, layerName); };
    this.getMapTypeId = function () { return Mapper.getMapTypeId2(this.map); }
    this.getZoom = function () { return this.map.getZoom(); };
    this.openInfoWindow = function(infoWindow, content, marker)
    {
        infoWindow.setContent(content);
        infoWindow.open(this.map, marker);
    }
}

// Popup chọn điểm
function PopupPickerLatLng()
{
    $.extend(this, new Popup());
    this.dialogType = "modal-lg";
    this.title = "Chọn điểm";
    this.content = "<div class='row'><div class='col-xs-12' style='height:400px'><div id='map-canvas-popup' class='core-map'></div></div></div>";

    var marker = null;

    this.buttons.push({
        value: "Chọn", cls: "btn btn-primary pull-left", func: function (element, scope)
        {
            if (scope.receiveLatlng != null)
                scope.receiveLatlng(marker.getPosition().lat(), marker.getPosition().lng());
            scope.hide();
        }});

    this.loadContentWhenShow = true;
    this.clearWhenHide = true;

    var mapper = null;

    this.lat = 0;
    this.lng = 0;

    this.onAlwaysShow = function()
    {
        var $this = this;

        var inputAddress = $("<input type='text' class='form-control' placeholder='"+ Core.getLabel("Nhập địa chỉ để tìm vị trí") +"' />");
        $this.header.append(inputAddress);
        mapper = Mapper.new(this.popupBody.find('#map-canvas-popup'), true, function()
        {
            mapper.map.setZoom(17);

            marker = mapper.createMarker({ draggable : true }, "PopupPickerLatLng");
            if ($this.lat != 0 && $this.lng != 0) 
            {
                Mapper.setPosition(marker, $this.lat, $this.lng, true);
                Mapper.getAddress(marker.getPosition().lat(), marker.getPosition().lng(), function (address) { inputAddress.val(address); });
            }
            else marker.setPosition(mapper.getCenter());

            Mapper.bindEvent(mapper.map, "click", function (e) { Mapper.setPosition2(marker, e.latLng); });
            Mapper.bindEvent(marker, "dragend", function () { Mapper.getAddress(marker.getPosition().lat(), marker.getPosition().lng(), function (address) { inputAddress.val(address); }); });

            var autocomplete = new google.maps.places.Autocomplete(inputAddress[0]);
            autocomplete.bindTo('bounds', mapper.map);
            autocomplete.setTypes(['address']);

            autocomplete.addListener('place_changed', function () 
            {
                var place = autocomplete.getPlace();
                if (!place.geometry) 
                {
                    Core.alert("Không tìm thấy địa chỉ");
                    return;
                }
           
                if (place.geometry.viewport) 
                {
                    mapper.map.fitBounds(place.geometry.viewport);
                } 
                else 
                {
                    mapper.map.setCenter(place.geometry.location);
                    mapper.map.setZoom(17);
                    marker.setPosition(place.geometry.location);
                }

                //var address = '';
                //if (place.address_components) {
                //  address = [
                //    (place.address_components[0] && place.address_components[0].short_name || ''),
                //    (place.address_components[1] && place.address_components[1].short_name || ''),
                //    (place.address_components[2] && place.address_components[2].short_name || '')
                //  ].join(' ');
                //}
            });
        });
    }

    this.receiveLatlng = null;
}