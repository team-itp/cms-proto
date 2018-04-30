'use strict';

jQuery(function ($) {
  const $dms_form = $('#dms-search-widget-form');
  const $dms_tagList = $('.tagchecklist');
  const $dms_searchInput = $('.search-inner.dms-search');
  const $dms_searchSubmit = $('.search-submit.dms-search');

  let tags = {};

  $dms_searchInput.autocomplete({
      source: (request, response) => {
          $.ajax({
              url: '/wp-json/wp/v2/tags',
              type: 'GET',
              data: {
                  'search': request.term
              }
          })
          .done( (data) => {
              tags = data;
              const displayNames = data.map( (element) => {
                  return element.name;
              });

              response(displayNames);
          })
          .fail( (data) => {
              response([]);
          });

      }
  });

  $dms_searchInput.change(function () {
      const filtered = tags.filter( (element) => {
          return element.name == $dms_searchInput.val();
      });
      if (!filtered) { // 該当なし
          $dms_searchInput.val(null);
      } else if (filtered.length != 1) {
          $dms_searchInput.val(null);
      }
  });

  $dms_searchSubmit.click(function () {
      if (!$dms_searchInput.val()) {
          $dms_searchInput.prop('disabled', true);
      } else {
        const filtered = tags.filter( (element) => {
            return element.name == $dms_searchInput.val();
        });
        $dms_searchInput.val(filtered[0].slug);
      }
      $dms_form.submit();
  });

  $('.dms-tag').click(function () {
      this.remove();
      if (!$dms_searchInput.val()) {
          $dms_searchInput.prop('disabled', true);
      }
      $dms_form.submit();
  });
});
