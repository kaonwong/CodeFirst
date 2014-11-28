$.validator.unobtrusive.adapters.add('datecompare', ["comparetopropertyname"], function (options) {
    options.rules["datecompare"] = "#" + options.params.comparetopropertyname;
    if (options.messages) {
        options.messages['datecompare'] = options.message;
    }
});

$.validator.addMethod('datecompare', function (value, element, params) {
    var baseDate = value;
    var compareDate = $(params).val();
    if (baseDate == undefined || baseDate == null || baseDate.length == 0 || compareDate == undefined || compareDate == null || compareDate.length == 0) return true;
    var val1 = (isNaN(baseDate) ? Date.parse(baseDate) : eval(baseDate));
    var val2 = (isNaN(compareDate) ? Date.parse(compareDate) : eval(compareDate));
    return val1 > val2;
});