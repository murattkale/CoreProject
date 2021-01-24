if (window.addEventListener) {
    window.addEventListener('load', general_Load, false);
}
else {
    window.attachEvent('onload', general_Load);
}

var ContentType =
{
    Blog: 1,
    Message: 2,
    Tanimlar: 3,
    Slider: 4,
    SSS: 5,
    Dokumanlar: 6,
}



var Level = {
    AnaKategori: 1,
    AltKategori: 2,
    Etiket: 3,
};



var ContentPageTypeEnum = {
    None: 77,
    Slider: 99,
    Liste: 1,
    ListeYatay: 88,
    Sayfa: 2,
    Kilavuzlar: 3,
    SSS: 4,
};


const FikirDurumu = {
    Ondegerlendirme: 1,
    Degerlendirme: 2,
    Tamamlandi: 5,
    Beklemede: 4,
    GeriAtandi: 3,
};

const AtamaStatus = {
    Havuzda: 1,
    Atandi: 2,
    Red: 3,
    Pasif: 4,
};

const KapanmaStatu = {
    BuBirOneriDegil: 1,
    OncedenPlanlanmis: 2,
    UygulanabilirDegil: 3,
    Mevcut: 4,
    Uygulanabilir: 5,
};


const ProjeStatu = {
    ProjeDegerlendirmede: 1,
    Projelendiriliyor: 2,
    iptalEdildi: 3,
    HayataGecti: 4,
}


function setCatColor(divid) {
    var divtext = $(divid);
    var value = divtext.text();
    if (divtext.text() == "") {
        value = divtext.val();
    }

    if (value == "") {
        value = divtext.attr("data");
    }

    if (value.indexOf('HİZMET') != -1) {
        divtext.css('color', 'rgb(46, 20, 225)');
    }
    else if (value.indexOf('ÇALIŞAN') != -1) {
        divtext.css('color', ' rgb(225, 126, 20)');
    }
    else if (value.indexOf('YENİ') != -1) {
        divtext.css('color', 'rgb(183, 20, 225)');
    }
    else {
        divtext.css('color', '#65646b');
    }
}





function getAtamaStatusColor(str_atamastatus) {


    value = str_atamastatus;
    switch (value) {

        case AtamaStatus.Havuzda: {
            value = ' background:#ffb822;color:white; ';
            break;
        }
        case AtamaStatus.Atandi: {
            value = ' background:#1dc9b7;color:white; ';
            break;
        }
        case AtamaStatus.Red: {
            value = ' background:#841e3f;color:white; ';
            break;
        }
        case AtamaStatus.Pasif: {
            value = ' background:#6c757d;color:white; ';
            break;
        }
        default:
            {
                break;
            }
    }
    return value;
}



function old_getAtamaStatusColor(AtamaStatusEnum) {
    var atamastatusColor = "";
    switch (AtamaStatusEnum) {

        case AtamaStatus.Havuzda: {
            atamastatusColor = 'warning';
            break;
        }
        case FikirDurumu.Atandi: {
            atamastatusColor = 'success';
            break;
        }
        case FikirDurumu.Red: {
            atamastatusColor = 'light-gray';
            break;
        }
        case FikirDurumu.Pasif: {
            atamastatusColor = 'gray';
            break;
        }
        default:
            {
                atamastatusColor = 'primary';
                break;
            }
    }

    return atamastatusColor;

}


function getFikirStatusColor(FikirStatusEnum) {
    var type = "";
    switch (FikirStatusEnum) {

        case FikirDurumu.GeriAtandi: {
            type = 'info';
            break;
        }
        case FikirDurumu.Beklemede: {
            type = 'success';
            break;
        }
        case FikirDurumu.Tamamlandi: {
            type = 'danger';
            break;
        }
        case FikirDurumu.Ondegerlendirme: {
            type = 'warning';
            break;
        }
        default:
            {
                type = 'primary';
                break;
            }
    }

    return type;

}



function general_Load() {
    window.onbeforeunload = setClick;
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


var postArray = [];
function setClick() {
    for (var i = 0; i < postArray.length; i++) {
        postArray[i].abort();
    }
    // cl();
}


var toStr = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? "" : e.toString();
};

var toInt = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? null : parseInt(e);
};



var toDouble = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? null : parseFloat(e);
};

var isBool = function (variable) {
    if (typeof (variable) === "boolean") {
        return true;
    }
    else {
        return false;
    }
}

