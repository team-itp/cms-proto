<!-- src/renderer-process/components/App.vue -->
<!-- This is an alternative way to define the Hello component using decorators -->
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
                    <a class="mdl-navigation__link" href=""><i class="material-icons">view_list</i></a>
                </nav>
            </div>
        </header>
        <main class="mdl-layout__content">
            <div class="page-content">
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
        </main>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SelectableCard from './SelectableCard.vue'

@Component({
  components: {
    SelectableCard
  }
})
export default class App extends Vue {
}
</script>

<style>
.page-content {
  padding-top: 8px;
}
</style>