

$(document).ready(function () {
    

    //MODAL
    $("a[data-modal=editor]").on("click", function () {
        $("#editModalContent").load(this.href, function () {
            $("#editModal").modal({ keyboard: true }, "show");

        });
        return false;
    });

    $("a[data-modal=assigner]").on("click", function () {
        $("#assignModalContent").load(this.href, function () {
            $("#assignModal").modal({ keyboard: true }, "show");

        });
        return false;
    });

    $("a[data-modal=complete]").on("click", function () {
        $("#completeModalContent").load(this.href, function () {
            $("#completeModal").modal({ keyboard: true }, "show");

        });
        return false;
    });

    $("a[data-modal=event]").on("click", function () {
        $("#eventModalContent").load(this.href, function () {
            $("#eventModal").modal({ keyboard: true }, "show");
        });
        return false;
    });


    //CHECKBOX BUTTON
    $('#spnCheck').on('click', function () {
        if ($('#ckCheck').hasClass('fa fa-square-o')) {
            $('#ckCheck').removeClass('fa fa-square-o').addClass('fa fa-check-square-o');
        } else {
            $('#ckCheck').removeClass('fa fa-check-square-o').addClass('fa fa-square-o');
        }

    });

    $('.button-checkbox').each(function () {
        var $widget = $(this),
            $button = $widget.find('#btnCheck'),
            $checkbox = $widget.find('input:checkbox'),
            color = $button.data('color'),
            settings = {
                on: {
                    icon: 'glyphicon glyphicon-check'
                },
                off: {
                    icon: 'glyphicon glyphicon-unchecked'
                }
            };

        $button.on('click', function () {
            $checkbox.prop('checked', !$checkbox.is(':checked'));
            $checkbox.triggerHandler('change');
            updateDisplay();
        });

        $checkbox.on('change', function () {
            updateDisplay();
        });

        function updateDisplay() {
            var isChecked = $checkbox.is(':checked');

            $button.data('state', (isChecked) ? "on" : "off");

            $button.find('.state-icon')
                .removeClass()
                .addClass('state-icon' + settings[$button.data('state')].icon);

            if (isChecked) {
                $button.removeClass('btn-default')
                        .addClass('btn-' + color + ' active');
            }
            else {
                $button.removeClass('btn-' + color + ' active')
                .addClass('btn-default');
            }
        }
        function init() {
            updateDisplay();
            if ($button.find('.state-icon').length == 0) {
                $button.append('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i>.');
            }
        }
        init();
    });

    //CONTENT
    $('.toggle').click(function () {
        // Switches the Icon
        $(this).children('i').toggleClass('fa-pencil');
        // Switches the forms  
        $('.form').animate({
            height: "toggle",
            'padding-top': 'toggle',
            'padding-bottom': 'toggle',
            opacity: "toggle"
        }, "slow");
    });


    //AUTOCOMPLETES
    $("#Artist").autocomplete({

        minLength: 1,
        source: function (request, response) {
            var url = $(this.element).data("url");
            $.getJSON(url, { term: request.term }, function (data) {
                response(data);
            });
        },
        appendTo: $("#auto"),
        select: function (event, ui) {

        },
        change: function (event, ui) {
            if (!ui.item) {
                $(event.target).val("");
            }
        }
    });



    $("#Name").autocomplete({
        minLength: 1,
        source: function (request, response) {
            var url = $(this.element).data("url");
            $.getJSON(url, { term: request.term }, function (data) {
                response(data);
            });
        },
        appendTo: $("#car"),
        select: function (event, ui) {

            //$("#Highway").val(ui.item.Highway);
            //$("#City").val(ui.item.City);
            //$("#Combined").val(ui.item.Combined);
            //$("#Cylinders").val(ui.item.Cylinders);
            //$("#Displacement").val(ui.item.Displacement);
            //$("#Manufacturer").val(ui.item.Manufacturer);
            //$("#Cost").val(ui.item.Cost);
            //$("#Year").val(ui.item.Year);
        },
        change: function (event, ui) {
            if (!ui.item) {
                $(event.target).val("");
            }
        }
    });


    //Search

    $('.panel-heading span.clickable').click(function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body').slideUp();
            $this.addClass('panel-collapsed');
            $this.addClass('panel-collapsed');
            $this.find('i').removeClass('fa fa-arrow-up fa-lg').addClass('fa fa-arrow-down fa-lg');
        } else {
            $this.parents('.panel').find('.panel-body').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('i').removeClass('fa fa-arrow-down fa-lg').addClass('fa fa-arrow-up fa-lg');
        }
    });

    //SCOLL
    $('a.page-scroll').bind('click', function (event) {
        var $ele = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($ele.attr('href')).offset().top - 60)
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });


    $.fn.extend({
        filterTable: function () {
            return this.each(function () {
                $(this).on('keyup', function (e) {
                    $('.filterTable_no_results').remove();
                    var $this = $(this),
                        search = $this.val().toLowerCase(),
                        target = $this.attr('data-filters'),
                        $target = $(target),
                        $rows = $target.find('tbody tr');

                    if (search == '') {
                        $rows.show();
                    } else {
                        $rows.each(function () {
                            var $this = $(this);
                            $this.text().toLowerCase().indexOf(search) === -1 ? $this.hide() : $this.show();
                        })
                        if ($target.find('tbody tr:visible').size() === 0) {
                            var col_count = $target.find('tr').first().find('td').size();
                            var no_results = $('<tr class="filterTable_no_results"><td colspan="' + col_count + '">No results found</td></tr>')
                            $target.find('tbody').append(no_results);
                        }
                    }
                });
            });
        }
    })
    $('[data-action="filter"]').filterTable();
});



