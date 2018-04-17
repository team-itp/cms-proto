<!-- src/renderer-process/components/SelectableCard.vue -->
<template>
  <div v-on:click.right="select" class="demo-card-image mdl-card mdl-shadow--2dp"  v-bind:style="{ backgroundImage: 'url(' + filepath + ')' }" ref="card">
    <div class="mdl-card__title mdl-card--expand"></div>
    <div class="mdl-card__actions">
      <span class="demo-card-image__filename">{{filename}}</span>
    </div>
  </div>
</template>

<script lang="ts">
  import { Vue, Component, Prop } from "vue-property-decorator";

  @Component
  export default class SelectableCard extends Vue {
    @Prop() selected: boolean = false;
    @Prop() filename?: string
    @Prop() filepath?: string

    select() {
      this.selected = true;
      console.log(<any>this.$refs.card)
    }
    deselect() {
      this.selected = false;
    }
    toggle() {
      this.selected = !this.selected;
      (<any>this.$refs.card).$el.style.border = 'blue solid 2px'
      console.log(this.selected);
    }
  }
</script>

<style>
  .demo-card-image.mdl-card {
    width: 100%;
    height: 256px;
    background-size:     contain;
    background-repeat:   no-repeat;
    background-position: center center;
  }

  .demo-card-image>.mdl-card__actions {
    height: 52px;
    padding: 16px;
    background: rgba(0, 0, 0, 0.4);
  }

  .demo-card-image__filename {
    color: #fff;
    font-size: 14px;
    font-weight: 500;
  }
</style>