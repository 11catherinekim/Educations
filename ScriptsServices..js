if (!datalus.services.educations) {
    datalus.services.educations = {};
}

datalus.services.educations.createNewEducation = function (formData, onSuccess, onError) {
    var url = "/api/educations/";
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
         , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

datalus.services.educations.updateEducation = function (valueId, formData, onSuccess, onError) {
    var url = "/api/educations/" + valueId;
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
         , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };
    $.ajax(url, settings);
}

datalus.services.educations.getEducationById = function (IdValue, onSuccess, onError) {
    var url = "/api/educations/" + IdValue;
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}

datalus.services.educations.onDeleteEducation = function (IdValue, onSuccess, onError) {
    var url = "/api/educations/" + IdValue;
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "DELETE"
    };
    $.ajax(url, settings);
}

datalus.services.educations.getAllEducations = function (onSuccess, onError) {
    var url = "/api/educations/";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}
