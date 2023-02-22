<template>
  <div class="disco-wrapper">
    <div class="disco">
      <h2>
        {{ disco.nombre }}
      </h2>
      <p>Lanzado el año {{ disco.año }}</p>
    </div>
    <div class="artists">
      <h4>Artista/s</h4>
      <div :key="artist.artistId" v-for="artist in disco.discoArtists">
        <p>{{ artist.nombre }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Disco',
  props: {
    disco: Object,
  },
}
</script>

<style scope>
.disco-wrapper {
  background: #f4f4f4;
  margin: 5px;
  padding: 10px 20px;
  display: flex;
  
}

.disco {
  align-items: flex-start;
  flex: 1;
  max-width: 180px;
}

h4 {
  display: flex;
  color: #969090;
}

.artists {
  display: flex;
  flex-direction: column;
  justify-content:  flex-start;
  align-items: right;
  margin-left: 50px;
}
</style>
