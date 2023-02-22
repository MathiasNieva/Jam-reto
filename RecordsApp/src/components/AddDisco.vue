<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">
      <label>Nombre del Disco</label>
      <input 
        type="text" 
        v-model="name" 
        name="text" 
      />
    </div>
    <div class="form-control">
      <label>Año de Lanzamiento</label>
      <input
        type="number"
        v-model="año"
        name="año"
        step="1"
      />
    </div>
    <div class="form-control">
      <label>Artista/s</label>
      <MultiCheckbox class="checkbox" v-model:value="artistsIds" :options="artists" />
    </div>
    <input type="submit" value="Registrar Disco" class="btn btn-block" />
  </form>
</template>

<script>
import MultiCheckbox from './MultiCheckbox.vue'

export default {
  name: 'AddDisco',
  props: {
    artists: Array,
  },
  components: {
    MultiCheckbox,
  },
  data() {
    return {
      name: '',
      año: '',
      artistsIds: []
    }
  },
  methods: {
    onSubmit(e) {
      e.preventDefault()

      if (!this.name) {
        alert('El campo Nombre no puede estar vacio')
        return
      }
      if (!this.año) {
        alert('El campo Año no puede estar vacio')
        return
      }

      const newDisco = {
        discoDTO: {
          discoId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          nombre: this.name,
          año: this.año,
        },
        artistIds: this.artistsIds
      }

      this.$emit('add-disco', newDisco)

      this.name = ''
      this.año = ''
      this.artistsIds = []
      this.artists.forEach(artist => artist.Checked = false)
    },
  },
}
</script>

<style scoped>
.add-form {
  margin-bottom: 40px;
}

.form-control {
  margin: 20px 0;
}

.form-control label {
  display: block;
  font-weight: bold;
}

.checkbox {
  margin: 10px;
}

.form-control input {
  width: 100%;
  height: 40px;
  margin: 5px;
  padding: 3px 7px;
  font-size: 17px;
}

.form-control-check {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.form-control-check label {
  flex: 1;
}

.form-control-check input {
  flex: 2;
  height: 20px;
}
</style>