var toBool = function (value) {
    return value == true ? "True" : "False";
}

var isNumeric = function (n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

jQuery('.isnumeric').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});


function getObjects(obj, key, val) {
    var objects = [];
    for (var i in obj) {
        if (!obj.hasOwnProperty(i)) continue;
        if (typeof obj[i] == 'object') {
            objects = objects.concat(getObjects(obj[i], key, val));
        } else
            if (i == key && obj[i] == val || i == key && val == '') { //
                objects.push(obj);
            } else if (obj[i] == val && key == '') {
                if (objects.lastIndexOf(obj) == -1) {
                    objects.push(obj);
                }
            }
    }
    return objects;
}



function getEnumList(dataResult, id, selectid, selectText) {
    $(id).addOption(dataResult, "value", "text", null, null, selectid, '', selectText);
}

function getEnumRow(dataResult, value) {
    if (value < 1) {
        row = { value: "", text: "", name: "" };
        return row;
    }
    var row;
    for (var i = 0; i < dataResult.length; i++) {
        var rowItem = dataResult[i];
        if (parseInt(rowItem.value) == parseInt(value)) {
            row = rowItem;
            break;
        }
    }
    return row;
}

function getEnumRowName(dataResult, value) {
    if (value < 1) {
        row = { value: "", text: "", name: "" };
        return row;
    }
    var row;
    for (var i = 0; i < dataResult.length; i++) {
        var rowItem = dataResult[i];
        if (rowItem.name == value) {
            row = rowItem;
            break;
        }
    }
    return row;
}




(function ($) {
    $.fn.ceo = function (ayarlar) {
        var ayar = $.extend({
            'source': "#" + $(this)[0].name,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            str = replaceSpecialChars(str);
            str = str.toLowerCase();
            str = str.replace(/\s\s+/g, ' ').replace(/[^a-z0-9\s]/gi, '').replace(/[^\w]/ig, "-");
            function replaceSpecialChars(str) {
                var specialChars = [["ş", "s"], ["ğ", "g"], ["ü", "u"], ["ı", "i"], ["_", "-"],
                ["ö", "o"], ["Ş", "S"], ["Ğ", "G"], ["Ç", "C"], ["ç", "c"],
                ["Ü", "U"], ["İ", "I"], ["Ö", "O"], ["ş", "s"]];
                for (var i = 0; i < specialChars.length; i++) {
                    str = str.replace(eval("/" + specialChars[i][0] + "/ig"), specialChars[i][1]);
                }
                return str;
            }
            $(ayar.target).val(str);
        });
    };

})(jQuery);

(function ($) {
    $.fn.dup = function (ayarlar) {
        var ayar = $.extend({
            'source': "#" + $(this)[0].name,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            $(ayar.target).val(str);
        });
    };

})(jQuery);


function alerts(message, button, call) {
    var but = [];
    if (button == "yesno") {
        but = {
            confirm: {
                label: "Evet",
                className: 'btn-success'
            },
            cancel: {
                label: "Hayır",
                className: 'btn-danger'
            }
        };
    }
    else if (button == "ok") {
        but = {
            confirm: {
                label: "Tamam",
                className: 'btn-success'
            }
        };
    }

    if (call) {
        bootbox.confirm({
            message: message,
            buttons: but,
            callback: call,
        });
    }
    else {
        bootbox.alert(message);
    }

}


