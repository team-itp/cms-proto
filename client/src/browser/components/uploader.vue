<!-- src/renderer-process/components/Uploader.vue -->
<template>
  <div class="mdl-list">
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
          <i class="material-icons">work</i>&nbsp;
          <span>書類の種類</span>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
        <label class="mdl-radio mdl-js-radio mdl-js-ripple-effect">
          <input type="radio" class="mdl-radio__button" name="document"> 設計図
        </label>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
        <label class="mdl-radio mdl-js-radio mdl-js-ripple-effect">
          <input type="radio" class="mdl-radio__button" name="document"> 設計図
        </label>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
        <label class="mdl-radio mdl-js-radio mdl-js-ripple-effect">
          <input type="radio" class="mdl-radio__button" name="document"> 設計図
        </label>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
          <i class="material-icons">more</i>&nbsp;
          <span>タグ</span>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
        <div class="mdl-textfield mdl-js-textfield">
          <input class="mdl-textfield__input" type="text" id="sample1">
          <label class="mdl-textfield__label" for="sample1">Text...</label>
        </div>
      </span>
    </div>
    <div class="mdl-list__item">
      <span class="mdl-list__item-primary-content">
        <span class="mdl-chip mdl-chip--deletable">
          <span class="mdl-chip__text">Deletable Chip</span>
          <button type="button" class="mdl-chip__action"><i class="material-icons">cancel</i></button>
        </span>
        <span class="mdl-chip mdl-chip--deletable">
          <span class="mdl-chip__text">Deletable Chip</span>
          <button type="button" class="mdl-chip__action"><i class="material-icons">cancel</i></button>
        </span>
        <span class="mdl-chip mdl-chip--deletable">
          <span class="mdl-chip__text">Deletable Chip</span>
          <button type="button" class="mdl-chip__action"><i class="material-icons">cancel</i></button>
        </span>
      </span>
    </div>
  </div>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";

@Component({})
export default class Uploader extends Vue {}
</script>