<template>
  <AddDisco :artists="artists" v-show="showAddDisco" @add-disco="addDisco" />
  <Discos :discos="discos" />
</template>

<script>
import Discos from '../components/Discos.vue'
import AddDisco from '../components/AddDisco.vue'
export default {
  name: 'Home',
  props: {
    showAddDisco: Boolean,
  },
  components: {
    Discos,
    AddDisco,
  },
  data() {
    return {
      discos: [],
      artists: []
    }
  },
  methods: {
    async addDisco(Disco) {
      const res = await fetch('http://localhost:5083/api/Disco', {
        method: 'POST',
        headers: {
          'Content-type': 'application/json',
        },
        body: JSON.stringify(Disco),
      })

      const discos = await this.fetchDiscos()

      this.discos = discos
    },
    async fetchArtists() {
      const res = await fetch('http://localhost:5083/api/Artist')
      let artists = await res.json()
      artists = artists.map(artist => {
        return {
          ...artist,
          checked: false
        }
      })

      return artists
    },
    async fetchDiscos() {
      const res = await fetch('http://localhost:5083/api/Disco')
      const discos = await res.json()

      const discoDetails = await this.getDiscoArtists(discos);
      return discoDetails
    },
    async getDiscoArtists(discos) {
      const discoDetails = [];
      for (const disco of discos) {
        const discoId = disco.discoId;
        const Artists = await fetch(`http://localhost:5083/api/Disco/artistDisco/${discoId}`);
        const ArtistArray = await Artists.json();
        const discoObject = {
          discoId: discoId,
          nombre: disco.nombre,
          año: disco.año,
          discoArtists: ArtistArray
        };
        discoDetails.push(discoObject);
      }
      return discoDetails;
    },
    async fetchTask(id) {
      const res = await fetch(`api/discos/${id}`)

      const data = await res.json()

      return data
    },
  },
  async created() {
    this.discos = await this.fetchDiscos()
    this.artists = await this.fetchArtists()
  },
}
</script>
