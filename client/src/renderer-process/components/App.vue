<!-- src/renderer-process/components/App.vue -->
<template>
  <!-- Always shows a header, even in smaller screens. -->
  <div class="mdl-layout mdl-js-layout mdl-layout--fixed-header mdl-layout--no-desktop-drawer-button">
    <header class="mdl-layout__header">
      <div class="mdl-layout__header-row">
        <!-- Title -->
        <span class="mdl-layout-title">書類選択</span>
        <!-- Add spacer, to align navigation to the right -->
        <div class="mdl-layout-spacer"></div>
        <!-- Navigation. We hide it in small screens. -->
        <nav class="mdl-navigation">
          <a class="mdl-navigation__link" @click="toggleFileListViewMode">
            <i class="material-icons">{{menuFileListViewMode}}</i>
          </a>
        </nav>
      </div>
    </header>
    <main class="mdl-layout__content cms-proto--show-drawer">
      <div class="page-content">
          <file-list v-bind:view-mode="fileListViewMode"></file-list>
      </div>
      <div class="cms-proto__drawer">
          <uploader></uploader>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
  import { Vue, Component } from "vue-property-decorator";
  import FileList from "./FileList.vue";
  import Uploader from "./Uploader.vue";

  @Component({
    components: {
      FileList,
      Uploader
    }
  })
  export default class App extends Vue {
    fileListViewMode: "list" | "grid" = "list";
    isSelectMode: boolean = false
    
    get menuFileListViewMode(): string {
      return this.fileListViewMode === "list" ? "view_module" : "view_list";
    }

    toggleFileListViewMode() {
      this.fileListViewMode = this.fileListViewMode === "list" ? "grid" : "list";
      this.$forceUpdate()
    }

    toggleSelectionMode() {
      this.isSelectMode = !this.isSelectMode
    }
  }
</script>

<style>
  .page-content {
    padding-top: 8px;
  }

  .cms-proto--show-drawer {
    position: relative;
  }
  .cms-proto__drawer {
    width:0;
  }

  .page-content {
    position: absolute;
    left:0;
    right: 0;
    top: 0;
    bottom: 0;
    overflow-y: auto;
  }

  .cms-proto__drawer {
    visibility: hidden;
    position: absolute;
    right: -400px;
    width: 400px;
    top: 0;
    bottom: 0;
    background-color: #efefef;
  }

  .cms-proto--show-drawer .page-content {
    right: 400px;
  }
  .cms-proto--show-drawer .cms-proto__drawer {
    visibility: visible;
    right: 0;
  }
</style>