<!-- src/renderer-process/components/FileList.vue -->
<template>
  <div>
    <div v-if="viewMode === 'grid'">
      <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone" v-for="file in fileList" v-bind:key="file.name">
          <selectable-card v-bind:filename="file.name" v-bind:filepath="file.fullPath"></selectable-card>
        </div>
      </div>
    </div>
    <div v-if="viewMode === 'list'">
      <ul class="demo-list-icon mdl-list">
        <li v-for="file in fileList" v-bind:key="file.name" class="mdl-list__item">
          <span class="mdl-list__item-primary-content">
            <img v-bind:src="file.fullPath" class="mdl-list__item-icon">
            {{ file.name }}
          </span>
        </li>
      </ul>
    </div>
  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'
import SelectableCard from './selectable-card.vue'
import { IFileInfo } from '../../common/files'

@Component({
  components: {
    SelectableCard
  }
})
export default class FileList extends Vue {
  @Prop({
    required: true
  })
  viewMode: "grid" | "list" = "grid";

  get fileList(): IFileInfo[] {
    return [
      {
        name: "FileName1.pdf",
        fullPath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg",
        lastUpdate: new Date()
      },
      {
        name: "FileName1.pdf",
        fullPath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg",
        lastUpdate: new Date()
      },
      {
        name: "FileName1.pdf",
        fullPath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg",
        lastUpdate: new Date()
      },
      {
        name: "FileName1.pdf",
        fullPath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg",
        lastUpdate: new Date()
      }
    ];
  }
}
</script>