PGDMP                     	    z            moab_db    14.5    14.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16403    moab_db    DATABASE     d   CREATE DATABASE moab_db WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE moab_db;
                postgres    false            �            1259    16404 
   tree_nodes    TABLE     a   CREATE TABLE public.tree_nodes (
    id bigint NOT NULL,
    name text,
    "parentId" bigint
);
    DROP TABLE public.tree_nodes;
       public         heap    postgres    false            �          0    16404 
   tree_nodes 
   TABLE DATA           :   COPY public.tree_nodes (id, name, "parentId") FROM stdin;
    public          postgres    false    209   1       \           2606    16410    tree_nodes tree_nodes_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tree_nodes
    ADD CONSTRAINT tree_nodes_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.tree_nodes DROP CONSTRAINT tree_nodes_pkey;
       public            postgres    false    209            �   4   x�3�t�����2�t�0L8]�c.S��!�g �6�2�t� 2L�b���� e;�     