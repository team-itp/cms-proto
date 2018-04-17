<!-- src/renderer-process/components/FileList.vue -->
<template>
  <div>
    <div v-if="viewMode === 'grid'">
      <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--4-col mdl-cell--12-col-phone" v-for="file in fileList" v-bind:key="file.filename">
          <selectable-card v-bind:filename="file.filename" v-bind:filepath="file.filepath"></selectable-card>
        </div>
      </div>
    </div>
    <div v-if="viewMode === 'list'">
      <ul class="demo-list-icon mdl-list">
        <li v-for="file in fileList" v-bind:key="file.filename" class="mdl-list__item">
          <span class="mdl-list__item-primary-content">
            <img v-bind:src="file.filepath" class="mdl-list__item-icon">
            {{ file.filename }}
          </span>
        </li>
      </ul>
    </div>
  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import SelectableCard from "./selectable-card.vue";

interface FileInfo {
  filename: string;
  filepath: string;
}

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

  get fileList(): FileInfo[] {
    return [
      {
        filename: "FileName1.pdf",
        filepath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg"
      },
      {
        filename: "FileName1.pdf",
        filepath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg"
      },
      {
        filename: "FileName1.pdf",
        filepath: "http://www.elonka.com/kryptos/sanborn/KGBCyrillic.jpg"
      }
    ];
  }
}
</script>