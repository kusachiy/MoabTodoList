<template>
  <v-container style="padding: 30px">
    <v-row>
      <div class="d-flex align-center">
        <v-btn icon color="pink" @click="createNode(null)">
          <v-icon>mdi-plus-thick</v-icon>
        </v-btn>
        <v-btn icon color="purple" @click="saveNodes">
          <v-icon>mdi-content-save</v-icon>
        </v-btn>
      </div>
    </v-row>
    <v-row>
      <v-treeview
        v-model="selection"
        :items="nodesComputed"
        :open.sync="openIds"
        selected-color="green"
        selection-type="independent"
        selectable
        open-all
      >
        <template v-slot:label="{ item }">
          <v-text-field
            ref="rename_input"
            v-if="editingNodeId == item.id"
            label="New node name"
            v-model="item.name"
            @blur="renameNode(item)"
          ></v-text-field>
          <strong v-else style="font-size: 24px">{{ item.name }}</strong>
        </template>
        <template v-slot:append="{ item }">
          <v-btn icon color="pink" @click="createNode(item)">
            <v-icon>mdi-receipt-text-plus</v-icon>
          </v-btn>
          <v-btn icon color="orange" @click="editNode(item)">
            <v-icon>mdi-pencil</v-icon>
          </v-btn>
          <v-btn icon color="purple" @click="deleteNode(item)">
            <v-icon>mdi-delete</v-icon>
          </v-btn>
        </template>
      </v-treeview>
    </v-row>
    <v-alert
      style="margin-top: 20px;"
      :value="alert"
      color="pink"
      dark
      border="top"
      icon="mdi-home"
      transition="scale-transition"
    >
      Data saved
    </v-alert>
  </v-container>
</template>

<script>
import axios from "axios";
export default {
  data: () => ({
    alert: false,
    incrementId: 10,
    editingNodeId: null,
    newNodeName: "New Todo Item Name...",
    nodesData: [],
    openIds: [],
    selection: [],
  }),
  computed: {
    nodesComputed: function () {
      let result = this.nodesData.map((n) => ({
        id: n.id,
        parentId: n.parentId,
        name: n.name,
        children: [],
      }));
      console.log(result);
      result.forEach((r) => {
        let parent = result.find((r2) => r2.id === r.parentId && r.parentId);
        console.log(parent);
        if (parent) parent.children.push(r);
      });
      return result.filter((r) => !r.parentId);
    },
  },
  methods: {
    createNode: function (parent) {
      let node = {
        name: this.newNodeName,
        id: this.incrementId++,
        parentId: parent?.id,
      };
      this.nodesData.push(node);
      this.editingNodeId = node.id;
      this.$nextTick(() => {
        this.$refs.rename_input?.focus();
        this.openIds.push(parent?.id);
      });
    },
    editNode: function (node) {
      this.editingNodeId = node.id;
      this.$nextTick(() => {
        this.$refs.rename_input?.focus();
      });
    },
    deleteNode: function (node) {
      let index = this.nodesData.findIndex((n) => n.id == node.id);
      this.nodesData.splice(index, 1);
      node.children.forEach((n) => this.deleteNode(n));
    },
    renameNode(node) {
      console.log(node.name);
      this.editingNodeId = null;
      let nodeData = this.nodesData.find((n) => n.id == node.id);
      nodeData.name = node.name;
    },
    saveNodes: async function () {
      let response = await axios.post(
        "https://localhost:7159/api/treenodes",
        this.nodesData
      );
      this.alert = true;
      setTimeout(() => {
        this.alert = false;
      }, 3000);
      console.log(response);
    },
  },
  mounted: async function () {
    let response = await axios.get("https://localhost:7159/api/treenodes");
    this.nodesData = response.data;
    this.incrementId =
      this.nodesData.length > 0 ? this.nodesData.map((n) => n.id).max() + 1 : 1;
  },
};
</script>
