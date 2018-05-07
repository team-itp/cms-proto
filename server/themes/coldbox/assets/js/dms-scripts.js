'use strict';

jQuery(function($) {
    const $dmsForm = $('#dms-search-widget-form');
    const $dmsSearchInput = $('#dms-search-input');
    const $dmsSearchInputHidden = $('#dms-search-input-hidden');
    const $dmsCheckbox = $('.dms-checkbox.dms-search');

    let tags  = {};
    let posts = {};

    $dmsSearchInput.autocomplete({
        source: function(request, response) {
            $.ajax({
                url: '/wp-json/wp/v2/tags',
                type: 'GET',
                data: {
                    'search': request.term
                }
            })
            .done(function(data) {
                tags = data;
                const names = data.map( (element) => {
                    return element.name;
                });

                response(names);
            })
            .fail(function(data) {
                response([]);
            });

        }
    });

    $dmsForm.submit(function() {
        if (!$dmsSearchInput.val()) {
            $dmsSearchInputHidden.prop('disabled', true);
        }
    });

    $dmsSearchInput.change(function() {
        const filtered = tags.filter(function(element) {
            return element.name === $dmsSearchInput.val();
        });
        // タグが取得できない場合は入力を消す
        if (!filtered || filtered.length != 1) {
            $dmsSearchInput.val(null);
            $dmsSearchInputHidden.prop('disabled', true);
        } else {
            $dmsSearchInputHidden.val(filtered[0].id);
        }
        $dmsForm.submit();
    });

    $('.dms-tag').click(function(eventData) {
        if (!$dmsSearchInput.val()) {
            $dmsSearchInputHidden.prop('disabled', true);
        }
        eventData.currentTarget.remove();
        $dmsForm.submit();
    });

    $dmsCheckbox.click(function() {
        if (!$dmsSearchInput.val()) {
            $dmsSearchInputHidden.prop('disabled', true);
        }
        $dmsForm.submit();
    });
});
