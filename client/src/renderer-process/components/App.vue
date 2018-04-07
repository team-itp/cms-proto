<!-- src/renderer-process/components/App.vue -->
<template>
    <!-- Always shows a header, even in smaller screens. -->
    <div class="mdl-layout mdl-js-layout mdl-layout--fixed-header">
        <header class="mdl-layout__header">
            <div class="mdl-layout__header-row">
                <!-- Title -->
                <span class="mdl-layout-title">書類選択</span>
                <!-- Add spacer, to align navigation to the right -->
                <div class="mdl-layout-spacer"></div>
                <!-- Navigation. We hide it in small screens. -->
                <nav class="mdl-navigation">
                    <a class="mdl-navigation__link" @click="toggleFileListView"><i class="material-icons">{{menuViewModeIcon}}</i></a>
                </nav>
            </div>
        </header>
        <main class="mdl-layout__content">
            <div class="page-content">
                <file-list v-bind:view-mode="viewMode"></file-list>
            </div>
        </main>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import FileList from "./FileList.vue";

@Component({
  components: {
    FileList
  }
})
export default class App extends Vue {
  viewMode: 'list' | 'grid' = 'list'

  get menuViewModeIcon() : string {
    return this.viewMode === 'list' ? 'view_module' : 'view_list'
  }

  toggleFileListView() {
    this.viewMode = (this.viewMode === 'list' ? 'grid' : 'list')
  }
}
</script>

<style>
.page-content {
  padding-top: 8px;
}
</style>