(function ($) {
    "use strict";



    var postArray = [];
    $.ajx = function (url, data, successMethod, error) {
        //if (typeof data != "string" && data != null) {
        //    data = JSON.stringify(data);
        //}
        var slash = url.substr(0, 1) == "/" ? "" : "/";

        var post = $.post(slash + url, data, successMethod)
            .fail(function (e, exception) {
                if (error) {
                    var errorResult = $.errorSend(e, exception);
                    console.log(exception);
                }
            });
        postArray.push(post);
    };

    $.ajxUpload = function (url, data, successMethod, error) {
        //if (typeof data != "string" && data != null) {
        //    data = JSON.stringify(data);
        //}
        var slash = url.substr(0, 1) == "/" ? "" : "/";

        $.ajax({
            url: slash + url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: data,
            success: successMethod,
            error: function (e, exception) {
                if (error) {
                    var errorResult = $.errorSend(e, exception);
                    console.log(errorResult);
                }
            }
        });

    };

    $.errorSend = function (e, exception) {
        var error = '';
        if (e.status === 0) {
            error = 'Not connect. Verify Network.';
        } else if (e.status === 404) {
            error = 'Requested page not found. [404]';
        } else if (e.status === 500) {
            error = 'Internal Server Error [500].';
        } else if (exception === 'parsererror') {
            error = 'Requested JSON parse failed.';
        } else if (exception === 'timeout') {
            error = 'Time out error.';
        } else if (exception === 'abort') {
            error = 'Ajax request aborted.';
        } else {
            error = 'Uncaught Error. \n' + error.responseText;
        }
        var data = { error: error };

        return error;
    };

    $.fn.addOption = function (selectValues, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName) {
        var id = this;
        $(id).html('');

        if (selectDefault) {
            var optionsAll = $("<option></option>")
                .attr("value", '')
                .text(selectDefault);
            $(id).append(optionsAll);
        }

        $.each(selectValues, function (i, item) {

            var splitText = text.split(',');
            var textValue = "";
            for (var ii = 0; ii < splitText.length; ii++)
                textValue += item[splitText[ii]] + (ii >= 0 ? ' ' : '');

            var ustkategori = "";
            try {
                ustkategori = item.Parent.text + ' / ';
            } catch (e) {

            }

            var optionsAll = $("<option></option>")
                .attr("value", item[value])
                .text(ustkategori + textValue);

            if (attrName)
                $(optionsAll)
                    .attr(attrName, item[attrName]);

            if (selectValue != null && value != '' && value != undefined && selectValue.toString() == item[value].toString()) {
                $(optionsAll).attr('selected', "selected");
            }
            if (selectText != null && text != '' && text != undefined && selectText == item[text]) {
                $(optionsAll).attr('selected', "selected");
            }



            $(id).append(optionsAll);

        });



        if (dpChange != null) {
            $(document).on('change', id, function (e) { dpChange(e.target); });
        }

        if (dpSuccess != null) {
            dpSuccess(id);
            //$(document).on('', id, function (e) { dpSuccess(e.target); });
        }

        //try {
        //    $(id).select2({});
        //} catch (e) {
        //    console.log(e);
        //}

    };

    $.fn.addOptionAjax = function (url, param, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName) {
        var id = this;
        $(id).LoadingOverlay("show");
        $(id).html('');

        var slash = url.substr(0, 1) == "/" ? "" : "/";

        $.ajx(slash + url, param, function (dataResult) {
            $(id).addOption(dataResult, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName);
            $(id).LoadingOverlay("hide");
        }, null);

    };


    $.fn.toForm = function (id) {//serialize data function

        var formArray = $(id).serializeArray();
        var returnArray = {};

        for (var i = 0; i < formArray.length; i++) {
            var finame = (formArray[i]['name']).toString();
            var fivalue = (formArray[i]['value']).toString();
            if (finame.indexOf("Id") != -1 && fivalue == "-1") {
                returnArray[formArray[i]['name']] = null;
            }
            else {
                returnArray[formArray[i]['name']] = fivalue.trim();
            }
        }
        $(id + ' select[disabled],' + id + ' select').each(function () {
            var dp = $(this).attr('name');
            try {
                if (dp.indexOf('dp_') != -1) {
                    dp = dp.substr(3, dp.length - 1);
                }
            } catch (e) {
                console.log('select error: ' + e);
            }


            returnArray[dp] = $(this).val();

            try {
                if (dp.indexOf('Id') != -1 && ($(this).val() == "-1" || $(this).val() == "0" || $(this).val() == "")) {
                    returnArray[dp] = null;
                }
            } catch (e) {
                console.log(e);
            }


            delete returnArray[$(this).attr('name')];

        });
        $(id + ' input[disabled]').each(function () {
            returnArray[$(this).attr('name')] = $(this).val().trim();
        });

        $(id + ' textarea').each(function () {
            try {
                returnArray[$(this).attr('name')] = $(this).val();

            } catch (e) {
                console.error(e);
            }

        });


        $(id + ' input[type="checkbox"]').each(function () {
            returnArray[$(this).attr('name')] = $(this).prop("checked");
        });

        return returnArray;
    };

    $.getAttrs = function (attrName) {
        var data = this;
        var attrValues = [];
        $.each(data, function (i, item) {
            attrValues.push({ id: $(item).attr(attrName) });
        });
        return attrValues;
    };


})(jQuery);