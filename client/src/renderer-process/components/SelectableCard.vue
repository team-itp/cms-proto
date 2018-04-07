<!-- src/renderer-process/components/SelectableCard.vue -->
<template>
  <div v-on:click="toggle" class="demo-card-image mdl-card mdl-shadow--2dp">
    <div class="mdl-card__title mdl-card--expand"></div>
    <div class="mdl-card__actions">
      <span class="demo-card-image__filename">Filename.pdf</span>
    </div>
  </div>
</template>

<script lang="ts">
  import { Vue, Component, Prop } from "vue-property-decorator";

  @Component
  export default class SelectableCard extends Vue {
    @Prop() selected: boolean = false;

    select() {
      this.selected = true;
    }
    deselect() {
      this.selected = false;
    }
    toggle() {
      this.selected = !this.selected;
      console.log(this.selected);
    }
  }
</script>

<style>
  .demo-card-image.mdl-card {
    width: 100%;
    height: 256px;
  }

  .demo-card-image>.mdl-card__actions {
    height: 52px;
    padding: 16px;
    background: rgba(0, 0, 0, 0.2);
  }

  .demo-card-image__filename {
    color: #fff;
    font-size: 14px;
    font-weight: 500;
  }
</style>