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
                    <a class="mdl-navigation__link" href=""><i class="material-icons">list</i></a>
                </nav>
            </div>
        </header>
        <main class="mdl-layout__content">
            <div class="page-content">
                
            </div>
        </main>
    </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";

@Component
export default class HelloDecorator extends Vue {
  @Prop() name: string = "";
  @Prop() initialEnthusiasm: number = 0;

  enthusiasm = this.initialEnthusiasm;

  increment() {
    this.enthusiasm++;
  }
  decrement() {
    if (this.enthusiasm > 1) {
      this.enthusiasm--;
    }
  }

  get exclamationMarks(): string {
    return Array(this.enthusiasm + 1).join("!");
  }
}
</script>

<style>
.greeting {
  font-size: 20px;
}
</style>