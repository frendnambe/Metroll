PGDMP  '            
        |            Users    16.2    16.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16535    Users    DATABASE     {   CREATE DATABASE "Users" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Users";
                postgres    false            �            1259    16537    users    TABLE     �   CREATE TABLE public.users (
    userid integer NOT NULL,
    username character varying(50) NOT NULL,
    passwordhash bytea NOT NULL,
    salt bytea NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    16536    users_userid_seq    SEQUENCE     �   CREATE SEQUENCE public.users_userid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.users_userid_seq;
       public          postgres    false    216            �           0    0    users_userid_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.users_userid_seq OWNED BY public.users.userid;
          public          postgres    false    215                       2604    16540    users userid    DEFAULT     l   ALTER TABLE ONLY public.users ALTER COLUMN userid SET DEFAULT nextval('public.users_userid_seq'::regclass);
 ;   ALTER TABLE public.users ALTER COLUMN userid DROP DEFAULT;
       public          postgres    false    216    215    216            �          0    16537    users 
   TABLE DATA                 public          postgres    false    216   U
       �           0    0    users_userid_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.users_userid_seq', 6, true);
          public          postgres    false    215                       2606    16544    users users_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (userid);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    216            �   �  x���;�TA���7[��n�d]u`�w42�z�` � ���
i0�np��;�w���/�m�?�_���}���������׷۫�f�����~��"5Qv��:�4+�JӡςVb I^��K�^�R��j����J+�*�O�|����a��fwu�>����y����b�?ږ���>�b*J�����/����
��àa�U\���j��K�����bMK��V����F�b� C^��q�#�H5�[��YY�F��ɩ�j�H&�u��e*ǳ_�^��Q���m��ڵ�E(���	O��<��! ��Ҙ�Dg��Sa,>aL�	�ʵ 2�ҥ�R�Z���*���*�g%��9��Ro��T8V�/넚�Vq���J���'|�T�P�aMZ��)�	5����M���4cF_tn�K�6s�Y/�["�J�H ^6+� �b��r>����ޡV]��)%�<ڐ�E[A�Z0� +��{q�TT#>     