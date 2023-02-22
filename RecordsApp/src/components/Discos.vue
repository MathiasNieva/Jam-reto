<template>
  <div :key="disco.discoId" v-for="disco in discos">
    <Disco :disco="disco"/>
  </div>
</template>

<script>
import Disco from './Disco.vue'

export default {
  name: 'Discos',
  props: {
    discos: Array,
  },
  components: {
    Disco,
  }
}
</script>
