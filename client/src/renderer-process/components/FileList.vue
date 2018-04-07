<!-- src/renderer-process/components/FileList.vue -->
<template>
  <div>
    <div v-if="viewMode === 'grid'">
      <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone">
          <selectable-card></selectable-card>
        </div>
      </div>
    </div>
    <div v-if="viewMode === 'list'">
      <ul class="demo-list-icon mdl-list">
        <li class="mdl-list__item">
          <span class="mdl-list__item-primary-content">
            <i class="material-icons mdl-list__item-icon">person</i>
            Bryan Cranston
          </span>
        </li>
        <li class="mdl-list__item">
          <span class="mdl-list__item-primary-content">
            <i class="material-icons mdl-list__item-icon">person</i>
            Aaron Paul
          </span>
        </li>
        <li class="mdl-list__item">
          <span class="mdl-list__item-primary-content">
            <i class="material-icons mdl-list__item-icon">person</i>
            Bob Odenkirk
          </span>
        </li>
      </ul>
    </div>
  </div>
</template>
<script lang="ts">
  import { Vue, Component, Prop } from "vue-property-decorator";
  import SelectableCard from "./SelectableCard.vue";

  @Component({
    components: {
      SelectableCard
    }
  })
  export default class FileList extends Vue {
    @Prop({
      required: true
    })
    viewMode: "grid" | "list" = "list";
  }
</script>