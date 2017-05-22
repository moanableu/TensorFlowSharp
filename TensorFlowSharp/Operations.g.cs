using System;

namespace TensorFlow {
	public partial class TFGraph {
		/// <summary>
		///   Raise a exception to abort the process when called.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Abort'.
		/// </param>
		/// <param name="error_msg">
		///   Optional argument
		///   A string which is the message associated with the exception.
		/// </param>
		/// <param name="exit_without_error">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   If exit_without_error is true, the process will exit normally,
		///   otherwise it will exit with a SIGABORT signal.
		///   
		///   Returns nothing but an exception.
		/// </remarks>
		public TFOperation Abort (string error_msg = null, bool? exit_without_error = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Abort", MakeName ("Abort", operName));
			if (error_msg != null)
				desc.SetAttr ("error_msg", error_msg);
			
			if (exit_without_error.HasValue)
				desc.SetAttr ("exit_without_error", exit_without_error.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Computes the absolute value of a tensor.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Abs'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `x`, this operation returns a tensor containing the absolute
		///   value of each element in `x`. For example, if x is an input element and y is
		///   an output element, this operation computes \\(y = |x|\\).
		/// </remarks>
		public TFOutput Abs (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Abs", MakeName ("Abs", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes acos of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Acos'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Acos (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Acos", MakeName ("Acos", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns x + y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Add'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Add` supports broadcasting. `AddN` does not. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Add (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Add", MakeName ("Add", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Add an `N`-minibatch `SparseTensor` to a `SparseTensorsMap`, return `N` handles.
		/// </summary>
		/// <param name="sparse_indices">
		///   2-D.  The `indices` of the minibatch `SparseTensor`.
		///   `sparse_indices[:, 0]` must be ordered values in `[0, N)`.
		/// </param>
		/// <param name="sparse_values">
		///   1-D.  The `values` of the minibatch `SparseTensor`.
		/// </param>
		/// <param name="sparse_shape">
		///   1-D.  The `shape` of the minibatch `SparseTensor`.
		///   The minibatch size `N == sparse_shape[0]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AddManySparseToTensorsMap'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   The container name for the `SparseTensorsMap` created by this op.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   The shared name for the `SparseTensorsMap` created by this op.
		///   If blank, the new Operation's unique name is used.
		/// </param>
		/// <returns>
		///   1-D.  The handles of the `SparseTensor` now stored in the
		///   `SparseTensorsMap`.  Shape: `[N]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   A `SparseTensor` of rank `R` is represented by three tensors: `sparse_indices`,
		///   `sparse_values`, and `sparse_shape`, where
		///   
		///   ```sparse_indices.shape[1] == sparse_shape.shape[0] == R```
		///   
		///   An `N`-minibatch of `SparseTensor` objects is represented as a `SparseTensor`
		///   having a first `sparse_indices` column taking values between `[0, N)`, where
		///   the minibatch size `N == sparse_shape[0]`.
		///   
		///   The input `SparseTensor` must have rank `R` greater than 1, and the first
		///   dimension is treated as the minibatch dimension.  Elements of the `SparseTensor`
		///   must be sorted in increasing order of this first dimension.  The stored
		///   `SparseTensor` objects pointed to by each row of the output `sparse_handles`
		///   will have rank `R-1`.
		///   
		///   The `SparseTensor` values can then be read out as part of a minibatch by passing
		///   the given keys as vector elements to `TakeManySparseFromTensorsMap`.  To ensure
		///   the correct `SparseTensorsMap` is accessed, ensure that the same
		///   `container` and `shared_name` are passed to that Op.  If no `shared_name`
		///   is provided here, instead use the *name* of the Operation created by calling
		///   `AddManySparseToTensorsMap` as the `shared_name` passed to
		///   `TakeManySparseFromTensorsMap`.  Ensure the Operations are colocated.
		/// </remarks>
		public TFOutput AddManySparseToTensorsMap (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AddManySparseToTensorsMap", MakeName ("AddManySparseToTensorsMap", operName));
			desc.AddInput (sparse_indices);
			desc.AddInput (sparse_values);
			desc.AddInput (sparse_shape);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sparse_handles = new TFOutput (op, _idx++);
			return sparse_handles;
		}

		/// <summary>
		///   Add all input tensors element wise.
		/// </summary>
		/// <param name="inputs">
		///   Must all be the same size and shape.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AddN'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput AddN (TFOutput[] inputs, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AddN", MakeName ("AddN", operName));
			desc.AddInputs (inputs);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sum = new TFOutput (op, _idx++);
			return sum;
		}

		/// <summary>
		///   Add a `SparseTensor` to a `SparseTensorsMap` return its handle.
		/// </summary>
		/// <param name="sparse_indices">
		///   2-D.  The `indices` of the `SparseTensor`.
		/// </param>
		/// <param name="sparse_values">
		///   1-D.  The `values` of the `SparseTensor`.
		/// </param>
		/// <param name="sparse_shape">
		///   1-D.  The `shape` of the `SparseTensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AddSparseToTensorsMap'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   The container name for the `SparseTensorsMap` created by this op.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   The shared name for the `SparseTensorsMap` created by this op.
		///   If blank, the new Operation's unique name is used.
		/// </param>
		/// <returns>
		///   0-D.  The handle of the `SparseTensor` now stored in the
		///   `SparseTensorsMap`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   A `SparseTensor` is represented by three tensors: `sparse_indices`,
		///   `sparse_values`, and `sparse_shape`.
		///   
		///   This operator takes the given `SparseTensor` and adds it to a container
		///   object (a `SparseTensorsMap`).  A unique key within this container is generated
		///   in the form of an `int64`, and this is the value that is returned.
		///   
		///   The `SparseTensor` can then be read out as part of a minibatch by passing
		///   the key as a vector element to `TakeManySparseFromTensorsMap`.  To ensure
		///   the correct `SparseTensorsMap` is accessed, ensure that the same
		///   `container` and `shared_name` are passed to that Op.  If no `shared_name`
		///   is provided here, instead use the *name* of the Operation created by calling
		///   `AddSparseToTensorsMap` as the `shared_name` passed to
		///   `TakeManySparseFromTensorsMap`.  Ensure the Operations are colocated.
		/// </remarks>
		public TFOutput AddSparseToTensorsMap (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AddSparseToTensorsMap", MakeName ("AddSparseToTensorsMap", operName));
			desc.AddInput (sparse_indices);
			desc.AddInput (sparse_values);
			desc.AddInput (sparse_shape);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sparse_handle = new TFOutput (op, _idx++);
			return sparse_handle;
		}

		/// <summary>
		///   Deprecated. Disallowed in GraphDef version &amp;gt;= 2.
		/// </summary>
		/// <param name="images">
		/// </param>
		/// <param name="contrast_factor">
		/// </param>
		/// <param name="min_value">
		/// </param>
		/// <param name="max_value">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AdjustContrast'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput AdjustContrast (TFOutput images, TFOutput contrast_factor, TFOutput min_value, TFOutput max_value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AdjustContrast", MakeName ("AdjustContrast", operName));
			desc.AddInput (images);
			desc.AddInput (contrast_factor);
			desc.AddInput (min_value);
			desc.AddInput (max_value);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adjust the contrast of one or more images.
		/// </summary>
		/// <param name="images">
		///   Images to adjust.  At least 3-D.
		/// </param>
		/// <param name="contrast_factor">
		///   A float multiplier for adjusting contrast.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AdjustContrastv2'.
		/// </param>
		/// <returns>
		///   The contrast-adjusted image or images.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `images` is a tensor of at least 3 dimensions.  The last 3 dimensions are
		///   interpreted as `[height, width, channels]`.  The other dimensions only
		///   represent a collection of images, such as `[batch, height, width, channels].`
		///   
		///   Contrast is adjusted independently for each channel of each image.
		///   
		///   For each channel, the Op first computes the mean of the image pixels in the
		///   channel and then adjusts each component of each pixel to
		///   `(x - mean) * contrast_factor + mean`.
		/// </remarks>
		public TFOutput AdjustContrastv2 (TFOutput images, TFOutput contrast_factor, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AdjustContrastv2", MakeName ("AdjustContrastv2", operName));
			desc.AddInput (images);
			desc.AddInput (contrast_factor);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adjust the hue of one or more images.
		/// </summary>
		/// <param name="images">
		///   Images to adjust.  At least 3-D.
		/// </param>
		/// <param name="delta">
		///   A float delta to add to the hue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AdjustHue'.
		/// </param>
		/// <returns>
		///   The hue-adjusted image or images.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `images` is a tensor of at least 3 dimensions.  The last dimension is
		///   interpretted as channels, and must be three.
		///   
		///   The input image is considered in the RGB colorspace. Conceptually, the RGB
		///   colors are first mapped into HSV. A delta is then applied all the hue values,
		///   and then remapped back to RGB colorspace.
		/// </remarks>
		public TFOutput AdjustHue (TFOutput images, TFOutput delta, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AdjustHue", MakeName ("AdjustHue", operName));
			desc.AddInput (images);
			desc.AddInput (delta);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adjust the saturation of one or more images.
		/// </summary>
		/// <param name="images">
		///   Images to adjust.  At least 3-D.
		/// </param>
		/// <param name="scale">
		///   A float scale to add to the saturation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AdjustSaturation'.
		/// </param>
		/// <returns>
		///   The hue-adjusted image or images.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `images` is a tensor of at least 3 dimensions.  The last dimension is
		///   interpretted as channels, and must be three.
		///   
		///   The input image is considered in the RGB colorspace. Conceptually, the RGB
		///   colors are first mapped into HSV. A scale is then applied all the saturation
		///   values, and then remapped back to RGB colorspace.
		/// </remarks>
		public TFOutput AdjustSaturation (TFOutput images, TFOutput scale, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AdjustSaturation", MakeName ("AdjustSaturation", operName));
			desc.AddInput (images);
			desc.AddInput (scale);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the "logical and" of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'All'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput All (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "All", MakeName ("All", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a learned unigram distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AllCandidateSampler'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to produce.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See explanations of candidate sampling and the data formats at
		///   go/candidate-sampling.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) AllCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AllCandidateSampler", MakeName ("AllCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Computes the "logical or" of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Any'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Any (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Any", MakeName ("Any", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the truth value of abs(x-y) &amp;lt; tolerance element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ApproximateEqual'.
		/// </param>
		/// <param name="tolerance">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ApproximateEqual (TFOutput x, TFOutput y, float? tolerance = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ApproximateEqual", MakeName ("ApproximateEqual", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			if (tolerance.HasValue)
				desc.SetAttr ("tolerance", tolerance.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns the index with the largest value across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="dimension">
		///   int32, 0 &amp;lt;= dimension &amp;lt; rank(input).  Describes which dimension
		///   of the input Tensor to reduce across. For vectors, use dimension = 0.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ArgMax'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Note that in case of ties the identity of the return value is not guaranteed.
		/// </remarks>
		public TFOutput ArgMax (TFOutput input, TFOutput dimension, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ArgMax", MakeName ("ArgMax", operName));
			desc.AddInput (input);
			desc.AddInput (dimension);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the index with the smallest value across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="dimension">
		///   int32, 0 &amp;lt;= dimension &amp;lt; rank(input).  Describes which dimension
		///   of the input Tensor to reduce across. For vectors, use dimension = 0.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ArgMin'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Note that in case of ties the identity of the return value is not guaranteed.
		/// </remarks>
		public TFOutput ArgMin (TFOutput input, TFOutput dimension, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ArgMin", MakeName ("ArgMin", operName));
			desc.AddInput (input);
			desc.AddInput (dimension);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes asin of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Asin'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Asin (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Asin", MakeName ("Asin", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Asserts that the given condition is true.
		/// </summary>
		/// <param name="condition">
		///   The condition to evaluate.
		/// </param>
		/// <param name="data">
		///   The tensors to print out when condition is false.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Assert'.
		/// </param>
		/// <param name="summarize">
		///   Optional argument
		///   Print this many entries of each tensor.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   If `condition` evaluates to false, print the list of tensors in `data`.
		///   `summarize` determines how many entries of the tensors to print.
		/// </remarks>
		public TFOperation Assert (TFOutput condition, TFOutput[] data, long? summarize = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Assert", MakeName ("Assert", operName));
			desc.AddInput (condition);
			desc.AddInputs (data);
			if (summarize.HasValue)
				desc.SetAttr ("summarize", summarize.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Adds a value to the current value of a variable.
		/// </summary>
		/// <param name="resource">
		///   handle to the resource in which to store the variable.
		/// </param>
		/// <param name="value">
		///   the value by which the variable will be incremented.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AssignAddVariableOp'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Any ReadVariableOp which depends directly or indirectly on this assign is
		///   guaranteed to see the incremented value or a subsequent newer one.
		///   
		///   Outputs the incremented value, which can be used to totally order the
		///   increments to this variable.
		/// </remarks>
		public TFOperation AssignAddVariableOp (TFOutput resource, TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AssignAddVariableOp", MakeName ("AssignAddVariableOp", operName));
			desc.AddInput (resource);
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Subtracts a value from the current value of a variable.
		/// </summary>
		/// <param name="resource">
		///   handle to the resource in which to store the variable.
		/// </param>
		/// <param name="value">
		///   the value by which the variable will be incremented.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AssignSubVariableOp'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Any ReadVariableOp which depends directly or indirectly on this assign is
		///   guaranteed to see the incremented value or a subsequent newer one.
		///   
		///   Outputs the incremented value, which can be used to totally order the
		///   increments to this variable.
		/// </remarks>
		public TFOperation AssignSubVariableOp (TFOutput resource, TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AssignSubVariableOp", MakeName ("AssignSubVariableOp", operName));
			desc.AddInput (resource);
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Assigns a new value to a variable.
		/// </summary>
		/// <param name="resource">
		///   handle to the resource in which to store the variable.
		/// </param>
		/// <param name="value">
		///   the value to set the new tensor to use.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AssignVariableOp'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Any ReadVariableOp with a control dependency on this op is guaranteed to return
		///   this value or a subsequent newer value of the variable.
		/// </remarks>
		public TFOperation AssignVariableOp (TFOutput resource, TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AssignVariableOp", MakeName ("AssignVariableOp", operName));
			desc.AddInput (resource);
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Converts each entry in the given tensor to strings.  Supports many numeric
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AsString'.
		/// </param>
		/// <param name="precision">
		///   Optional argument
		///   The post-decimal precision to use for floating point numbers.
		///   Only used if precision &amp;gt; -1.
		/// </param>
		/// <param name="scientific">
		///   Optional argument
		///   Use scientific notation for floating point numbers.
		/// </param>
		/// <param name="shortest">
		///   Optional argument
		///   Use shortest representation (either scientific or standard) for
		///   floating point numbers.
		/// </param>
		/// <param name="width">
		///   Optional argument
		///   Pad pre-decimal numbers to this width.
		///   Applies to both floating point and integer numbers.
		///   Only used if width &amp;gt; -1.
		/// </param>
		/// <param name="fill">
		///   Optional argument
		///   The value to pad if width &amp;gt; -1.  If empty, pads with spaces.
		///   Another typical value is '0'.  String cannot be longer than 1 character.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   types and boolean.
		/// </remarks>
		public TFOutput AsString (TFOutput input, long? precision = null, bool? scientific = null, bool? shortest = null, long? width = null, string fill = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AsString", MakeName ("AsString", operName));
			desc.AddInput (input);
			if (precision.HasValue)
				desc.SetAttr ("precision", precision.Value);
			
			if (scientific.HasValue)
				desc.SetAttr ("scientific", scientific.Value);
			
			if (shortest.HasValue)
				desc.SetAttr ("shortest", shortest.Value);
			
			if (width.HasValue)
				desc.SetAttr ("width", width.Value);
			
			if (fill != null)
				desc.SetAttr ("fill", fill);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes atan of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Atan'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Atan (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Atan", MakeName ("Atan", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes arctangent of `y/x` element-wise, respecting signs of the arguments.
		/// </summary>
		/// <param name="y">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Atan2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is the angle \( \theta \in [-\pi, \pi] \) such that
		///   \[ x = r \cos(\theta) \]
		///   and
		///   \[ y = r \sin(\theta) \]
		///   where \(r = \sqrt(x^2 + y^2) \).
		/// </remarks>
		public TFOutput Atan2 (TFOutput y, TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Atan2", MakeName ("Atan2", operName));
			desc.AddInput (y);
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Produces a visualization of audio data over time.
		/// </summary>
		/// <param name="input">
		///   Float representation of audio data.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AudioSpectrogram'.
		/// </param>
		/// <param name="magnitude_squared">
		///   Optional argument
		///   Whether to return the squared magnitude or just the
		///   magnitude. Using squared magnitude can avoid extra calculations.
		/// </param>
		/// <param name="window_size">
		///   How wide the input window is in samples. For the highest efficiency
		///   this should be a power of two, but other values are accepted.
		/// </param>
		/// <param name="stride">
		///   How widely apart the center of adjacent sample windows should be.
		/// </param>
		/// <returns>
		///   3D representation of the audio frequencies as an image.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Spectrograms are a standard way of representing audio information as a series of
		///   slices of frequency information, one slice for each window of time. By joining
		///   these together into a sequence, they form a distinctive fingerprint of the sound
		///   over time.
		///   
		///   This op expects to receive audio data as an input, stored as floats in the range
		///   -1 to 1, together with a window width in samples, and a stride specifying how
		///   far to move the window between slices. From this it generates a three
		///   dimensional output. The lowest dimension has an amplitude value for each
		///   frequency during that time slice. The next dimension is time, with successive
		///   frequency slices. The final dimension is for the channels in the input, so a
		///   stereo audio input would have two here for example.
		///   
		///   This means the layout when converted and saved as an image is rotated 90 degrees
		///   clockwise from a typical spectrogram. Time is descending down the Y axis, and
		///   the frequency decreases from left to right.
		///   
		///   Each value in the result represents the square root of the sum of the real and
		///   imaginary parts of an FFT on the current window of samples. In this way, the
		///   lowest dimension represents the power of each frequency in the current window,
		///   and adjacent windows are concatenated in the next dimension.
		///   
		///   To get a more intuitive and visual look at what this operation does, you can run
		///   tensorflow/examples/wav_to_spectrogram to read in an audio file and save out the
		///   resulting spectrogram as a PNG image.
		/// </remarks>
		public TFOutput AudioSpectrogram (TFOutput input, long window_size, long stride, bool? magnitude_squared = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AudioSpectrogram", MakeName ("AudioSpectrogram", operName));
			desc.AddInput (input);
			desc.SetAttr ("window_size", window_size);
			desc.SetAttr ("stride", stride);
			if (magnitude_squared.HasValue)
				desc.SetAttr ("magnitude_squared", magnitude_squared.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var spectrogram = new TFOutput (op, _idx++);
			return spectrogram;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with audio.
		/// </summary>
		/// <param name="tag">
		///   Scalar. Used to build the `tag` attribute of the summary values.
		/// </param>
		/// <param name="tensor">
		///   2-D of shape `[batch_size, frames]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AudioSummary'.
		/// </param>
		/// <param name="max_outputs">
		///   Optional argument
		///   Max number of batch elements to generate audio for.
		/// </param>
		/// <param name="sample_rate">
		///   The sample rate of the signal in hertz.
		/// </param>
		/// <returns>
		///   Scalar. Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The summary has up to `max_outputs` summary values containing audio. The
		///   audio is built from `tensor` which must be 3-D with shape `[batch_size,
		///   frames, channels]` or 2-D with shape `[batch_size, frames]`. The values are
		///   assumed to be in the range of `[-1.0, 1.0]` with a sample rate of `sample_rate`.
		///   
		///   The `tag` argument is a scalar `Tensor` of type `string`.  It is used to
		///   build the `tag` of the summary values:
		///   
		///   *  If `max_outputs` is 1, the summary value tag is '*tag*/audio'.
		///   *  If `max_outputs` is greater than 1, the summary value tags are
		///      generated sequentially as '*tag*/audio/0', '*tag*/audio/1', etc.
		/// </remarks>
		public TFOutput AudioSummary (TFOutput tag, TFOutput tensor, float sample_rate, long? max_outputs = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AudioSummary", MakeName ("AudioSummary", operName));
			desc.AddInput (tag);
			desc.AddInput (tensor);
			desc.SetAttr ("sample_rate", sample_rate);
			if (max_outputs.HasValue)
				desc.SetAttr ("max_outputs", max_outputs.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with audio.
		/// </summary>
		/// <param name="tag">
		///   Scalar. Used to build the `tag` attribute of the summary values.
		/// </param>
		/// <param name="tensor">
		///   2-D of shape `[batch_size, frames]`.
		/// </param>
		/// <param name="sample_rate">
		///   The sample rate of the signal in hertz.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AudioSummaryV2'.
		/// </param>
		/// <param name="max_outputs">
		///   Optional argument
		///   Max number of batch elements to generate audio for.
		/// </param>
		/// <returns>
		///   Scalar. Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The summary has up to `max_outputs` summary values containing audio. The
		///   audio is built from `tensor` which must be 3-D with shape `[batch_size,
		///   frames, channels]` or 2-D with shape `[batch_size, frames]`. The values are
		///   assumed to be in the range of `[-1.0, 1.0]` with a sample rate of `sample_rate`.
		///   
		///   The `tag` argument is a scalar `Tensor` of type `string`.  It is used to
		///   build the `tag` of the summary values:
		///   
		///   *  If `max_outputs` is 1, the summary value tag is '*tag*/audio'.
		///   *  If `max_outputs` is greater than 1, the summary value tags are
		///      generated sequentially as '*tag*/audio/0', '*tag*/audio/1', etc.
		/// </remarks>
		public TFOutput AudioSummaryV2 (TFOutput tag, TFOutput tensor, TFOutput sample_rate, long? max_outputs = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AudioSummaryV2", MakeName ("AudioSummaryV2", operName));
			desc.AddInput (tag);
			desc.AddInput (tensor);
			desc.AddInput (sample_rate);
			if (max_outputs.HasValue)
				desc.SetAttr ("max_outputs", max_outputs.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Performs average pooling on the input.
		/// </summary>
		/// <param name="value">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AvgPool'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   The size of the sliding window for each dimension of `value`.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of `value`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The average pooled output tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Each entry in `output` is the mean of the corresponding size `ksize`
		///   window in `value`.
		/// </remarks>
		public TFOutput AvgPool (TFOutput value, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AvgPool", MakeName ("AvgPool", operName));
			desc.AddInput (value);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Performs 3D average pooling on the input.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, depth, rows, cols, channels]` tensor to pool over.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AvgPool3D'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   1-D tensor of length 5. The size of the window for each dimension of
		///   the input tensor. Must have `ksize[0] = ksize[4] = 1`.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The average pooled output tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput AvgPool3D (TFOutput input, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AvgPool3D", MakeName ("AvgPool3D", operName));
			desc.AddInput (input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients of average pooling function.
		/// </summary>
		/// <param name="orig_input_shape">
		///   The original input dimensions.
		/// </param>
		/// <param name="grad">
		///   Output backprop of shape `[batch, depth, rows, cols, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AvgPool3DGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   1-D tensor of length 5. The size of the window for each dimension of
		///   the input tensor. Must have `ksize[0] = ksize[4] = 1`.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The backprop for input.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput AvgPool3DGrad (TFOutput orig_input_shape, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AvgPool3DGrad", MakeName ("AvgPool3DGrad", operName));
			desc.AddInput (orig_input_shape);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients of the average pooling function.
		/// </summary>
		/// <param name="orig_input_shape">
		///   1-D.  Shape of the original input to `avg_pool`.
		/// </param>
		/// <param name="grad">
		///   4-D with shape `[batch, height, width, channels]`.  Gradients w.r.t.
		///   the output of `avg_pool`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'AvgPoolGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   The size of the sliding window for each dimension of the input.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D.  Gradients w.r.t. the input of `avg_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput AvgPoolGrad (TFOutput orig_input_shape, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "AvgPoolGrad", MakeName ("AvgPoolGrad", operName));
			desc.AddInput (orig_input_shape);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a dataset that batches `batch_size` elements from `input_dataset`.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="batch_size">
		///   A scalar representing the number of elements to accumulate in a
		///   batch.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput BatchDataset (TFOutput input_dataset, TFOutput batch_size, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchDataset", MakeName ("BatchDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (batch_size);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Multiplies slices of two tensors in batches.
		/// </summary>
		/// <param name="x">
		///   2-D or higher with shape `[..., r_x, c_x]`.
		/// </param>
		/// <param name="y">
		///   2-D or higher with shape `[..., r_y, c_y]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchMatMul'.
		/// </param>
		/// <param name="adj_x">
		///   Optional argument
		///   If `True`, adjoint the slices of `x`. Defaults to `False`.
		/// </param>
		/// <param name="adj_y">
		///   Optional argument
		///   If `True`, adjoint the slices of `y`. Defaults to `False`.
		/// </param>
		/// <returns>
		///   3-D or higher with shape `[..., r_o, c_o]`
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Multiplies all slices of `Tensor` `x` and `y` (each slice can be
		///   viewed as an element of a batch), and arranges the individual results
		///   in a single output tensor of the same batch size. Each of the
		///   individual slices can optionally be adjointed (to adjoint a matrix
		///   means to transpose and conjugate it) before multiplication by setting
		///   the `adj_x` or `adj_y` flag to `True`, which are by default `False`.
		///   
		///   The input tensors `x` and `y` are 2-D or higher with shape `[..., r_x, c_x]`
		///   and `[..., r_y, c_y]`.
		///   
		///   The output tensor is 2-D or higher with shape `[..., r_o, c_o]`, where:
		///   
		///       r_o = c_x if adj_x else r_x
		///       c_o = r_y if adj_y else c_y
		///   
		///   It is computed as:
		///   
		///       output[..., :, :] = matrix(x[..., :, :]) * matrix(y[..., :, :])
		/// </remarks>
		public TFOutput BatchMatMul (TFOutput x, TFOutput y, bool? adj_x = null, bool? adj_y = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchMatMul", MakeName ("BatchMatMul", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			if (adj_x.HasValue)
				desc.SetAttr ("adj_x", adj_x.Value);
			
			if (adj_y.HasValue)
				desc.SetAttr ("adj_y", adj_y.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Batch normalization.
		/// </summary>
		/// <param name="t">
		///   A 4D input Tensor.
		/// </param>
		/// <param name="m">
		///   A 1D mean Tensor with size matching the last dimension of t.
		///   This is the first output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="v">
		///   A 1D variance Tensor with size matching the last dimension of t.
		///   This is the second output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="beta">
		///   A 1D beta Tensor with size matching the last dimension of t.
		///   An offset to be added to the normalized tensor.
		/// </param>
		/// <param name="gamma">
		///   A 1D gamma Tensor with size matching the last dimension of t.
		///   If "scale_after_normalization" is true, this tensor will be multiplied
		///   with the normalized tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchNormWithGlobalNormalization'.
		/// </param>
		/// <param name="variance_epsilon">
		///   A small float number to avoid dividing by 0.
		/// </param>
		/// <param name="scale_after_normalization">
		///   A bool indicating whether the resulted tensor
		///   needs to be multiplied with gamma.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op is deprecated. Prefer `tf.nn.batch_normalization`.
		/// </remarks>
		public TFOutput BatchNormWithGlobalNormalization (TFOutput t, TFOutput m, TFOutput v, TFOutput beta, TFOutput gamma, float variance_epsilon, bool scale_after_normalization, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchNormWithGlobalNormalization", MakeName ("BatchNormWithGlobalNormalization", operName));
			desc.AddInput (t);
			desc.AddInput (m);
			desc.AddInput (v);
			desc.AddInput (beta);
			desc.AddInput (gamma);
			desc.SetAttr ("variance_epsilon", variance_epsilon);
			desc.SetAttr ("scale_after_normalization", scale_after_normalization);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var result = new TFOutput (op, _idx++);
			return result;
		}

		/// <summary>
		///   Gradients for batch normalization.
		/// </summary>
		/// <param name="t">
		///   A 4D input Tensor.
		/// </param>
		/// <param name="m">
		///   A 1D mean Tensor with size matching the last dimension of t.
		///   This is the first output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="v">
		///   A 1D variance Tensor with size matching the last dimension of t.
		///   This is the second output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="gamma">
		///   A 1D gamma Tensor with size matching the last dimension of t.
		///   If "scale_after_normalization" is true, this Tensor will be multiplied
		///   with the normalized Tensor.
		/// </param>
		/// <param name="backprop">
		///   4D backprop Tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchNormWithGlobalNormalizationGrad'.
		/// </param>
		/// <param name="variance_epsilon">
		///   A small float number to avoid dividing by 0.
		/// </param>
		/// <param name="scale_after_normalization">
		///   A bool indicating whether the resulted tensor
		///   needs to be multiplied with gamma.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   dx: 4D backprop tensor for input.
		///   dm: 1D backprop tensor for mean.
		///   dv: 1D backprop tensor for variance.
		///   db: 1D backprop tensor for beta.
		///   dg: 1D backprop tensor for gamma.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This op is deprecated. See `tf.nn.batch_normalization`.
		/// </remarks>
		public (TFOutput dx, TFOutput dm, TFOutput dv, TFOutput db, TFOutput dg) BatchNormWithGlobalNormalizationGrad (TFOutput t, TFOutput m, TFOutput v, TFOutput gamma, TFOutput backprop, float variance_epsilon, bool scale_after_normalization, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchNormWithGlobalNormalizationGrad", MakeName ("BatchNormWithGlobalNormalizationGrad", operName));
			desc.AddInput (t);
			desc.AddInput (m);
			desc.AddInput (v);
			desc.AddInput (gamma);
			desc.AddInput (backprop);
			desc.SetAttr ("variance_epsilon", variance_epsilon);
			desc.SetAttr ("scale_after_normalization", scale_after_normalization);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var dx = new TFOutput (op, _idx++);
			var dm = new TFOutput (op, _idx++);
			var dv = new TFOutput (op, _idx++);
			var db = new TFOutput (op, _idx++);
			var dg = new TFOutput (op, _idx++);
			return (dx, dm, dv, db, dg);
		}

		/// <summary>
		///   BatchToSpace for 4-D tensors of type T.
		/// </summary>
		/// <param name="input">
		///   4-D tensor with shape
		///   `[batch*block_size*block_size, height_pad/block_size, width_pad/block_size,
		///     depth]`. Note that the batch size of the input tensor must be divisible by
		///   `block_size * block_size`.
		/// </param>
		/// <param name="crops">
		///   2-D tensor of non-negative integers with shape `[2, 2]`. It specifies
		///   how many elements to crop from the intermediate result across the spatial
		///   dimensions as follows:
		///   
		///       crops = [[crop_top, crop_bottom], [crop_left, crop_right]]
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchToSpace'.
		/// </param>
		/// <param name="block_size">
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, height, width, depth]`, where:
		///   
		///         height = height_pad - crop_top - crop_bottom
		///         width = width_pad - crop_left - crop_right
		///   
		///   The attr `block_size` must be greater than one. It indicates the block size.
		///   
		///   Some examples:
		///   
		///   (1) For the following input of shape `[4, 1, 1, 1]` and block_size of 2:
		///   
		///   ```
		///   [[[[1]]], [[[2]]], [[[3]]], [[[4]]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 2, 2, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [2]], [[3], [4]]]]
		///   ```
		///   
		///   (2) For the following input of shape `[4, 1, 1, 3]` and block_size of 2:
		///   
		///   ```
		///   [[[1, 2, 3]], [[4, 5, 6]], [[7, 8, 9]], [[10, 11, 12]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 2, 2, 3]` and value:
		///   
		///   ```
		///   x = [[[[1, 2, 3], [4, 5, 6]],
		///         [[7, 8, 9], [10, 11, 12]]]]
		///   ```
		///   
		///   (3) For the following input of shape `[4, 2, 2, 1]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1], [3]], [[9], [11]]],
		///        [[[2], [4]], [[10], [12]]],
		///        [[[5], [7]], [[13], [15]]],
		///        [[[6], [8]], [[14], [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 4, 4, 1]` and value:
		///   
		///   ```
		///   x = [[[1],   [2],  [3],  [4]],
		///        [[5],   [6],  [7],  [8]],
		///        [[9],  [10], [11],  [12]],
		///        [[13], [14], [15],  [16]]]
		///   ```
		///   
		///   (4) For the following input of shape `[8, 1, 2, 1]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1], [3]]], [[[9], [11]]], [[[2], [4]]], [[[10], [12]]],
		///        [[[5], [7]]], [[[13], [15]]], [[[6], [8]]], [[[14], [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[2, 2, 4, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [3]], [[5], [7]]],
		///        [[[2], [4]], [[10], [12]]],
		///        [[[5], [7]], [[13], [15]]],
		///        [[[6], [8]], [[14], [16]]]]
		///   ```
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is a legacy version of the more general BatchToSpaceND.
		///   
		///   Rearranges (permutes) data from batch into blocks of spatial data, followed by
		///   cropping. This is the reverse transformation of SpaceToBatch. More specifically,
		///   this op outputs a copy of the input tensor where values from the `batch`
		///   dimension are moved in spatial blocks to the `height` and `width` dimensions,
		///   followed by cropping along the `height` and `width` dimensions.
		/// </remarks>
		public TFOutput BatchToSpace (TFOutput input, TFOutput crops, long block_size, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchToSpace", MakeName ("BatchToSpace", operName));
			desc.AddInput (input);
			desc.AddInput (crops);
			desc.SetAttr ("block_size", block_size);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   BatchToSpace for N-D tensors of type T.
		/// </summary>
		/// <param name="input">
		///   N-D with shape `input_shape = [batch] + spatial_shape + remaining_shape`,
		///   where spatial_shape has M dimensions.
		/// </param>
		/// <param name="block_shape">
		///   1-D with shape `[M]`, all values must be &amp;gt;= 1.
		/// </param>
		/// <param name="crops">
		///   2-D with shape `[M, 2]`, all values must be &amp;gt;= 0.
		///     `crops[i] = [crop_start, crop_end]` specifies the amount to crop from input
		///     dimension `i + 1`, which corresponds to spatial dimension `i`.  It is
		///     required that
		///     `crop_start[i] + crop_end[i] &amp;lt;= block_shape[i] * input_shape[i + 1]`.
		///   
		///   This operation is equivalent to the following steps:
		///   
		///   1. Reshape `input` to `reshaped` of shape:
		///        [block_shape[0], ..., block_shape[M-1],
		///         batch / prod(block_shape),
		///         input_shape[1], ..., input_shape[N-1]]
		///   
		///   2. Permute dimensions of `reshaped` to produce `permuted` of shape
		///        [batch / prod(block_shape),
		///   
		///         input_shape[1], block_shape[0],
		///         ...,
		///         input_shape[M], block_shape[M-1],
		///   
		///         input_shape[M+1], ..., input_shape[N-1]]
		///   
		///   3. Reshape `permuted` to produce `reshaped_permuted` of shape
		///        [batch / prod(block_shape),
		///   
		///         input_shape[1] * block_shape[0],
		///         ...,
		///         input_shape[M] * block_shape[M-1],
		///   
		///         input_shape[M+1],
		///         ...,
		///         input_shape[N-1]]
		///   
		///   4. Crop the start and end of dimensions `[1, ..., M]` of
		///      `reshaped_permuted` according to `crops` to produce the output of shape:
		///        [batch / prod(block_shape),
		///   
		///         input_shape[1] * block_shape[0] - crops[0,0] - crops[0,1],
		///         ...,
		///         input_shape[M] * block_shape[M-1] - crops[M-1,0] - crops[M-1,1],
		///   
		///         input_shape[M+1], ..., input_shape[N-1]]
		///   
		///   Some examples:
		///   
		///   (1) For the following input of shape `[4, 1, 1, 1]`, `block_shape = [2, 2]`, and
		///       `crops = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   [[[[1]]], [[[2]]], [[[3]]], [[[4]]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 2, 2, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [2]], [[3], [4]]]]
		///   ```
		///   
		///   (2) For the following input of shape `[4, 1, 1, 3]`, `block_shape = [2, 2]`, and
		///       `crops = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   [[[1, 2, 3]], [[4, 5, 6]], [[7, 8, 9]], [[10, 11, 12]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 2, 2, 3]` and value:
		///   
		///   ```
		///   x = [[[[1, 2, 3], [4, 5, 6]],
		///         [[7, 8, 9], [10, 11, 12]]]]
		///   ```
		///   
		///   (3) For the following input of shape `[4, 2, 2, 1]`, `block_shape = [2, 2]`, and
		///       `crops = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   x = [[[[1], [3]], [[9], [11]]],
		///        [[[2], [4]], [[10], [12]]],
		///        [[[5], [7]], [[13], [15]]],
		///        [[[6], [8]], [[14], [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[1, 4, 4, 1]` and value:
		///   
		///   ```
		///   x = [[[1],   [2],  [3],  [4]],
		///        [[5],   [6],  [7],  [8]],
		///        [[9],  [10], [11],  [12]],
		///        [[13], [14], [15],  [16]]]
		///   ```
		///   
		///   (4) For the following input of shape `[8, 1, 3, 1]`, `block_shape = [2, 2]`, and
		///       `crops = [[0, 0], [2, 0]]`:
		///   
		///   ```
		///   x = [[[[0], [1], [3]]], [[[0], [9], [11]]],
		///        [[[0], [2], [4]]], [[[0], [10], [12]]],
		///        [[[0], [5], [7]]], [[[0], [13], [15]]],
		///        [[[0], [6], [8]]], [[[0], [14], [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[2, 2, 4, 1]` and value:
		///   
		///   ```
		///   x = [[[[1],   [2],  [3],  [4]],
		///         [[5],   [6],  [7],  [8]]],
		///        [[[9],  [10], [11],  [12]],
		///         [[13], [14], [15],  [16]]]]
		///   ```
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BatchToSpaceND'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation reshapes the "batch" dimension 0 into `M + 1` dimensions of shape
		///   `block_shape + [batch]`, interleaves these blocks back into the grid defined by
		///   the spatial dimensions `[1, ..., M]`, to obtain a result with the same rank as
		///   the input.  The spatial dimensions of this intermediate result are then
		///   optionally cropped according to `crops` to produce the output.  This is the
		///   reverse of SpaceToBatch.  See below for a precise description.
		/// </remarks>
		public TFOutput BatchToSpaceND (TFOutput input, TFOutput block_shape, TFOutput crops, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BatchToSpaceND", MakeName ("BatchToSpaceND", operName));
			desc.AddInput (input);
			desc.AddInput (block_shape);
			desc.AddInput (crops);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Compute the regularized incomplete beta integral \\(I_x(a, b)\\).
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="b">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Betainc'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The regularized incomplete beta integral is defined as:
		///   
		///   
		///   \\(I_x(a, b) = \frac{B(x; a, b)}{B(a, b)}\\)
		///   
		///   where
		///   
		///   
		///   \\(B(x; a, b) = \int_0^x t^{a-1} (1 - t)^{b-1} dt\\)
		///   
		///   
		///   is the incomplete beta function and \\(B(a, b)\\) is the *complete*
		///   beta function.
		/// </remarks>
		public TFOutput Betainc (TFOutput a, TFOutput b, TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Betainc", MakeName ("Betainc", operName));
			desc.AddInput (a);
			desc.AddInput (b);
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Adds `bias` to `value`.
		/// </summary>
		/// <param name="value">
		///   Any number of dimensions.
		/// </param>
		/// <param name="bias">
		///   1-D with size the last dimension of `value`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BiasAdd'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the bias tensor will be added to the last dimension
		///   of the value tensor.
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		///   The tensor will be added to "in_channels", the third-to-the-last
		///       dimension.
		/// </param>
		/// <returns>
		///   Broadcasted sum of `value` and `bias`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is a special case of `tf.add` where `bias` is restricted to be 1-D.
		///   Broadcasting is supported, so `value` may have any number of dimensions.
		/// </remarks>
		public TFOutput BiasAdd (TFOutput value, TFOutput bias, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BiasAdd", MakeName ("BiasAdd", operName));
			desc.AddInput (value);
			desc.AddInput (bias);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   The backward operation for "BiasAdd" on the "bias" tensor.
		/// </summary>
		/// <param name="out_backprop">
		///   Any number of dimensions.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BiasAddGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the bias tensor will be added to the last dimension
		///   of the value tensor.
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		///   The tensor will be added to "in_channels", the third-to-the-last
		///       dimension.
		/// </param>
		/// <returns>
		///   1-D with size the feature dimension of `out_backprop`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   It accumulates all the values from out_backprop into the feature dimension.
		///   For NHWC data format, the feature dimension is the last. For NCHW data format,
		///   the feature dimension is the third-to-last.
		/// </remarks>
		public TFOutput BiasAddGrad (TFOutput out_backprop, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BiasAddGrad", MakeName ("BiasAddGrad", operName));
			desc.AddInput (out_backprop);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adds `bias` to `value`.
		/// </summary>
		/// <param name="value">
		///   Any number of dimensions.
		/// </param>
		/// <param name="bias">
		///   1-D with size the last dimension of `value`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BiasAddV1'.
		/// </param>
		/// <returns>
		///   Broadcasted sum of `value` and `bias`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is a deprecated version of BiasAdd and will be soon removed.
		///   
		///   This is a special case of `tf.add` where `bias` is restricted to be 1-D.
		///   Broadcasting is supported, so `value` may have any number of dimensions.
		/// </remarks>
		public TFOutput BiasAddV1 (TFOutput value, TFOutput bias, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BiasAddV1", MakeName ("BiasAddV1", operName));
			desc.AddInput (value);
			desc.AddInput (bias);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Counts the number of occurrences of each value in an integer array.
		/// </summary>
		/// <param name="arr">
		///   int32 `Tensor`.
		/// </param>
		/// <param name="size">
		///   non-negative int32 scalar `Tensor`.
		/// </param>
		/// <param name="weights">
		///   is an int32, int64, float32, or float64 `Tensor` with the same
		///   shape as `arr`, or a length-0 `Tensor`, in which case it acts as all weights
		///   equal to 1.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Bincount'.
		/// </param>
		/// <returns>
		///   1D `Tensor` with length equal to `size`. The counts or summed weights for
		///   each value in the range [0, size).
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Outputs a vector with length `size` and the same dtype as `weights`. If
		///   `weights` are empty, then index `i` stores the number of times the value `i` is
		///   counted in `arr`. If `weights` are non-empty, then index `i` stores the sum of
		///   the value in `weights` at each index where the corresponding value in `arr` is
		///   `i`.
		///   
		///   Values in `arr` outside of the range [0, size) are ignored.
		/// </remarks>
		public TFOutput Bincount (TFOutput arr, TFOutput size, TFOutput weights, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Bincount", MakeName ("Bincount", operName));
			desc.AddInput (arr);
			desc.AddInput (size);
			desc.AddInput (weights);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var bins = new TFOutput (op, _idx++);
			return bins;
		}

		/// <summary>
		///   Bitcasts a tensor from one type to another without copying data.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Bitcast'.
		/// </param>
		/// <param name="type">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input`, this operation returns a tensor that has the same buffer
		///   data as `input` with datatype `type`.
		///   
		///   If the input datatype `T` is larger than the output datatype `type` then the
		///   shape changes from [...] to [..., sizeof(`T`)/sizeof(`type`)].
		///   
		///   If `T` is smaller than `type`, the operator requires that the rightmost
		///   dimension be equal to sizeof(`type`)/sizeof(`T`). The shape then goes from
		///   [..., sizeof(`type`)/sizeof(`T`)] to [...].
		///   
		///   *NOTE*: Bitcast is implemented as a low-level cast, so machines with different
		///   endian orderings will give different results.
		/// </remarks>
		public TFOutput Bitcast (TFOutput input, TFDataType type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Bitcast", MakeName ("Bitcast", operName));
			desc.AddInput (input);
			desc.SetAttrType ("type", type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Return the shape of s0 op s1 with broadcast.
		/// </summary>
		/// <param name="s0">
		/// </param>
		/// <param name="s1">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BroadcastArgs'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given `s0` and `s1`, tensors that represent shapes, compute `r0`, the
		///   broadcasted shape. `s0`, `s1` and `r0` are all integer vectors.
		/// </remarks>
		public TFOutput BroadcastArgs (TFOutput s0, TFOutput s1, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BroadcastArgs", MakeName ("BroadcastArgs", operName));
			desc.AddInput (s0);
			desc.AddInput (s1);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var r0 = new TFOutput (op, _idx++);
			return r0;
		}

		/// <summary>
		///   Return the reduction indices for computing gradients of s0 op s1 with broadcast.
		/// </summary>
		/// <param name="s0">
		/// </param>
		/// <param name="s1">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'BroadcastGradientArgs'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   r0: 
		///   r1: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This is typically used by gradient computations for a broadcasting operation.
		/// </remarks>
		public (TFOutput r0, TFOutput r1) BroadcastGradientArgs (TFOutput s0, TFOutput s1, string operName = null)
		{
			var desc = new TFOperationDesc (this, "BroadcastGradientArgs", MakeName ("BroadcastGradientArgs", operName));
			desc.AddInput (s0);
			desc.AddInput (s1);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var r0 = new TFOutput (op, _idx++);
			var r1 = new TFOutput (op, _idx++);
			return (r0, r1);
		}

		/// <summary>
		///   Bucketizes 'input' based on 'boundaries'.
		/// </summary>
		/// <param name="input">
		///   Any shape of Tensor contains with int or float type.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Bucketize'.
		/// </param>
		/// <param name="boundaries">
		///   A sorted list of floats gives the boundary of the buckets.
		/// </param>
		/// <returns>
		///   Same shape with 'input', each value of input replaced with bucket index.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.digitize.
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For example, if the inputs are
		///       boundaries = [0, 10, 100]
		///       input = [[-5, 10000]
		///                [150,   10]
		///                [5,    100]]
		///   
		///   then the output will be
		///       output = [[0, 3]
		///                 [3, 2]
		///                 [1, 3]]
		/// </remarks>
		public TFOutput Bucketize (TFOutput input, float[] boundaries, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Bucketize", MakeName ("Bucketize", operName));
			desc.AddInput (input);
			desc.SetAttr ("boundaries", boundaries);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Cast x of type SrcT to y of DstT.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cast'.
		/// </param>
		/// <param name="DstT">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Cast (TFOutput x, TFDataType DstT, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cast", MakeName ("Cast", operName));
			desc.AddInput (x);
			desc.SetAttrType ("DstT", DstT);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns element-wise smallest integer in not less than x.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Ceil'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Ceil (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Ceil", MakeName ("Ceil", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Checks a tensor for NaN and Inf values.
		/// </summary>
		/// <param name="tensor">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CheckNumerics'.
		/// </param>
		/// <param name="message">
		///   Prefix of the error message.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   When run, reports an `InvalidArgument` error if `tensor` has any values
		///   that are not a number (NaN) or infinity (Inf). Otherwise, passes `tensor` as-is.
		/// </remarks>
		public TFOutput CheckNumerics (TFOutput tensor, string message, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CheckNumerics", MakeName ("CheckNumerics", operName));
			desc.AddInput (tensor);
			desc.SetAttr ("message", message);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the Cholesky decomposition of one or more square matrices.
		/// </summary>
		/// <param name="input">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cholesky'.
		/// </param>
		/// <returns>
		///   Shape is `[..., M, M]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The input is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions
		///   form square matrices, with the same constraints as the single matrix Cholesky
		///   decomposition above. The output is a tensor of the same shape as the input
		///   containing the Cholesky decompositions for all input submatrices `[..., :, :]`.
		/// </remarks>
		public TFOutput Cholesky (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cholesky", MakeName ("Cholesky", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the reverse mode backpropagated gradient of the Cholesky algorithm.
		/// </summary>
		/// <param name="l">
		///   Output of batch Cholesky algorithm l = cholesky(A). Shape is `[..., M, M]`.
		///   Algorithm depends only on lower triangular part of the innermost matrices of
		///   this tensor.
		/// </param>
		/// <param name="grad">
		///   df/dl where f is some scalar function. Shape is `[..., M, M]`.
		///   Algorithm depends only on lower triangular part of the innermost matrices of
		///   this tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CholeskyGrad'.
		/// </param>
		/// <returns>
		///   Symmetrized version of df/dA . Shape is `[..., M, M]`
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For an explanation see "Differentiation of the Cholesky algorithm" by
		///   Iain Murray http://arxiv.org/abs/1602.07527.
		/// </remarks>
		public TFOutput CholeskyGrad (TFOutput l, TFOutput grad, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CholeskyGrad", MakeName ("CholeskyGrad", operName));
			desc.AddInput (l);
			desc.AddInput (grad);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Converts two real numbers to a complex number.
		/// </summary>
		/// <param name="real">
		/// </param>
		/// <param name="imag">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Complex'.
		/// </param>
		/// <param name="Tout">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `real` representing the real part of a complex number, and a
		///   tensor `imag` representing the imaginary part of a complex number, this
		///   operation returns complex numbers elementwise of the form \\(a + bj\\), where
		///   *a* represents the `real` part and *b* represents the `imag` part.
		///   
		///   The input tensors `real` and `imag` must have the same shape.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'real' is [2.25, 3.25]
		///   # tensor `imag` is [4.75, 5.75]
		///   tf.complex(real, imag) ==&amp;gt; [[2.25 + 4.75j], [3.25 + 5.75j]]
		///   ```
		/// </remarks>
		public TFOutput Complex (TFOutput real, TFOutput imag, TFDataType? Tout = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Complex", MakeName ("Complex", operName));
			desc.AddInput (real);
			desc.AddInput (imag);
			if (Tout.HasValue)
				desc.SetAttrType ("Tout", Tout.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the complex absolute value of a tensor.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ComplexAbs'.
		/// </param>
		/// <param name="Tout">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `x` of complex numbers, this operation returns a tensor of type
		///   `float` or `double` that is the absolute value of each element in `x`. All
		///   elements in `x` must be complex numbers of the form \\(a + bj\\). The absolute
		///   value is computed as \\( \sqrt{a^2 + b^2}\\).
		/// </remarks>
		public TFOutput ComplexAbs (TFOutput x, TFDataType? Tout = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ComplexAbs", MakeName ("ComplexAbs", operName));
			desc.AddInput (x);
			if (Tout.HasValue)
				desc.SetAttrType ("Tout", Tout.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the ids of the positions in sampled_candidates that match true_labels.
		/// </summary>
		/// <param name="true_classes">
		///   The true_classes output of UnpackSparseLabels.
		/// </param>
		/// <param name="sampled_candidates">
		///   The sampled_candidates output of CandidateSampler.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ComputeAccidentalHits'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   indices: A vector of indices corresponding to rows of true_candidates.
		///   ids: A vector of IDs of positions in sampled_candidates that match a true_label
		///   for the row with the corresponding index in indices.
		///   weights: A vector of the same length as indices and ids, in which each element
		///   is -FLOAT_MAX.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   When doing log-odds NCE, the result of this op should be passed through a
		///   SparseToDense op, then added to the logits of the sampled candidates. This has
		///   the effect of 'removing' the sampled labels that match the true labels by
		///   making the classifier sure that they are sampled labels.
		/// </remarks>
		public (TFOutput indices, TFOutput ids, TFOutput weights) ComputeAccidentalHits (TFOutput true_classes, TFOutput sampled_candidates, long num_true, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ComputeAccidentalHits", MakeName ("ComputeAccidentalHits", operName));
			desc.AddInput (true_classes);
			desc.AddInput (sampled_candidates);
			desc.SetAttr ("num_true", num_true);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var indices = new TFOutput (op, _idx++);
			var ids = new TFOutput (op, _idx++);
			var weights = new TFOutput (op, _idx++);
			return (indices, ids, weights);
		}

		/// <summary>
		///   Concatenates tensors along one dimension.
		/// </summary>
		/// <param name="concat_dim">
		///   0-D.  The dimension along which to concatenate.  Must be in the
		///   range [0, rank(values)).
		/// </param>
		/// <param name="values">
		///   The `N` Tensors to concatenate. Their ranks and types must match,
		///   and their sizes must match in all dimensions except `concat_dim`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Concat'.
		/// </param>
		/// <returns>
		///   A `Tensor` with the concatenation of values stacked along the
		///   `concat_dim` dimension.  This tensor's shape matches that of `values` except
		///   in `concat_dim` where it has the sum of the sizes.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Concat (TFOutput concat_dim, TFOutput[] values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Concat", MakeName ("Concat", operName));
			desc.AddInput (concat_dim);
			desc.AddInputs (values);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes offsets of concat inputs within its output.
		/// </summary>
		/// <param name="concat_dim">
		///   The dimension along which to concatenate.
		/// </param>
		/// <param name="shape">
		///   The `N` int32 vectors representing shape of tensors being concatenated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ConcatOffset'.
		/// </param>
		/// <returns>
		///   The `N` int32 vectors representing the starting offset
		///   of input tensors within the concatenated output.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For example:
		///   
		///   ```
		///   # 'x' is [2, 2, 7]
		///   # 'y' is [2, 3, 7]
		///   # 'z' is [2, 5, 7]
		///   concat_offset(2, [x, y, z]) =&amp;gt; [0, 0, 0], [0, 2, 0], [0, 5, 0]
		///   ```
		///   
		///   This is typically used by gradient computations for a concat operation.
		/// </remarks>
		public TFOutput[] ConcatOffset (TFOutput concat_dim, TFOutput[] shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ConcatOffset", MakeName ("ConcatOffset", operName));
			desc.AddInput (concat_dim);
			desc.AddInputs (shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("offset");
			var offset = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				offset [i] = new TFOutput (op, _idx++);
			
			return offset;
		}

		/// <summary>
		///   Concatenates tensors along one dimension.
		/// </summary>
		/// <param name="values">
		///   List of `N` Tensors to concatenate. Their ranks and types must match,
		///   and their sizes must match in all dimensions except `concat_dim`.
		/// </param>
		/// <param name="axis">
		///   0-D.  The dimension along which to concatenate.  Must be in the
		///   range [-rank(values), rank(values)).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ConcatV2'.
		/// </param>
		/// <returns>
		///   A `Tensor` with the concatenation of values stacked along the
		///   `concat_dim` dimension.  This tensor's shape matches that of `values` except
		///   in `concat_dim` where it has the sum of the sizes.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ConcatV2 (TFOutput[] values, TFOutput axis, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ConcatV2", MakeName ("ConcatV2", operName));
			desc.AddInputs (values);
			desc.AddInput (axis);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the complex conjugate of a complex number.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conj'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input` of complex numbers, this operation returns a tensor of
		///   complex numbers that are the complex conjugate of each element in `input`. The
		///   complex numbers in `input` must be of the form \\(a + bj\\), where *a* is the
		///   real part and *b* is the imaginary part.
		///   
		///   The complex conjugate returned by this operation is of the form \\(a - bj\\).
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'input' is [-2.25 + 4.75j, 3.25 + 5.75j]
		///   tf.conj(input) ==&amp;gt; [-2.25 - 4.75j, 3.25 - 5.75j]
		///   ```
		/// </remarks>
		public TFOutput Conj (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conj", MakeName ("Conj", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns a constant tensor.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Const'.
		/// </param>
		/// <param name="value">
		///   Attr `value` is the tensor to return.
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Const (TFTensor value, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Const", MakeName ("Const", operName));
			desc.SetAttr ("value", value /* cstatus */);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Does nothing. Serves as a control trigger for scheduling.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ControlTrigger'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Only useful as a placeholder for control edges.
		/// </remarks>
		public TFOperation ControlTrigger (string operName = null)
		{
			var desc = new TFOperationDesc (this, "ControlTrigger", MakeName ("ControlTrigger", operName));
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Computes a 2-D convolution given 4-D `input` and `filter` tensors.
		/// </summary>
		/// <param name="input">
		///   A 4-D tensor. The dimension order is interpreted according to the value
		///   of `data_format`, see below for details.
		/// </param>
		/// <param name="filter">
		///   A 4-D tensor of shape
		///   `[filter_height, filter_width, in_channels, out_channels]`
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv2D'.
		/// </param>
		/// <param name="use_cudnn_on_gpu">
		///   Optional argument
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, height, width, channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, channels, height, width].
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 4.  The stride of the sliding window for each
		///   dimension of `input`. The dimension order is determined by the value of
		///     `data_format`, see below for details.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   A 4-D tensor. The dimension order is determined by the value of
		///   `data_format`, see below for details.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given an input tensor of shape `[batch, in_height, in_width, in_channels]`
		///   and a filter / kernel tensor of shape
		///   `[filter_height, filter_width, in_channels, out_channels]`, this op
		///   performs the following:
		///   
		///   1. Flattens the filter to a 2-D matrix with shape
		///      `[filter_height * filter_width * in_channels, output_channels]`.
		///   2. Extracts image patches from the input tensor to form a *virtual*
		///      tensor of shape `[batch, out_height, out_width,
		///      filter_height * filter_width * in_channels]`.
		///   3. For each patch, right-multiplies the filter matrix and the image patch
		///      vector.
		///   
		///   In detail, with the default NHWC format,
		///   
		///       output[b, i, j, k] =
		///           sum_{di, dj, q} input[b, strides[1] * i + di, strides[2] * j + dj, q] *
		///                           filter[di, dj, q, k]
		///   
		///   Must have `strides[0] = strides[3] = 1`.  For the most common case of the same
		///   horizontal and vertices strides, `strides = [1, stride, stride, 1]`.
		/// </remarks>
		public TFOutput Conv2D (TFOutput input, TFOutput filter, long[] strides, string padding, bool? use_cudnn_on_gpu = null, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv2D", MakeName ("Conv2D", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (use_cudnn_on_gpu.HasValue)
				desc.SetAttr ("use_cudnn_on_gpu", use_cudnn_on_gpu.Value);
			
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of convolution with respect to the filter.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, in_channels]`.
		/// </param>
		/// <param name="filter_sizes">
		///   An integer vector representing the tensor shape of `filter`,
		///   where `filter` is a 4-D
		///   `[filter_height, filter_width, in_channels, out_channels]` tensor.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, out_height, out_width, out_channels]`.
		///   Gradients w.r.t. the output of the convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv2DBackpropFilter'.
		/// </param>
		/// <param name="use_cudnn_on_gpu">
		///   Optional argument
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   of the convolution. Must be in the same order as the dimension specified with
		///   format.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, out_channels]`.  Gradient w.r.t.
		///   the `filter` input of the convolution.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv2DBackpropFilter (TFOutput input, TFOutput filter_sizes, TFOutput out_backprop, long[] strides, string padding, bool? use_cudnn_on_gpu = null, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv2DBackpropFilter", MakeName ("Conv2DBackpropFilter", operName));
			desc.AddInput (input);
			desc.AddInput (filter_sizes);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (use_cudnn_on_gpu.HasValue)
				desc.SetAttr ("use_cudnn_on_gpu", use_cudnn_on_gpu.Value);
			
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of convolution with respect to the input.
		/// </summary>
		/// <param name="input_sizes">
		///   An integer vector representing the shape of `input`,
		///   where `input` is a 4-D `[batch, height, width, channels]` tensor.
		/// </param>
		/// <param name="filter">
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, out_channels]`.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, out_height, out_width, out_channels]`.
		///   Gradients w.r.t. the output of the convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv2DBackpropInput'.
		/// </param>
		/// <param name="use_cudnn_on_gpu">
		///   Optional argument
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   of the convolution. Must be in the same order as the dimension specified with
		///   format.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, in_height, in_width, in_channels]`.  Gradient
		///   w.r.t. the input of the convolution.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv2DBackpropInput (TFOutput input_sizes, TFOutput filter, TFOutput out_backprop, long[] strides, string padding, bool? use_cudnn_on_gpu = null, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv2DBackpropInput", MakeName ("Conv2DBackpropInput", operName));
			desc.AddInput (input_sizes);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (use_cudnn_on_gpu.HasValue)
				desc.SetAttr ("use_cudnn_on_gpu", use_cudnn_on_gpu.Value);
			
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes a 3-D convolution given 5-D `input` and `filter` tensors.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, in_depth, in_height, in_width, in_channels]`.
		/// </param>
		/// <param name="filter">
		///   Shape `[filter_depth, filter_height, filter_width, in_channels,
		///   out_channels]`. `in_channels` must match between `input` and `filter`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv3D'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   In signal processing, cross-correlation is a measure of similarity of
		///   two waveforms as a function of a time-lag applied to one of them. This
		///   is also known as a sliding dot product or sliding inner-product.
		///   
		///   Our Conv3D implements a form of cross-correlation.
		/// </remarks>
		public TFOutput Conv3D (TFOutput input, TFOutput filter, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv3D", MakeName ("Conv3D", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of 3-D convolution with respect to the filter.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, depth, rows, cols, in_channels]`.
		/// </param>
		/// <param name="filter">
		///   Shape `[depth, rows, cols, in_channels, out_channels]`.
		///   `in_channels` must match between `input` and `filter`.
		/// </param>
		/// <param name="out_backprop">
		///   Backprop signal of shape `[batch, out_depth, out_rows, out_cols,
		///   out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv3DBackpropFilter'.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv3DBackpropFilter (TFOutput input, TFOutput filter, TFOutput out_backprop, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv3DBackpropFilter", MakeName ("Conv3DBackpropFilter", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of 3-D convolution with respect to the filter.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, depth, rows, cols, in_channels]`.
		/// </param>
		/// <param name="filter_sizes">
		///   An integer vector representing the tensor shape of `filter`,
		///   where `filter` is a 5-D
		///   `[filter_depth, filter_height, filter_width, in_channels, out_channels]`
		///   tensor.
		/// </param>
		/// <param name="out_backprop">
		///   Backprop signal of shape `[batch, out_depth, out_rows, out_cols,
		///   out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv3DBackpropFilterV2'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv3DBackpropFilterV2 (TFOutput input, TFOutput filter_sizes, TFOutput out_backprop, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv3DBackpropFilterV2", MakeName ("Conv3DBackpropFilterV2", operName));
			desc.AddInput (input);
			desc.AddInput (filter_sizes);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of 3-D convolution with respect to the input.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, depth, rows, cols, in_channels]`.
		/// </param>
		/// <param name="filter">
		///   Shape `[depth, rows, cols, in_channels, out_channels]`.
		///   `in_channels` must match between `input` and `filter`.
		/// </param>
		/// <param name="out_backprop">
		///   Backprop signal of shape `[batch, out_depth, out_rows, out_cols,
		///   out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv3DBackpropInput'.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv3DBackpropInput (TFOutput input, TFOutput filter, TFOutput out_backprop, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv3DBackpropInput", MakeName ("Conv3DBackpropInput", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of 3-D convolution with respect to the input.
		/// </summary>
		/// <param name="input_sizes">
		///   An integer vector representing the tensor shape of `input`,
		///   where `input` is a 5-D
		///   `[batch, depth, rows, cols, in_channels]` tensor.
		/// </param>
		/// <param name="filter">
		///   Shape `[depth, rows, cols, in_channels, out_channels]`.
		///   `in_channels` must match between `input` and `filter`.
		/// </param>
		/// <param name="out_backprop">
		///   Backprop signal of shape `[batch, out_depth, out_rows, out_cols,
		///   out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Conv3DBackpropInputV2'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Conv3DBackpropInputV2 (TFOutput input_sizes, TFOutput filter, TFOutput out_backprop, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Conv3DBackpropInputV2", MakeName ("Conv3DBackpropInputV2", operName));
			desc.AddInput (input_sizes);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes cos of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cos'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Cos (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cos", MakeName ("Cos", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Extracts crops from the input image tensor and bilinearly resizes them (possibly
		/// </summary>
		/// <param name="image">
		///   A 4-D tensor of shape `[batch, image_height, image_width, depth]`.
		///   Both `image_height` and `image_width` need to be positive.
		/// </param>
		/// <param name="boxes">
		///   A 2-D tensor of shape `[num_boxes, 4]`. The `i`-th row of the tensor
		///   specifies the coordinates of a box in the `box_ind[i]` image and is specified
		///   in normalized coordinates `[y1, x1, y2, x2]`. A normalized coordinate value of
		///   `y` is mapped to the image coordinate at `y * (image_height - 1)`, so as the
		///   `[0, 1]` interval of normalized image height is mapped to
		///   `[0, image_height - 1] in image height coordinates. We do allow y1 &amp;gt; y2, in
		///   which case the sampled crop is an up-down flipped version of the original
		///   image. The width dimension is treated similarly. Normalized coordinates
		///   outside the `[0, 1]` range are allowed, in which case we use
		///   `extrapolation_value` to extrapolate the input image values.
		/// </param>
		/// <param name="box_ind">
		///   A 1-D tensor of shape `[num_boxes]` with int32 values in `[0, batch)`.
		///   The value of `box_ind[i]` specifies the image that the `i`-th box refers to.
		/// </param>
		/// <param name="crop_size">
		///   A 1-D tensor of 2 elements, `size = [crop_height, crop_width]`. All
		///   cropped image patches are resized to this size. The aspect ratio of the image
		///   content is not preserved. Both `crop_height` and `crop_width` need to be
		///   positive.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CropAndResize'.
		/// </param>
		/// <param name="method">
		///   Optional argument
		///   A string specifying the interpolation method. Only 'bilinear' is
		///   supported for now.
		/// </param>
		/// <param name="extrapolation_value">
		///   Optional argument
		///   Value used for extrapolation, when applicable.
		/// </param>
		/// <returns>
		///   A 4-D tensor of shape `[num_boxes, crop_height, crop_width, depth]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   with aspect ratio change) to a common output size specified by `crop_size`. This
		///   is more general than the `crop_to_bounding_box` op which extracts a fixed size
		///   slice from the input image and does not allow resizing or aspect ratio change.
		///   
		///   Returns a tensor with `crops` from the input `image` at positions defined at the
		///   bounding box locations in `boxes`. The cropped boxes are all resized (with
		///   bilinear interpolation) to a fixed `size = [crop_height, crop_width]`. The
		///   result is a 4-D tensor `[num_boxes, crop_height, crop_width, depth]`.
		/// </remarks>
		public TFOutput CropAndResize (TFOutput image, TFOutput boxes, TFOutput box_ind, TFOutput crop_size, string method = null, float? extrapolation_value = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CropAndResize", MakeName ("CropAndResize", operName));
			desc.AddInput (image);
			desc.AddInput (boxes);
			desc.AddInput (box_ind);
			desc.AddInput (crop_size);
			if (method != null)
				desc.SetAttr ("method", method);
			
			if (extrapolation_value.HasValue)
				desc.SetAttr ("extrapolation_value", extrapolation_value.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var crops = new TFOutput (op, _idx++);
			return crops;
		}

		/// <summary>
		///   Computes the gradient of the crop_and_resize op wrt the input boxes tensor.
		/// </summary>
		/// <param name="grads">
		///   A 4-D tensor of shape `[num_boxes, crop_height, crop_width, depth]`.
		/// </param>
		/// <param name="image">
		///   A 4-D tensor of shape `[batch, image_height, image_width, depth]`.
		///   Both `image_height` and `image_width` need to be positive.
		/// </param>
		/// <param name="boxes">
		///   A 2-D tensor of shape `[num_boxes, 4]`. The `i`-th row of the tensor
		///   specifies the coordinates of a box in the `box_ind[i]` image and is specified
		///   in normalized coordinates `[y1, x1, y2, x2]`. A normalized coordinate value of
		///   `y` is mapped to the image coordinate at `y * (image_height - 1)`, so as the
		///   `[0, 1]` interval of normalized image height is mapped to
		///   `[0, image_height - 1] in image height coordinates. We do allow y1 &amp;gt; y2, in
		///   which case the sampled crop is an up-down flipped version of the original
		///   image. The width dimension is treated similarly. Normalized coordinates
		///   outside the `[0, 1]` range are allowed, in which case we use
		///   `extrapolation_value` to extrapolate the input image values.
		/// </param>
		/// <param name="box_ind">
		///   A 1-D tensor of shape `[num_boxes]` with int32 values in `[0, batch)`.
		///   The value of `box_ind[i]` specifies the image that the `i`-th box refers to.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CropAndResizeGradBoxes'.
		/// </param>
		/// <param name="method">
		///   Optional argument
		///   A string specifying the interpolation method. Only 'bilinear' is
		///   supported for now.
		/// </param>
		/// <returns>
		///   A 2-D tensor of shape `[num_boxes, 4]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput CropAndResizeGradBoxes (TFOutput grads, TFOutput image, TFOutput boxes, TFOutput box_ind, string method = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CropAndResizeGradBoxes", MakeName ("CropAndResizeGradBoxes", operName));
			desc.AddInput (grads);
			desc.AddInput (image);
			desc.AddInput (boxes);
			desc.AddInput (box_ind);
			if (method != null)
				desc.SetAttr ("method", method);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradient of the crop_and_resize op wrt the input image tensor.
		/// </summary>
		/// <param name="grads">
		///   A 4-D tensor of shape `[num_boxes, crop_height, crop_width, depth]`.
		/// </param>
		/// <param name="boxes">
		///   A 2-D tensor of shape `[num_boxes, 4]`. The `i`-th row of the tensor
		///   specifies the coordinates of a box in the `box_ind[i]` image and is specified
		///   in normalized coordinates `[y1, x1, y2, x2]`. A normalized coordinate value of
		///   `y` is mapped to the image coordinate at `y * (image_height - 1)`, so as the
		///   `[0, 1]` interval of normalized image height is mapped to
		///   `[0, image_height - 1] in image height coordinates. We do allow y1 &amp;gt; y2, in
		///   which case the sampled crop is an up-down flipped version of the original
		///   image. The width dimension is treated similarly. Normalized coordinates
		///   outside the `[0, 1]` range are allowed, in which case we use
		///   `extrapolation_value` to extrapolate the input image values.
		/// </param>
		/// <param name="box_ind">
		///   A 1-D tensor of shape `[num_boxes]` with int32 values in `[0, batch)`.
		///   The value of `box_ind[i]` specifies the image that the `i`-th box refers to.
		/// </param>
		/// <param name="image_size">
		///   A 1-D tensor with value `[batch, image_height, image_width, depth]`
		///   containing the original image size. Both `image_height` and `image_width` need
		///   to be positive.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CropAndResizeGradImage'.
		/// </param>
		/// <param name="method">
		///   Optional argument
		///   A string specifying the interpolation method. Only 'bilinear' is
		///   supported for now.
		/// </param>
		/// <param name="T">
		/// </param>
		/// <returns>
		///   A 4-D tensor of shape `[batch, image_height, image_width, depth]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput CropAndResizeGradImage (TFOutput grads, TFOutput boxes, TFOutput box_ind, TFOutput image_size, TFDataType T, string method = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CropAndResizeGradImage", MakeName ("CropAndResizeGradImage", operName));
			desc.AddInput (grads);
			desc.AddInput (boxes);
			desc.AddInput (box_ind);
			desc.AddInput (image_size);
			desc.SetAttrType ("T", T);
			if (method != null)
				desc.SetAttr ("method", method);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Compute the pairwise cross product.
		/// </summary>
		/// <param name="a">
		///   A tensor containing 3-element vectors.
		/// </param>
		/// <param name="b">
		///   Another tensor, of same type and shape as `a`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cross'.
		/// </param>
		/// <returns>
		///   Pairwise cross product of the vectors in `a` and `b`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `a` and `b` must be the same shape; they can either be simple 3-element vectors,
		///   or any shape where the innermost dimension is 3. In the latter case, each pair
		///   of corresponding 3-element vectors is cross-multiplied independently.
		/// </remarks>
		public TFOutput Cross (TFOutput a, TFOutput b, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cross", MakeName ("Cross", operName));
			desc.AddInput (a);
			desc.AddInput (b);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var product = new TFOutput (op, _idx++);
			return product;
		}

		/// <summary>
		///   Performs beam search decoding on the logits given in input.
		/// </summary>
		/// <param name="inputs">
		///   3-D, shape: `(max_time x batch_size x num_classes)`, the logits.
		/// </param>
		/// <param name="sequence_length">
		///   A vector containing sequence lengths, size `(batch)`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CTCBeamSearchDecoder'.
		/// </param>
		/// <param name="merge_repeated">
		///   Optional argument
		///   If true, merge repeated classes in output.
		/// </param>
		/// <param name="beam_width">
		///   A scalar &amp;gt;= 0 (beam search beam width).
		/// </param>
		/// <param name="top_paths">
		///   A scalar &amp;gt;= 0, &amp;lt;= beam_width (controls output size).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   decoded_indices: A list (length: top_paths) of indices matrices.  Matrix j,
		///   size `(total_decoded_outputs[j] x 2)`, has indices of a
		///   `SparseTensor&amp;lt;int64, 2&amp;gt;`.  The rows store: [batch, time].
		///   decoded_values: A list (length: top_paths) of values vectors.  Vector j,
		///   size `(length total_decoded_outputs[j])`, has the values of a
		///   `SparseTensor&amp;lt;int64, 2&amp;gt;`.  The vector stores the decoded classes for beam j.
		///   decoded_shape: A list (length: top_paths) of shape vector.  Vector j,
		///   size `(2)`, stores the shape of the decoded `SparseTensor[j]`.
		///   Its values are: `[batch_size, max_decoded_length[j]]`.
		///   log_probability: A matrix, shaped: `(batch_size x top_paths)`.  The
		///   sequence log-probabilities.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   A note about the attribute merge_repeated: For the beam search decoder,
		///   this means that if consecutive entries in a beam are the same, only
		///   the first of these is emitted.  That is, when the top path is "A B B B B",
		///   "A B" is returned if merge_repeated = True but "A B B B B" is
		///   returned if merge_repeated = False.
		/// </remarks>
		public (TFOutput[] decoded_indices, TFOutput[] decoded_values, TFOutput[] decoded_shape, TFOutput log_probability) CTCBeamSearchDecoder (TFOutput inputs, TFOutput sequence_length, long beam_width, long top_paths, bool? merge_repeated = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CTCBeamSearchDecoder", MakeName ("CTCBeamSearchDecoder", operName));
			desc.AddInput (inputs);
			desc.AddInput (sequence_length);
			desc.SetAttr ("beam_width", beam_width);
			desc.SetAttr ("top_paths", top_paths);
			if (merge_repeated.HasValue)
				desc.SetAttr ("merge_repeated", merge_repeated.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("decoded_indices");
			var decoded_indices = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				decoded_indices [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("decoded_values");
			var decoded_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				decoded_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("decoded_shape");
			var decoded_shape = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				decoded_shape [i] = new TFOutput (op, _idx++);
			
			var log_probability = new TFOutput (op, _idx++);
			return (decoded_indices, decoded_values, decoded_shape, log_probability);
		}

		/// <summary>
		///   Performs greedy decoding on the logits given in inputs.
		/// </summary>
		/// <param name="inputs">
		///   3-D, shape: `(max_time x batch_size x num_classes)`, the logits.
		/// </param>
		/// <param name="sequence_length">
		///   A vector containing sequence lengths, size `(batch_size)`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CTCGreedyDecoder'.
		/// </param>
		/// <param name="merge_repeated">
		///   Optional argument
		///   If True, merge repeated classes in output.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   decoded_indices: Indices matrix, size `(total_decoded_outputs x 2)`,
		///   of a `SparseTensor&amp;lt;int64, 2&amp;gt;`.  The rows store: [batch, time].
		///   decoded_values: Values vector, size: `(total_decoded_outputs)`,
		///   of a `SparseTensor&amp;lt;int64, 2&amp;gt;`.  The vector stores the decoded classes.
		///   decoded_shape: Shape vector, size `(2)`, of the decoded SparseTensor.
		///   Values are: `[batch_size, max_decoded_length]`.
		///   log_probability: Matrix, size `(batch_size x 1)`, containing sequence
		///   log-probabilities.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   A note about the attribute merge_repeated: if enabled, when
		///   consecutive logits' maximum indices are the same, only the first of
		///   these is emitted.  Labeling the blank '*', the sequence "A B B * B B"
		///   becomes "A B B" if merge_repeated = True and "A B B B B" if
		///   merge_repeated = False.
		///   
		///   Regardless of the value of merge_repeated, if the maximum index of a given
		///   time and batch corresponds to the blank, index `(num_classes - 1)`, no new
		///   element is emitted.
		/// </remarks>
		public (TFOutput decoded_indices, TFOutput decoded_values, TFOutput decoded_shape, TFOutput log_probability) CTCGreedyDecoder (TFOutput inputs, TFOutput sequence_length, bool? merge_repeated = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CTCGreedyDecoder", MakeName ("CTCGreedyDecoder", operName));
			desc.AddInput (inputs);
			desc.AddInput (sequence_length);
			if (merge_repeated.HasValue)
				desc.SetAttr ("merge_repeated", merge_repeated.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var decoded_indices = new TFOutput (op, _idx++);
			var decoded_values = new TFOutput (op, _idx++);
			var decoded_shape = new TFOutput (op, _idx++);
			var log_probability = new TFOutput (op, _idx++);
			return (decoded_indices, decoded_values, decoded_shape, log_probability);
		}

		/// <summary>
		///   Calculates the CTC Loss (log probability) for each batch entry.  Also calculates
		/// </summary>
		/// <param name="inputs">
		///   3-D, shape: `(max_time x batch_size x num_classes)`, the logits.
		/// </param>
		/// <param name="labels_indices">
		///   The indices of a `SparseTensor&amp;lt;int32, 2&amp;gt;`.
		///   `labels_indices(i, :) == [b, t]` means `labels_values(i)` stores the id for
		///   `(batch b, time t)`.
		/// </param>
		/// <param name="labels_values">
		///   The values (labels) associated with the given batch and time.
		/// </param>
		/// <param name="sequence_length">
		///   A vector containing sequence lengths (batch).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'CTCLoss'.
		/// </param>
		/// <param name="preprocess_collapse_repeated">
		///   Optional argument
		///   Scalar, if true then repeated labels are
		///   collapsed prior to the CTC calculation.
		/// </param>
		/// <param name="ctc_merge_repeated">
		///   Optional argument
		///   Scalar.  If set to false, *during* CTC calculation
		///   repeated non-blank labels will not be merged and are interpreted as
		///   individual labels.  This is a simplified version of CTC.
		/// </param>
		/// <param name="ignore_longer_outputs_than_inputs">
		///   Optional argument
		///   Scalar. If set to true, during CTC
		///   calculation items have longer input sequences than output sequences
		///   are ignored by returning zero-gradient for those items.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   loss: A vector (batch) containing log-probabilities.
		///   gradient: The gradient of `loss`.  3-D, shape:
		///   `(max_time x batch_size x num_classes)`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   the gradient.  This class performs the softmax operation for you, so inputs
		///   should be e.g. linear projections of outputs by an LSTM.
		/// </remarks>
		public (TFOutput loss, TFOutput gradient) CTCLoss (TFOutput inputs, TFOutput labels_indices, TFOutput labels_values, TFOutput sequence_length, bool? preprocess_collapse_repeated = null, bool? ctc_merge_repeated = null, bool? ignore_longer_outputs_than_inputs = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "CTCLoss", MakeName ("CTCLoss", operName));
			desc.AddInput (inputs);
			desc.AddInput (labels_indices);
			desc.AddInput (labels_values);
			desc.AddInput (sequence_length);
			if (preprocess_collapse_repeated.HasValue)
				desc.SetAttr ("preprocess_collapse_repeated", preprocess_collapse_repeated.Value);
			
			if (ctc_merge_repeated.HasValue)
				desc.SetAttr ("ctc_merge_repeated", ctc_merge_repeated.Value);
			
			if (ignore_longer_outputs_than_inputs.HasValue)
				desc.SetAttr ("ignore_longer_outputs_than_inputs", ignore_longer_outputs_than_inputs.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var loss = new TFOutput (op, _idx++);
			var gradient = new TFOutput (op, _idx++);
			return (loss, gradient);
		}

		/// <summary>
		///   Compute the cumulative product of the tensor `x` along `axis`.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="axis">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cumprod'.
		/// </param>
		/// <param name="exclusive">
		///   Optional argument
		/// </param>
		/// <param name="reverse">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   By default, this op performs an inclusive cumprod, which means that the first
		///   element of the input is identical to the first element of the output:
		///   ```prettyprint
		///   tf.cumprod([a, b, c]) ==&amp;gt; [a, a * b, a * b * c]
		///   ```
		///   
		///   By setting the `exclusive` kwarg to `True`, an exclusive cumprod is
		///   performed instead:
		///   ```prettyprint
		///   tf.cumprod([a, b, c], exclusive=True) ==&amp;gt; [1, a, a * b]
		///   ```
		///   
		///   By setting the `reverse` kwarg to `True`, the cumprod is performed in the
		///   opposite direction:
		///   ```prettyprint
		///   tf.cumprod([a, b, c], reverse=True) ==&amp;gt; [a * b * c, b * c, c]
		///   ```
		///   This is more efficient than using separate `tf.reverse` ops.
		///   
		///   The `reverse` and `exclusive` kwargs can also be combined:
		///   ```prettyprint
		///   tf.cumprod([a, b, c], exclusive=True, reverse=True) ==&amp;gt; [b * c, c, 1]
		///   ```
		/// </remarks>
		public TFOutput Cumprod (TFOutput x, TFOutput axis, bool? exclusive = null, bool? reverse = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cumprod", MakeName ("Cumprod", operName));
			desc.AddInput (x);
			desc.AddInput (axis);
			if (exclusive.HasValue)
				desc.SetAttr ("exclusive", exclusive.Value);
			
			if (reverse.HasValue)
				desc.SetAttr ("reverse", reverse.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Compute the cumulative sum of the tensor `x` along `axis`.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="axis">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Cumsum'.
		/// </param>
		/// <param name="exclusive">
		///   Optional argument
		/// </param>
		/// <param name="reverse">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   By default, this op performs an inclusive cumsum, which means that the first
		///   element of the input is identical to the first element of the output:
		///   ```prettyprint
		///   tf.cumsum([a, b, c]) ==&amp;gt; [a, a + b, a + b + c]
		///   ```
		///   
		///   By setting the `exclusive` kwarg to `True`, an exclusive cumsum is
		///   performed instead:
		///   ```prettyprint
		///   tf.cumsum([a, b, c], exclusive=True) ==&amp;gt; [0, a, a + b]
		///   ```
		///   
		///   By setting the `reverse` kwarg to `True`, the cumsum is performed in the
		///   opposite direction:
		///   ```prettyprint
		///   tf.cumsum([a, b, c], reverse=True) ==&amp;gt; [a + b + c, b + c, c]
		///   ```
		///   This is more efficient than using separate `tf.reverse` ops.
		///   
		///   The `reverse` and `exclusive` kwargs can also be combined:
		///   ```prettyprint
		///   tf.cumsum([a, b, c], exclusive=True, reverse=True) ==&amp;gt; [b + c, c, 0]
		///   ```
		/// </remarks>
		public TFOutput Cumsum (TFOutput x, TFOutput axis, bool? exclusive = null, bool? reverse = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Cumsum", MakeName ("Cumsum", operName));
			desc.AddInput (x);
			desc.AddInput (axis);
			if (exclusive.HasValue)
				desc.SetAttr ("exclusive", exclusive.Value);
			
			if (reverse.HasValue)
				desc.SetAttr ("reverse", reverse.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Decode web-safe base64-encoded strings.
		/// </summary>
		/// <param name="input">
		///   Base64 strings to decode.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeBase64'.
		/// </param>
		/// <returns>
		///   Decoded strings.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Input may or may not have padding at the end. See EncodeBase64 for padding.
		///   Web-safe means that input must use - and _ instead of + and /.
		/// </remarks>
		public TFOutput DecodeBase64 (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeBase64", MakeName ("DecodeBase64", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Decode the first frame of a BMP-encoded image to a uint8 tensor.
		/// </summary>
		/// <param name="contents">
		///   0-D.  The BMP-encoded image.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeBmp'.
		/// </param>
		/// <param name="channels">
		///   Optional argument
		/// </param>
		/// <returns>
		///   3-D with shape `[height, width, channels]`. RGB order
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The attr `channels` indicates the desired number of color channels for the
		///   decoded image.
		///   
		///   Accepted values are:
		///   
		///   *   0: Use the number of channels in the BMP-encoded image.
		///   *   3: output an RGB image.
		///   *   4: output an RGBA image.
		/// </remarks>
		public TFOutput DecodeBmp (TFOutput contents, long? channels = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeBmp", MakeName ("DecodeBmp", operName));
			desc.AddInput (contents);
			if (channels.HasValue)
				desc.SetAttr ("channels", channels.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var image = new TFOutput (op, _idx++);
			return image;
		}

		/// <summary>
		///   Convert CSV records to tensors. Each column maps to one tensor.
		/// </summary>
		/// <param name="records">
		///   Each string is a record/row in the csv and all records should have
		///   the same format.
		/// </param>
		/// <param name="record_defaults">
		///   One tensor per column of the input record, with either a
		///   scalar default value for that column or empty if the column is required.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeCSV'.
		/// </param>
		/// <param name="field_delim">
		///   Optional argument
		///   delimiter to separate fields in a record.
		/// </param>
		/// <returns>
		///   Each tensor will have the same shape as records.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   RFC 4180 format is expected for the CSV records.
		///   (https://tools.ietf.org/html/rfc4180)
		///   Note that we allow leading and trailing spaces with int or float field.
		/// </remarks>
		public TFOutput[] DecodeCSV (TFOutput records, TFOutput[] record_defaults, string field_delim = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeCSV", MakeName ("DecodeCSV", operName));
			desc.AddInput (records);
			desc.AddInputs (record_defaults);
			if (field_delim != null)
				desc.SetAttr ("field_delim", field_delim);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output");
			var output = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output [i] = new TFOutput (op, _idx++);
			
			return output;
		}

		/// <summary>
		///   Decode the first frame of a GIF-encoded image to a uint8 tensor.
		/// </summary>
		/// <param name="contents">
		///   0-D.  The GIF-encoded image.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeGif'.
		/// </param>
		/// <returns>
		///   4-D with shape `[num_frames, height, width, 3]`. RGB order
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   GIF with frame or transparency compression are not supported
		///   convert animated GIF from compressed to uncompressed by:
		///   
		///       convert $src.gif -coalesce $dst.gif
		///   
		///   This op also supports decoding JPEGs and PNGs, though it is cleaner to use
		///   `tf.image.decode_image`.
		/// </remarks>
		public TFOutput DecodeGif (TFOutput contents, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeGif", MakeName ("DecodeGif", operName));
			desc.AddInput (contents);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var image = new TFOutput (op, _idx++);
			return image;
		}

		/// <summary>
		///   Decode a JPEG-encoded image to a uint8 tensor.
		/// </summary>
		/// <param name="contents">
		///   0-D.  The JPEG-encoded image.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeJpeg'.
		/// </param>
		/// <param name="channels">
		///   Optional argument
		///   Number of color channels for the decoded image.
		/// </param>
		/// <param name="ratio">
		///   Optional argument
		///   Downscaling ratio.
		/// </param>
		/// <param name="fancy_upscaling">
		///   Optional argument
		///   If true use a slower but nicer upscaling of the
		///   chroma planes (yuv420/422 only).
		/// </param>
		/// <param name="try_recover_truncated">
		///   Optional argument
		///   If true try to recover an image from truncated input.
		/// </param>
		/// <param name="acceptable_fraction">
		///   Optional argument
		///   The minimum required fraction of lines before a truncated
		///   input is accepted.
		/// </param>
		/// <param name="dct_method">
		///   Optional argument
		///   string specifying a hint about the algorithm used for
		///   decompression.  Defaults to "" which maps to a system-specific
		///   default.  Currently valid values are ["INTEGER_FAST",
		///   "INTEGER_ACCURATE"].  The hint may be ignored (e.g., the internal
		///   jpeg library changes to a version that does not have that specific
		///   option.)
		/// </param>
		/// <returns>
		///   3-D with shape `[height, width, channels]`..
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The attr `channels` indicates the desired number of color channels for the
		///   decoded image.
		///   
		///   Accepted values are:
		///   
		///   *   0: Use the number of channels in the JPEG-encoded image.
		///   *   1: output a grayscale image.
		///   *   3: output an RGB image.
		///   
		///   If needed, the JPEG-encoded image is transformed to match the requested number
		///   of color channels.
		///   
		///   The attr `ratio` allows downscaling the image by an integer factor during
		///   decoding.  Allowed values are: 1, 2, 4, and 8.  This is much faster than
		///   downscaling the image later.
		///   
		///   This op also supports decoding PNGs and non-animated GIFs since the interface is
		///   the same, though it is cleaner to use `tf.image.decode_image`.
		/// </remarks>
		public TFOutput DecodeJpeg (TFOutput contents, long? channels = null, long? ratio = null, bool? fancy_upscaling = null, bool? try_recover_truncated = null, float? acceptable_fraction = null, string dct_method = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeJpeg", MakeName ("DecodeJpeg", operName));
			desc.AddInput (contents);
			if (channels.HasValue)
				desc.SetAttr ("channels", channels.Value);
			
			if (ratio.HasValue)
				desc.SetAttr ("ratio", ratio.Value);
			
			if (fancy_upscaling.HasValue)
				desc.SetAttr ("fancy_upscaling", fancy_upscaling.Value);
			
			if (try_recover_truncated.HasValue)
				desc.SetAttr ("try_recover_truncated", try_recover_truncated.Value);
			
			if (acceptable_fraction.HasValue)
				desc.SetAttr ("acceptable_fraction", acceptable_fraction.Value);
			
			if (dct_method != null)
				desc.SetAttr ("dct_method", dct_method);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var image = new TFOutput (op, _idx++);
			return image;
		}

		/// <summary>
		///   Convert JSON-encoded Example records to binary protocol buffer strings.
		/// </summary>
		/// <param name="json_examples">
		///   Each string is a JSON object serialized according to the JSON
		///   mapping of the Example proto.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeJSONExample'.
		/// </param>
		/// <returns>
		///   Each string is a binary Example protocol buffer corresponding
		///   to the respective element of `json_examples`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op translates a tensor containing Example records, encoded using
		///   the [standard JSON
		///   mapping](https://developers.google.com/protocol-buffers/docs/proto3#json),
		///   into a tensor containing the same records encoded as binary protocol
		///   buffers. The resulting tensor can then be fed to any of the other
		///   Example-parsing ops.
		/// </remarks>
		public TFOutput DecodeJSONExample (TFOutput json_examples, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeJSONExample", MakeName ("DecodeJSONExample", operName));
			desc.AddInput (json_examples);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var binary_examples = new TFOutput (op, _idx++);
			return binary_examples;
		}

		/// <summary>
		///   Decode a PNG-encoded image to a uint8 or uint16 tensor.
		/// </summary>
		/// <param name="contents">
		///   0-D.  The PNG-encoded image.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodePng'.
		/// </param>
		/// <param name="channels">
		///   Optional argument
		///   Number of color channels for the decoded image.
		/// </param>
		/// <param name="dtype">
		///   Optional argument
		/// </param>
		/// <returns>
		///   3-D with shape `[height, width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The attr `channels` indicates the desired number of color channels for the
		///   decoded image.
		///   
		///   Accepted values are:
		///   
		///   *   0: Use the number of channels in the PNG-encoded image.
		///   *   1: output a grayscale image.
		///   *   3: output an RGB image.
		///   *   4: output an RGBA image.
		///   
		///   If needed, the PNG-encoded image is transformed to match the requested number
		///   of color channels.
		///   
		///   This op also supports decoding JPEGs and non-animated GIFs since the interface
		///   is the same, though it is cleaner to use `tf.image.decode_image`.
		/// </remarks>
		public TFOutput DecodePng (TFOutput contents, long? channels = null, TFDataType? dtype = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodePng", MakeName ("DecodePng", operName));
			desc.AddInput (contents);
			if (channels.HasValue)
				desc.SetAttr ("channels", channels.Value);
			
			if (dtype.HasValue)
				desc.SetAttrType ("dtype", dtype.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var image = new TFOutput (op, _idx++);
			return image;
		}

		/// <summary>
		///   Reinterpret the bytes of a string as a vector of numbers.
		/// </summary>
		/// <param name="bytes">
		///   All the elements must have the same length.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeRaw'.
		/// </param>
		/// <param name="little_endian">
		///   Optional argument
		///   Whether the input `bytes` are in little-endian order.
		///   Ignored for `out_type` values that are stored in a single byte like
		///   `uint8`.
		/// </param>
		/// <param name="out_type">
		/// </param>
		/// <returns>
		///   A Tensor with one more dimension than the input `bytes`.  The
		///   added dimension will have size equal to the length of the elements
		///   of `bytes` divided by the number of bytes to represent `out_type`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput DecodeRaw (TFOutput bytes, TFDataType out_type, bool? little_endian = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeRaw", MakeName ("DecodeRaw", operName));
			desc.AddInput (bytes);
			desc.SetAttrType ("out_type", out_type);
			if (little_endian.HasValue)
				desc.SetAttr ("little_endian", little_endian.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Decode a 16-bit PCM WAV file to a float tensor.
		/// </summary>
		/// <param name="contents">
		///   The WAV-encoded audio, usually from a file.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DecodeWav'.
		/// </param>
		/// <param name="desired_channels">
		///   Optional argument
		///   Number of sample channels wanted.
		/// </param>
		/// <param name="desired_samples">
		///   Optional argument
		///   Length of audio requested.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   audio: 2-D with shape `[length, channels]`.
		///   sample_rate: Scalar holding the sample rate found in the WAV header.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The -32768 to 32767 signed 16-bit values will be scaled to -1.0 to 1.0 in float.
		///   
		///   When desired_channels is set, if the input contains fewer channels than this
		///   then the last channel will be duplicated to give the requested number, else if
		///   the input has more channels than requested then the additional channels will be
		///   ignored.
		///   
		///   If desired_samples is set, then the audio will be cropped or padded with zeroes
		///   to the requested length.
		///   
		///   The first output contains a Tensor with the content of the audio samples. The
		///   lowest dimension will be the number of channels, and the second will be the
		///   number of samples. For example, a ten-sample-long stereo WAV file should give an
		///   output shape of [10, 2].
		/// </remarks>
		public (TFOutput audio, TFOutput sample_rate) DecodeWav (TFOutput contents, long? desired_channels = null, long? desired_samples = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DecodeWav", MakeName ("DecodeWav", operName));
			desc.AddInput (contents);
			if (desired_channels.HasValue)
				desc.SetAttr ("desired_channels", desired_channels.Value);
			
			if (desired_samples.HasValue)
				desc.SetAttr ("desired_samples", desired_samples.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var audio = new TFOutput (op, _idx++);
			var sample_rate = new TFOutput (op, _idx++);
			return (audio, sample_rate);
		}

		/// <summary>
		///   Delete the tensor specified by its handle in the session.
		/// </summary>
		/// <param name="handle">
		///   The handle for a tensor stored in the session state.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DeleteSessionTensor'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation DeleteSessionTensor (TFOutput handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DeleteSessionTensor", MakeName ("DeleteSessionTensor", operName));
			desc.AddInput (handle);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Applies set operation along last dimension of 2 `Tensor` inputs.
		/// </summary>
		/// <param name="set1">
		///   `Tensor` with rank `n`. 1st `n-1` dimensions must be the same as `set2`.
		///   Dimension `n` contains values in a set, duplicates are allowed but ignored.
		/// </param>
		/// <param name="set2">
		///   `Tensor` with rank `n`. 1st `n-1` dimensions must be the same as `set1`.
		///   Dimension `n` contains values in a set, duplicates are allowed but ignored.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DenseToDenseSetOperation'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <param name="set_operation">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   result_indices: 2D indices of a `SparseTensor`.
		///   result_values: 1D values of a `SparseTensor`.
		///   result_shape: 1D `Tensor` shape of a `SparseTensor`. `result_shape[0...n-1]` is
		///   the same as the 1st `n-1` dimensions of `set1` and `set2`, `result_shape[n]`
		///   is the max result set size across all `0...n-1` dimensions.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See SetOperationOp::SetOperationFromContext for values of `set_operation`.
		///   
		///   Output `result` is a `SparseTensor` represented by `result_indices`,
		///   `result_values`, and `result_shape`. For `set1` and `set2` ranked `n`, this
		///   has rank `n` and the same 1st `n-1` dimensions as `set1` and `set2`. The `nth`
		///   dimension contains the result of `set_operation` applied to the corresponding
		///   `[0...n-1]` dimension of `set`.
		/// </remarks>
		public (TFOutput result_indices, TFOutput result_values, TFOutput result_shape) DenseToDenseSetOperation (TFOutput set1, TFOutput set2, string set_operation, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DenseToDenseSetOperation", MakeName ("DenseToDenseSetOperation", operName));
			desc.AddInput (set1);
			desc.AddInput (set2);
			desc.SetAttr ("set_operation", set_operation);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var result_indices = new TFOutput (op, _idx++);
			var result_values = new TFOutput (op, _idx++);
			var result_shape = new TFOutput (op, _idx++);
			return (result_indices, result_values, result_shape);
		}

		/// <summary>
		///   Creates a dataset that yields a SparseTensor for each element of the input.
		/// </summary>
		/// <param name="input_dataset">
		///   A handle to an input dataset. Must have a single component.
		/// </param>
		/// <param name="batch_size">
		///   A scalar representing the number of elements to accumulate in a
		///   batch.
		/// </param>
		/// <param name="row_shape">
		///   A vector representing the dense shape of each row in the produced
		///   SparseTensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DenseToSparseBatchDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput DenseToSparseBatchDataset (TFOutput input_dataset, TFOutput batch_size, TFOutput row_shape, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DenseToSparseBatchDataset", MakeName ("DenseToSparseBatchDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (batch_size);
			desc.AddInput (row_shape);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Applies set operation along last dimension of `Tensor` and `SparseTensor`.
		/// </summary>
		/// <param name="set1">
		///   `Tensor` with rank `n`. 1st `n-1` dimensions must be the same as `set2`.
		///   Dimension `n` contains values in a set, duplicates are allowed but ignored.
		/// </param>
		/// <param name="set2_indices">
		///   2D `Tensor`, indices of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set2_values">
		///   1D `Tensor`, values of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set2_shape">
		///   1D `Tensor`, shape of a `SparseTensor`. `set2_shape[0...n-1]` must
		///   be the same as the 1st `n-1` dimensions of `set1`, `result_shape[n]` is the
		///   max set size across `n-1` dimensions.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DenseToSparseSetOperation'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <param name="set_operation">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   result_indices: 2D indices of a `SparseTensor`.
		///   result_values: 1D values of a `SparseTensor`.
		///   result_shape: 1D `Tensor` shape of a `SparseTensor`. `result_shape[0...n-1]` is
		///   the same as the 1st `n-1` dimensions of `set1` and `set2`, `result_shape[n]`
		///   is the max result set size across all `0...n-1` dimensions.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See SetOperationOp::SetOperationFromContext for values of `set_operation`.
		///   
		///   Input `set2` is a `SparseTensor` represented by `set2_indices`, `set2_values`,
		///   and `set2_shape`. For `set2` ranked `n`, 1st `n-1` dimensions must be the same
		///   as `set1`. Dimension `n` contains values in a set, duplicates are allowed but
		///   ignored.
		///   
		///   If `validate_indices` is `True`, this op validates the order and range of `set2`
		///   indices.
		///   
		///   Output `result` is a `SparseTensor` represented by `result_indices`,
		///   `result_values`, and `result_shape`. For `set1` and `set2` ranked `n`, this
		///   has rank `n` and the same 1st `n-1` dimensions as `set1` and `set2`. The `nth`
		///   dimension contains the result of `set_operation` applied to the corresponding
		///   `[0...n-1]` dimension of `set`.
		/// </remarks>
		public (TFOutput result_indices, TFOutput result_values, TFOutput result_shape) DenseToSparseSetOperation (TFOutput set1, TFOutput set2_indices, TFOutput set2_values, TFOutput set2_shape, string set_operation, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DenseToSparseSetOperation", MakeName ("DenseToSparseSetOperation", operName));
			desc.AddInput (set1);
			desc.AddInput (set2_indices);
			desc.AddInput (set2_values);
			desc.AddInput (set2_shape);
			desc.SetAttr ("set_operation", set_operation);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var result_indices = new TFOutput (op, _idx++);
			var result_values = new TFOutput (op, _idx++);
			var result_shape = new TFOutput (op, _idx++);
			return (result_indices, result_values, result_shape);
		}

		/// <summary>
		///   DepthToSpace for tensors of type T.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DepthToSpace'.
		/// </param>
		/// <param name="block_size">
		///   The size of the spatial block, same as in Space2Depth.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Rearranges data from depth into blocks of spatial data.
		///   This is the reverse transformation of SpaceToDepth. More specifically,
		///   this op outputs a copy of the input tensor where values from the `depth`
		///   dimension are moved in spatial blocks to the `height` and `width` dimensions.
		///   The attr `block_size` indicates the input block size and how the data is moved.
		///   
		///     * Chunks of data of size `block_size * block_size` from depth are rearranged
		///       into non-overlapping blocks of size `block_size x block_size`
		///     * The width the output tensor is `input_depth * block_size`, whereas the
		///       height is `input_height * block_size`.
		///     * The depth of the input tensor must be divisible by
		///       `block_size * block_size`.
		///   
		///   That is, assuming the input is in the shape:
		///   `[batch, height, width, depth]`,
		///   the shape of the output will be:
		///   `[batch, height*block_size, width*block_size, depth/(block_size*block_size)]`
		///   
		///   This operation requires that the input tensor be of rank 4, and that
		///   `block_size` be &amp;gt;=1 and that `block_size * block_size` be a divisor of the
		///   input depth.
		///   
		///   This operation is useful for resizing the activations between convolutions
		///   (but keeping all data), e.g. instead of pooling. It is also useful for training
		///   purely convolutional models.
		///   
		///   For example, given this input of shape `[1, 1, 1, 4]`, and a block size of 2:
		///   
		///   ```
		///   x = [[[[1, 2, 3, 4]]]]
		///   
		///   ```
		///   
		///   This operation will output a tensor of shape `[1, 2, 2, 1]`:
		///   
		///   ```
		///      [[[[1], [2]],
		///        [[3], [4]]]]
		///   ```
		///   
		///   Here, the input has a batch of 1 and each batch element has shape `[1, 1, 4]`,
		///   the corresponding output will have 2x2 elements and will have a depth of
		///   1 channel (1 = `4 / (block_size * block_size)`).
		///   The output element shape is `[2, 2, 1]`.
		///   
		///   For an input tensor with larger depth, here of shape `[1, 1, 1, 12]`, e.g.
		///   
		///   ```
		///   x = [[[[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]]]]
		///   ```
		///   
		///   This operation, for block size of 2, will return the following tensor of shape
		///   `[1, 2, 2, 3]`
		///   
		///   ```
		///      [[[[1, 2, 3], [4, 5, 6]],
		///        [[7, 8, 9], [10, 11, 12]]]]
		///   
		///   ```
		///   
		///   Similarly, for the following input of shape `[1 2 2 4]`, and a block size of 2:
		///   
		///   ```
		///   x =  [[[[1, 2, 3, 4],
		///          [5, 6, 7, 8]],
		///         [[9, 10, 11, 12],
		///          [13, 14, 15, 16]]]]
		///   ```
		///   
		///   the operator will return the following tensor of shape `[1 4 4 1]`:
		///   
		///   ```
		///   x = [[ [1],   [2],  [5],  [6]],
		///        [ [3],   [4],  [7],  [8]],
		///        [ [9],  [10], [13],  [14]],
		///        [ [11], [12], [15],  [16]]]
		///   
		///   ```
		/// </remarks>
		public TFOutput DepthToSpace (TFOutput input, long block_size, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DepthToSpace", MakeName ("DepthToSpace", operName));
			desc.AddInput (input);
			desc.SetAttr ("block_size", block_size);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes a 2-D depthwise convolution given 4-D `input` and `filter` tensors.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="filter">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DepthwiseConv2dNative'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, height, width, channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, channels, height, width].
		/// </param>
		/// <param name="strides">
		///   1-D of length 4.  The stride of the sliding window for each dimension
		///   of `input`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given an input tensor of shape `[batch, in_height, in_width, in_channels]`
		///   and a filter / kernel tensor of shape
		///   `[filter_height, filter_width, in_channels, channel_multiplier]`, containing
		///   `in_channels` convolutional filters of depth 1, `depthwise_conv2d` applies
		///   a different filter to each input channel (expanding from 1 channel to
		///   `channel_multiplier` channels for each), then concatenates the results
		///   together. Thus, the output has `in_channels * channel_multiplier` channels.
		///   
		///   for k in 0..in_channels-1
		///     for q in 0..channel_multiplier-1
		///       output[b, i, j, k * channel_multiplier + q] =
		///         sum_{di, dj} input[b, strides[1] * i + di, strides[2] * j + dj, k] *
		///                           filter[di, dj, k, q]
		///   
		///   Must have `strides[0] = strides[3] = 1`.  For the most common case of the same
		///   horizontal and vertices strides, `strides = [1, stride, stride, 1]`.
		/// </remarks>
		public TFOutput DepthwiseConv2dNative (TFOutput input, TFOutput filter, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DepthwiseConv2dNative", MakeName ("DepthwiseConv2dNative", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of depthwise convolution with respect to the filter.
		/// </summary>
		/// <param name="input">
		///   4-D with shape based on `data_format`.  For example, if
		///   `data_format` is 'NHWC' then `input` is a 4-D `[batch, in_height,
		///   in_width, in_channels]` tensor.
		/// </param>
		/// <param name="filter_sizes">
		///   An integer vector representing the tensor shape of `filter`,
		///   where `filter` is a 4-D
		///   `[filter_height, filter_width, in_channels, depthwise_multiplier]` tensor.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape  based on `data_format`.
		///   For example, if `data_format` is 'NHWC' then
		///   out_backprop shape is `[batch, out_height, out_width, out_channels]`.
		///   Gradients w.r.t. the output of the convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DepthwiseConv2dNativeBackpropFilter'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, height, width, channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, channels, height, width].
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   of the convolution.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, out_channels]`.  Gradient w.r.t.
		///   the `filter` input of the convolution.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput DepthwiseConv2dNativeBackpropFilter (TFOutput input, TFOutput filter_sizes, TFOutput out_backprop, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DepthwiseConv2dNativeBackpropFilter", MakeName ("DepthwiseConv2dNativeBackpropFilter", operName));
			desc.AddInput (input);
			desc.AddInput (filter_sizes);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradients of depthwise convolution with respect to the input.
		/// </summary>
		/// <param name="input_sizes">
		///   An integer vector representing the shape of `input`, based
		///   on `data_format`.  For example, if `data_format` is 'NHWC' then
		///    `input` is a 4-D `[batch, height, width, channels]` tensor.
		/// </param>
		/// <param name="filter">
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, depthwise_multiplier]`.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape  based on `data_format`.
		///   For example, if `data_format` is 'NHWC' then
		///   out_backprop shape is `[batch, out_height, out_width, out_channels]`.
		///   Gradients w.r.t. the output of the convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DepthwiseConv2dNativeBackpropInput'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, height, width, channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, channels, height, width].
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   of the convolution.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape according to `data_format`.  For example, if
		///   `data_format` is 'NHWC', output shape is `[batch, in_height,
		///   in_width, in_channels]`.  Gradient w.r.t. the input of the
		///   convolution.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput DepthwiseConv2dNativeBackpropInput (TFOutput input_sizes, TFOutput filter, TFOutput out_backprop, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DepthwiseConv2dNativeBackpropInput", MakeName ("DepthwiseConv2dNativeBackpropInput", operName));
			desc.AddInput (input_sizes);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Dequantize the 'input' tensor into a float Tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="min_range">
		///   The minimum scalar value possibly produced for the input.
		/// </param>
		/// <param name="max_range">
		///   The maximum scalar value possibly produced for the input.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Dequantize'.
		/// </param>
		/// <param name="mode">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   [min_range, max_range] are scalar floats that specify the range for
		///   the 'input' data. The 'mode' attribute controls exactly which calculations are
		///   used to convert the float values to their quantized equivalents.
		///   
		///   In 'MIN_COMBINED' mode, each value of the tensor will undergo the following:
		///   
		///   ```
		///   if T == qint8, in[i] += (range(T) + 1)/ 2.0
		///   out[i] = min_range + (in[i]* (max_range - min_range) / range(T))
		///   ```
		///   here `range(T) = numeric_limits&amp;lt;T&amp;gt;::max() - numeric_limits&amp;lt;T&amp;gt;::min()`
		///   
		///   *MIN_COMBINED Mode Example*
		///   
		///   If the input comes from a QuantizedRelu6, the output type is
		///   quint8 (range of 0-255) but the possible range of QuantizedRelu6 is
		///   0-6.  The min_range and max_range values are therefore 0.0 and 6.0.
		///   Dequantize on quint8 will take each value, cast to float, and multiply
		///   by 6 / 255.
		///   Note that if quantizedtype is qint8, the operation will additionally add
		///   each value by 128 prior to casting.
		///   
		///   If the mode is 'MIN_FIRST', then this approach is used:
		///   
		///   ```c++
		///   number_of_steps = 1 &amp;lt;&amp;lt; (# of bits in T)
		///   range_adjust = number_of_steps / (number_of_steps - 1)
		///   range = (range_max - range_min) * range_adjust
		///   range_scale = range / number_of_steps
		///   const double offset_input = static_cast&amp;lt;double&amp;gt;(input) - lowest_quantized;
		///   result = range_min + ((input - numeric_limits&amp;lt;T&amp;gt;::min()) * range_scale)
		///   ```
		/// </remarks>
		public TFOutput Dequantize (TFOutput input, TFOutput min_range, TFOutput max_range, string mode = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Dequantize", MakeName ("Dequantize", operName));
			desc.AddInput (input);
			desc.AddInput (min_range);
			desc.AddInput (max_range);
			if (mode != null)
				desc.SetAttr ("mode", mode);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Deserialize and concatenate `SparseTensors` from a serialized minibatch.
		/// </summary>
		/// <param name="serialized_sparse">
		///   2-D, The `N` serialized `SparseTensor` objects.
		///   Must have 3 columns.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DeserializeManySparse'.
		/// </param>
		/// <param name="dtype">
		///   The `dtype` of the serialized `SparseTensor` objects.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sparse_indices: 
		///   sparse_values: 
		///   sparse_shape: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The input `serialized_sparse` must be a string matrix of shape `[N x 3]` where
		///   `N` is the minibatch size and the rows correspond to packed outputs of
		///   `SerializeSparse`.  The ranks of the original `SparseTensor` objects
		///   must all match.  When the final `SparseTensor` is created, it has rank one
		///   higher than the ranks of the incoming `SparseTensor` objects
		///   (they have been concatenated along a new row dimension).
		///   
		///   The output `SparseTensor` object's shape values for all dimensions but the
		///   first are the max across the input `SparseTensor` objects' shape values
		///   for the corresponding dimensions.  Its first shape value is `N`, the minibatch
		///   size.
		///   
		///   The input `SparseTensor` objects' indices are assumed ordered in
		///   standard lexicographic order.  If this is not the case, after this
		///   step run `SparseReorder` to restore index ordering.
		///   
		///   For example, if the serialized input is a `[2 x 3]` matrix representing two
		///   original `SparseTensor` objects:
		///   
		///       index = [ 0]
		///               [10]
		///               [20]
		///       values = [1, 2, 3]
		///       shape = [50]
		///   
		///   and
		///   
		///       index = [ 2]
		///               [10]
		///       values = [4, 5]
		///       shape = [30]
		///   
		///   then the final deserialized `SparseTensor` will be:
		///   
		///       index = [0  0]
		///               [0 10]
		///               [0 20]
		///               [1  2]
		///               [1 10]
		///       values = [1, 2, 3, 4, 5]
		///       shape = [2 50]
		/// </remarks>
		public (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape) DeserializeManySparse (TFOutput serialized_sparse, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DeserializeManySparse", MakeName ("DeserializeManySparse", operName));
			desc.AddInput (serialized_sparse);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sparse_indices = new TFOutput (op, _idx++);
			var sparse_values = new TFOutput (op, _idx++);
			var sparse_shape = new TFOutput (op, _idx++);
			return (sparse_indices, sparse_values, sparse_shape);
		}

		/// <summary>
		///   Deletes the resource specified by the handle.
		/// </summary>
		/// <param name="resource">
		///   handle to the resource to delete.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DestroyResourceOp'.
		/// </param>
		/// <param name="ignore_lookup_error">
		///   Optional argument
		///   whether to ignore the error when the resource
		///   doesn't exist.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   All subsequent operations using the resource will result in a NotFound
		///   error status.
		/// </remarks>
		public TFOperation DestroyResourceOp (TFOutput resource, bool? ignore_lookup_error = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DestroyResourceOp", MakeName ("DestroyResourceOp", operName));
			desc.AddInput (resource);
			if (ignore_lookup_error.HasValue)
				desc.SetAttr ("ignore_lookup_error", ignore_lookup_error.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Returns a diagonal tensor with a given diagonal values.
		/// </summary>
		/// <param name="diagonal">
		///   Rank k tensor where k is at most 3.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Diag'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a `diagonal`, this operation returns a tensor with the `diagonal` and
		///   everything else padded with zeros. The diagonal is computed as follows:
		///   
		///   Assume `diagonal` has dimensions [D1,..., Dk], then the output is a tensor of
		///   rank 2k with dimensions [D1,..., Dk, D1,..., Dk] where:
		///   
		///   `output[i1,..., ik, i1,..., ik] = diagonal[i1, ..., ik]` and 0 everywhere else.
		///   
		///   For example:
		///   
		///   ```
		///   # 'diagonal' is [1, 2, 3, 4]
		///   tf.diag(diagonal) ==&amp;gt; [[1, 0, 0, 0]
		///                          [0, 2, 0, 0]
		///                          [0, 0, 3, 0]
		///                          [0, 0, 0, 4]]
		///   ```
		/// </remarks>
		public TFOutput Diag (TFOutput diagonal, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Diag", MakeName ("Diag", operName));
			desc.AddInput (diagonal);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the diagonal part of the tensor.
		/// </summary>
		/// <param name="input">
		///   Rank k tensor where k is 2, 4, or 6.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DiagPart'.
		/// </param>
		/// <returns>
		///   The extracted diagonal.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns a tensor with the `diagonal` part
		///   of the `input`. The `diagonal` part is computed as follows:
		///   
		///   Assume `input` has dimensions `[D1,..., Dk, D1,..., Dk]`, then the output is a
		///   tensor of rank `k` with dimensions `[D1,..., Dk]` where:
		///   
		///   `diagonal[i1,..., ik] = input[i1, ..., ik, i1,..., ik]`.
		///   
		///   For example:
		///   
		///   ```
		///   # 'input' is [[1, 0, 0, 0]
		///                 [0, 2, 0, 0]
		///                 [0, 0, 3, 0]
		///                 [0, 0, 0, 4]]
		///   
		///   tf.diag_part(input) ==&amp;gt; [1, 2, 3, 4]
		///   ```
		/// </remarks>
		public TFOutput DiagPart (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DiagPart", MakeName ("DiagPart", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var diagonal = new TFOutput (op, _idx++);
			return diagonal;
		}

		/// <summary>
		///   Computes Psi, the derivative of Lgamma (the log of the absolute value of
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Digamma'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `Gamma(x)`), element-wise.
		/// </remarks>
		public TFOutput Digamma (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Digamma", MakeName ("Digamma", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the grayscale dilation of 4-D `input` and 3-D `filter` tensors.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, depth]`.
		/// </param>
		/// <param name="filter">
		///   3-D with shape `[filter_height, filter_width, depth]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Dilation2D'.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   tensor. Must be: `[1, stride_height, stride_width, 1]`.
		/// </param>
		/// <param name="rates">
		///   The input stride for atrous morphological dilation. Must be:
		///   `[1, rate_height, rate_width, 1]`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, out_height, out_width, depth]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The `input` tensor has shape `[batch, in_height, in_width, depth]` and the
		///   `filter` tensor has shape `[filter_height, filter_width, depth]`, i.e., each
		///   input channel is processed independently of the others with its own structuring
		///   function. The `output` tensor has shape
		///   `[batch, out_height, out_width, depth]`. The spatial dimensions of the output
		///   tensor depend on the `padding` algorithm. We currently only support the default
		///   "NHWC" `data_format`.
		///   
		///   In detail, the grayscale morphological 2-D dilation is the max-sum correlation
		///   (for consistency with `conv2d`, we use unmirrored filters):
		///   
		///       output[b, y, x, c] =
		///          max_{dy, dx} input[b,
		///                             strides[1] * y + rates[1] * dy,
		///                             strides[2] * x + rates[2] * dx,
		///                             c] +
		///                       filter[dy, dx, c]
		///   
		///   Max-pooling is a special case when the filter has size equal to the pooling
		///   kernel size and contains all zeros.
		///   
		///   Note on duality: The dilation of `input` by the `filter` is equal to the
		///   negation of the erosion of `-input` by the reflected `filter`.
		/// </remarks>
		public TFOutput Dilation2D (TFOutput input, TFOutput filter, long[] strides, long[] rates, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Dilation2D", MakeName ("Dilation2D", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("rates", rates);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the gradient of morphological 2-D dilation with respect to the filter.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, depth]`.
		/// </param>
		/// <param name="filter">
		///   3-D with shape `[filter_height, filter_width, depth]`.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, out_height, out_width, depth]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Dilation2DBackpropFilter'.
		/// </param>
		/// <param name="strides">
		///   1-D of length 4. The stride of the sliding window for each dimension of
		///   the input tensor. Must be: `[1, stride_height, stride_width, 1]`.
		/// </param>
		/// <param name="rates">
		///   1-D of length 4. The input stride for atrous morphological dilation.
		///   Must be: `[1, rate_height, rate_width, 1]`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   3-D with shape `[filter_height, filter_width, depth]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Dilation2DBackpropFilter (TFOutput input, TFOutput filter, TFOutput out_backprop, long[] strides, long[] rates, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Dilation2DBackpropFilter", MakeName ("Dilation2DBackpropFilter", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("rates", rates);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var filter_backprop = new TFOutput (op, _idx++);
			return filter_backprop;
		}

		/// <summary>
		///   Computes the gradient of morphological 2-D dilation with respect to the input.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, depth]`.
		/// </param>
		/// <param name="filter">
		///   3-D with shape `[filter_height, filter_width, depth]`.
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, out_height, out_width, depth]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Dilation2DBackpropInput'.
		/// </param>
		/// <param name="strides">
		///   1-D of length 4. The stride of the sliding window for each dimension of
		///   the input tensor. Must be: `[1, stride_height, stride_width, 1]`.
		/// </param>
		/// <param name="rates">
		///   1-D of length 4. The input stride for atrous morphological dilation.
		///   Must be: `[1, rate_height, rate_width, 1]`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, in_height, in_width, depth]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Dilation2DBackpropInput (TFOutput input, TFOutput filter, TFOutput out_backprop, long[] strides, long[] rates, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Dilation2DBackpropInput", MakeName ("Dilation2DBackpropInput", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.AddInput (out_backprop);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("rates", rates);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var in_backprop = new TFOutput (op, _idx++);
			return in_backprop;
		}

		/// <summary>
		///   Returns x / y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Div'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Div` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Div (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Div", MakeName ("Div", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Draw bounding boxes on a batch of images.
		/// </summary>
		/// <param name="images">
		///   4-D with shape `[batch, height, width, depth]`. A batch of images.
		/// </param>
		/// <param name="boxes">
		///   3-D with shape `[batch, num_bounding_boxes, 4]` containing bounding
		///   boxes.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DrawBoundingBoxes'.
		/// </param>
		/// <returns>
		///   4-D with the same shape as `images`. The batch of input images with
		///   bounding boxes drawn on the images.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Outputs a copy of `images` but draws on top of the pixels zero or more bounding
		///   boxes specified by the locations in `boxes`. The coordinates of the each
		///   bounding box in `boxes` are encoded as `[y_min, x_min, y_max, x_max]`. The
		///   bounding box coordinates are floats in `[0.0, 1.0]` relative to the width and
		///   height of the underlying image.
		///   
		///   For example, if an image is 100 x 200 pixels and the bounding box is
		///   `[0.1, 0.2, 0.5, 0.9]`, the bottom-left and upper-right coordinates of the
		///   bounding box will be `(10, 40)` to `(50, 180)`.
		///   
		///   Parts of the bounding box may fall outside the image.
		/// </remarks>
		public TFOutput DrawBoundingBoxes (TFOutput images, TFOutput boxes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DrawBoundingBoxes", MakeName ("DrawBoundingBoxes", operName));
			desc.AddInput (images);
			desc.AddInput (boxes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Partitions `data` into `num_partitions` tensors using indices from `partitions`.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="partitions">
		///   Any shape.  Indices in the range `[0, num_partitions)`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DynamicPartition'.
		/// </param>
		/// <param name="num_partitions">
		///   The number of partitions to output.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For each index tuple `js` of size `partitions.ndim`, the slice `data[js, ...]`
		///   becomes part of `outputs[partitions[js]]`.  The slices with `partitions[js] = i`
		///   are placed in `outputs[i]` in lexicographic order of `js`, and the first
		///   dimension of `outputs[i]` is the number of entries in `partitions` equal to `i`.
		///   In detail,
		///   
		///   ```python
		///       outputs[i].shape = [sum(partitions == i)] + data.shape[partitions.ndim:]
		///   
		///       outputs[i] = pack([data[js, ...] for js if partitions[js] == i])
		///   ```
		///   
		///   `data.shape` must start with `partitions.shape`.
		///   
		///   For example:
		///   
		///   ```python
		///       # Scalar partitions.
		///       partitions = 1
		///       num_partitions = 2
		///       data = [10, 20]
		///       outputs[0] = []  # Empty with shape [0, 2]
		///       outputs[1] = [[10, 20]]
		///   
		///       # Vector partitions.
		///       partitions = [0, 0, 1, 1, 0]
		///       num_partitions = 2
		///       data = [10, 20, 30, 40, 50]
		///       outputs[0] = [10, 20, 50]
		///       outputs[1] = [30, 40]
		///   ```
		///   
		///   See `dynamic_stitch` for an example on how to merge partitions back.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/DynamicPartition.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput[] DynamicPartition (TFOutput data, TFOutput partitions, long num_partitions, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DynamicPartition", MakeName ("DynamicPartition", operName));
			desc.AddInput (data);
			desc.AddInput (partitions);
			desc.SetAttr ("num_partitions", num_partitions);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("outputs");
			var outputs = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				outputs [i] = new TFOutput (op, _idx++);
			
			return outputs;
		}

		/// <summary>
		///   Interleave the values from the `data` tensors into a single tensor.
		/// </summary>
		/// <param name="indices">
		/// </param>
		/// <param name="data">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'DynamicStitch'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Builds a merged tensor such that
		///   
		///   ```python
		///       merged[indices[m][i, ..., j], ...] = data[m][i, ..., j, ...]
		///   ```
		///   
		///   For example, if each `indices[m]` is scalar or vector, we have
		///   
		///   ```python
		///       # Scalar indices:
		///       merged[indices[m], ...] = data[m][...]
		///   
		///       # Vector indices:
		///       merged[indices[m][i], ...] = data[m][i, ...]
		///   ```
		///   
		///   Each `data[i].shape` must start with the corresponding `indices[i].shape`,
		///   and the rest of `data[i].shape` must be constant w.r.t. `i`.  That is, we
		///   must have `data[i].shape = indices[i].shape + constant`.  In terms of this
		///   `constant`, the output shape is
		///   
		///       merged.shape = [max(indices)] + constant
		///   
		///   Values are merged in order, so if an index appears in both `indices[m][i]` and
		///   `indices[n][j]` for `(m,i) &amp;lt; (n,j)` the slice `data[n][j]` will appear in the
		///   merged result.
		///   
		///   For example:
		///   
		///   ```python
		///       indices[0] = 6
		///       indices[1] = [4, 1]
		///       indices[2] = [[5, 2], [0, 3]]
		///       data[0] = [61, 62]
		///       data[1] = [[41, 42], [11, 12]]
		///       data[2] = [[[51, 52], [21, 22]], [[1, 2], [31, 32]]]
		///       merged = [[1, 2], [11, 12], [21, 22], [31, 32], [41, 42],
		///                 [51, 52], [61, 62]]
		///   ```
		///   
		///   This method can be used to merge partitions created by `dynamic_partition`
		///   as illustrated on the following example:
		///   
		///   ```python
		///       # Apply function (increments x_i) on elements for which a certain condition
		///       # apply (x_i != -1 in this example).
		///       x=tf.constant([0.1, -1., 5.2, 4.3, -1., 7.4])
		///       condition_mask=tf.not_equal(x,tf.constant(-1.))
		///       partitioned_data = tf.dynamic_partition(
		///           x, tf.cast(condition_mask, tf.int32) , 2)
		///       partitioned_data[1] = partitioned_data[1] + 1.0
		///       condition_indices = tf.dynamic_partition(
		///           tf.range(tf.shape(x)[0]), tf.cast(condition_mask, tf.int32) , 2)
		///       x = tf.dynamic_stitch(condition_indices, partitioned_data)
		///       # Here x=[1.1, -1., 6.2, 5.3, -1, 8.4], the -1. values remain
		///       # unchanged.
		///   ```
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/DynamicStitch.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput DynamicStitch (TFOutput[] indices, TFOutput[] data, string operName = null)
		{
			var desc = new TFOperationDesc (this, "DynamicStitch", MakeName ("DynamicStitch", operName));
			desc.AddInputs (indices);
			desc.AddInputs (data);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var merged = new TFOutput (op, _idx++);
			return merged;
		}

		/// <summary>
		///   Computes the (possibly normalized) Levenshtein Edit Distance.
		/// </summary>
		/// <param name="hypothesis_indices">
		///   The indices of the hypothesis list SparseTensor.
		///   This is an N x R int64 matrix.
		/// </param>
		/// <param name="hypothesis_values">
		///   The values of the hypothesis list SparseTensor.
		///   This is an N-length vector.
		/// </param>
		/// <param name="hypothesis_shape">
		///   The shape of the hypothesis list SparseTensor.
		///   This is an R-length vector.
		/// </param>
		/// <param name="truth_indices">
		///   The indices of the truth list SparseTensor.
		///   This is an M x R int64 matrix.
		/// </param>
		/// <param name="truth_values">
		///   The values of the truth list SparseTensor.
		///   This is an M-length vector.
		/// </param>
		/// <param name="truth_shape">
		///   truth indices, vector.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EditDistance'.
		/// </param>
		/// <param name="normalize">
		///   Optional argument
		///   boolean (if true, edit distances are normalized by length of truth).
		///   
		///   The output is:
		/// </param>
		/// <returns>
		///   A dense float tensor with rank R - 1.
		///   
		///   For the example input:
		///   
		///       // hypothesis represents a 2x1 matrix with variable-length values:
		///       //   (0,0) = ["a"]
		///       //   (1,0) = ["b"]
		///       hypothesis_indices = [[0, 0, 0],
		///                             [1, 0, 0]]
		///       hypothesis_values = ["a", "b"]
		///       hypothesis_shape = [2, 1, 1]
		///   
		///       // truth represents a 2x2 matrix with variable-length values:
		///       //   (0,0) = []
		///       //   (0,1) = ["a"]
		///       //   (1,0) = ["b", "c"]
		///       //   (1,1) = ["a"]
		///       truth_indices = [[0, 1, 0],
		///                        [1, 0, 0],
		///                        [1, 0, 1],
		///                        [1, 1, 0]]
		///       truth_values = ["a", "b", "c", "a"]
		///       truth_shape = [2, 2, 2]
		///       normalize = true
		///   
		///   The output will be:
		///   
		///       // output is a 2x2 matrix with edit distances normalized by truth lengths.
		///       output = [[inf, 1.0],  // (0,0): no truth, (0,1): no hypothesis
		///                 [0.5, 1.0]]  // (1,0): addition, (1,1): no hypothesis
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The inputs are variable-length sequences provided by SparseTensors
		///     (hypothesis_indices, hypothesis_values, hypothesis_shape)
		///   and
		///     (truth_indices, truth_values, truth_shape).
		///   
		///   The inputs are:
		/// </remarks>
		public TFOutput EditDistance (TFOutput hypothesis_indices, TFOutput hypothesis_values, TFOutput hypothesis_shape, TFOutput truth_indices, TFOutput truth_values, TFOutput truth_shape, bool? normalize = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EditDistance", MakeName ("EditDistance", operName));
			desc.AddInput (hypothesis_indices);
			desc.AddInput (hypothesis_values);
			desc.AddInput (hypothesis_shape);
			desc.AddInput (truth_indices);
			desc.AddInput (truth_values);
			desc.AddInput (truth_shape);
			if (normalize.HasValue)
				desc.SetAttr ("normalize", normalize.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes exponential linear: `exp(features) - 1` if &amp;lt; 0, `features` otherwise.
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Elu'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   See [Fast and Accurate Deep Network Learning by Exponential Linear Units (ELUs)
		///   ](http://arxiv.org/abs/1511.07289)
		/// </remarks>
		public TFOutput Elu (TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Elu", MakeName ("Elu", operName));
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			return activations;
		}

		/// <summary>
		///   Computes gradients for the exponential linear (Elu) operation.
		/// </summary>
		/// <param name="gradients">
		///   The backpropagated gradients to the corresponding Elu operation.
		/// </param>
		/// <param name="outputs">
		///   The outputs of the corresponding Elu operation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EluGrad'.
		/// </param>
		/// <returns>
		///   The gradients: `gradients * (outputs + 1)` if outputs &amp;lt; 0,
		///   `gradients` otherwise.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput EluGrad (TFOutput gradients, TFOutput outputs, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EluGrad", MakeName ("EluGrad", operName));
			desc.AddInput (gradients);
			desc.AddInput (outputs);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   Encode strings into web-safe base64 format.
		/// </summary>
		/// <param name="input">
		///   Strings to be encoded.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EncodeBase64'.
		/// </param>
		/// <param name="pad">
		///   Optional argument
		///   Bool whether padding is applied at the ends.
		/// </param>
		/// <returns>
		///   Input strings encoded in base64.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Refer to the following article for more information on base64 format:
		///   en.wikipedia.org/wiki/Base64. Base64 strings may have padding with '=' at the
		///   end so that the encoded has length multiple of 4. See Padding section of the
		///   link above.
		///   
		///   Web-safe means that the encoder uses - and _ instead of + and /.
		/// </remarks>
		public TFOutput EncodeBase64 (TFOutput input, bool? pad = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EncodeBase64", MakeName ("EncodeBase64", operName));
			desc.AddInput (input);
			if (pad.HasValue)
				desc.SetAttr ("pad", pad.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   JPEG-encode an image.
		/// </summary>
		/// <param name="image">
		///   3-D with shape `[height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EncodeJpeg'.
		/// </param>
		/// <param name="format">
		///   Optional argument
		///   Per pixel image format.
		/// </param>
		/// <param name="quality">
		///   Optional argument
		///   Quality of the compression from 0 to 100 (higher is better and slower).
		/// </param>
		/// <param name="progressive">
		///   Optional argument
		///   If True, create a JPEG that loads progressively (coarse to fine).
		/// </param>
		/// <param name="optimize_size">
		///   Optional argument
		///   If True, spend CPU/RAM to reduce size with no quality change.
		/// </param>
		/// <param name="chroma_downsampling">
		///   Optional argument
		///   See http://en.wikipedia.org/wiki/Chroma_subsampling.
		/// </param>
		/// <param name="density_unit">
		///   Optional argument
		///   Unit used to specify `x_density` and `y_density`:
		///   pixels per inch (`'in'`) or centimeter (`'cm'`).
		/// </param>
		/// <param name="x_density">
		///   Optional argument
		///   Horizontal pixels per density unit.
		/// </param>
		/// <param name="y_density">
		///   Optional argument
		///   Vertical pixels per density unit.
		/// </param>
		/// <param name="xmp_metadata">
		///   Optional argument
		///   If not empty, embed this XMP metadata in the image header.
		/// </param>
		/// <returns>
		///   0-D. JPEG-encoded image.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `image` is a 3-D uint8 Tensor of shape `[height, width, channels]`.
		///   
		///   The attr `format` can be used to override the color format of the encoded
		///   output.  Values can be:
		///   
		///   *   `''`: Use a default format based on the number of channels in the image.
		///   *   `grayscale`: Output a grayscale JPEG image.  The `channels` dimension
		///       of `image` must be 1.
		///   *   `rgb`: Output an RGB JPEG image. The `channels` dimension
		///       of `image` must be 3.
		///   
		///   If `format` is not specified or is the empty string, a default format is picked
		///   in function of the number of channels in `image`:
		///   
		///   *   1: Output a grayscale image.
		///   *   3: Output an RGB image.
		/// </remarks>
		public TFOutput EncodeJpeg (TFOutput image, string format = null, long? quality = null, bool? progressive = null, bool? optimize_size = null, bool? chroma_downsampling = null, string density_unit = null, long? x_density = null, long? y_density = null, string xmp_metadata = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EncodeJpeg", MakeName ("EncodeJpeg", operName));
			desc.AddInput (image);
			if (format != null)
				desc.SetAttr ("format", format);
			
			if (quality.HasValue)
				desc.SetAttr ("quality", quality.Value);
			
			if (progressive.HasValue)
				desc.SetAttr ("progressive", progressive.Value);
			
			if (optimize_size.HasValue)
				desc.SetAttr ("optimize_size", optimize_size.Value);
			
			if (chroma_downsampling.HasValue)
				desc.SetAttr ("chroma_downsampling", chroma_downsampling.Value);
			
			if (density_unit != null)
				desc.SetAttr ("density_unit", density_unit);
			
			if (x_density.HasValue)
				desc.SetAttr ("x_density", x_density.Value);
			
			if (y_density.HasValue)
				desc.SetAttr ("y_density", y_density.Value);
			
			if (xmp_metadata != null)
				desc.SetAttr ("xmp_metadata", xmp_metadata);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var contents = new TFOutput (op, _idx++);
			return contents;
		}

		/// <summary>
		///   PNG-encode an image.
		/// </summary>
		/// <param name="image">
		///   3-D with shape `[height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EncodePng'.
		/// </param>
		/// <param name="compression">
		///   Optional argument
		///   Compression level.
		/// </param>
		/// <returns>
		///   0-D. PNG-encoded image.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `image` is a 3-D uint8 or uint16 Tensor of shape `[height, width, channels]`
		///   where `channels` is:
		///   
		///   *   1: for grayscale.
		///   *   2: for grayscale + alpha.
		///   *   3: for RGB.
		///   *   4: for RGBA.
		///   
		///   The ZLIB compression level, `compression`, can be -1 for the PNG-encoder
		///   default or a value from 0 to 9.  9 is the highest compression level, generating
		///   the smallest output, but is slower.
		/// </remarks>
		public TFOutput EncodePng (TFOutput image, long? compression = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EncodePng", MakeName ("EncodePng", operName));
			desc.AddInput (image);
			if (compression.HasValue)
				desc.SetAttr ("compression", compression.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var contents = new TFOutput (op, _idx++);
			return contents;
		}

		/// <summary>
		///   Encode audio data using the WAV file format.
		/// </summary>
		/// <param name="audio">
		///   2-D with shape `[length, channels]`.
		/// </param>
		/// <param name="sample_rate">
		///   Scalar containing the sample frequency.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'EncodeWav'.
		/// </param>
		/// <returns>
		///   0-D. WAV-encoded file contents.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation will generate a string suitable to be saved out to create a .wav
		///   audio file. It will be encoded in the 16-bit PCM format. It takes in float
		///   values in the range -1.0f to 1.0f, and any outside that value will be clamped to
		///   that range.
		///   
		///   `audio` is a 2-D float Tensor of shape `[length, channels]`.
		///   `sample_rate` is a scalar Tensor holding the rate to use (e.g. 44100).
		/// </remarks>
		public TFOutput EncodeWav (TFOutput audio, TFOutput sample_rate, string operName = null)
		{
			var desc = new TFOperationDesc (this, "EncodeWav", MakeName ("EncodeWav", operName));
			desc.AddInput (audio);
			desc.AddInput (sample_rate);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var contents = new TFOutput (op, _idx++);
			return contents;
		}

		/// <summary>
		///   Creates or finds a child frame, and makes `data` available to the child frame.
		/// </summary>
		/// <param name="data">
		///   The tensor to be made available to the child frame.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Enter'.
		/// </param>
		/// <param name="is_constant">
		///   Optional argument
		///   If true, the output is constant within the child frame.
		/// </param>
		/// <param name="parallel_iterations">
		///   Optional argument
		///   The number of iterations allowed to run in parallel.
		/// </param>
		/// <param name="frame_name">
		///   The name of the child frame.
		/// </param>
		/// <returns>
		///   The same tensor as `data`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op is used together with `Exit` to create loops in the graph.
		///   The unique `frame_name` is used by the `Executor` to identify frames. If
		///   `is_constant` is true, `output` is a constant in the child frame; otherwise
		///   it may be changed in the child frame. At most `parallel_iterations` iterations
		///   are run in parallel in the child frame.
		/// </remarks>
		public TFOutput Enter (TFOutput data, string frame_name, bool? is_constant = null, long? parallel_iterations = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Enter", MakeName ("Enter", operName));
			desc.AddInput (data);
			desc.SetAttr ("frame_name", frame_name);
			if (is_constant.HasValue)
				desc.SetAttr ("is_constant", is_constant.Value);
			
			if (parallel_iterations.HasValue)
				desc.SetAttr ("parallel_iterations", parallel_iterations.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the truth value of (x == y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Equal'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Equal` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Equal (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Equal", MakeName ("Equal", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes the Gauss error function of `x` element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Erf'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Erf (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Erf", MakeName ("Erf", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the complementary error function of `x` element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Erfc'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Erfc (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Erfc", MakeName ("Erfc", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Exits the current frame to its parent frame.
		/// </summary>
		/// <param name="data">
		///   The tensor to be made available to the parent frame.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Exit'.
		/// </param>
		/// <returns>
		///   The same tensor as `data`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Exit makes its input `data` available to the parent frame.
		/// </remarks>
		public TFOutput Exit (TFOutput data, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Exit", MakeName ("Exit", operName));
			desc.AddInput (data);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes exponential of x element-wise.  \\(y = e^x\\).
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Exp'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Exp (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Exp", MakeName ("Exp", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Inserts a dimension of 1 into a tensor's shape.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="dim">
		///   0-D (scalar). Specifies the dimension index at which to
		///   expand the shape of `input`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ExpandDims'.
		/// </param>
		/// <returns>
		///   Contains the same data as `input`, but its shape has an additional
		///   dimension of size 1 added.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input`, this operation inserts a dimension of 1 at the
		///   dimension index `dim` of `input`'s shape. The dimension index `dim` starts at
		///   zero; if you specify a negative number for `dim` it is counted backward from
		///   the end.
		///   
		///   This operation is useful if you want to add a batch dimension to a single
		///   element. For example, if you have a single image of shape `[height, width,
		///   channels]`, you can make it a batch of 1 image with `expand_dims(image, 0)`,
		///   which will make the shape `[1, height, width, channels]`.
		///   
		///   Other examples:
		///   
		///   ```
		///   # 't' is a tensor of shape [2]
		///   shape(expand_dims(t, 0)) ==&amp;gt; [1, 2]
		///   shape(expand_dims(t, 1)) ==&amp;gt; [2, 1]
		///   shape(expand_dims(t, -1)) ==&amp;gt; [2, 1]
		///   
		///   # 't2' is a tensor of shape [2, 3, 5]
		///   shape(expand_dims(t2, 0)) ==&amp;gt; [1, 2, 3, 5]
		///   shape(expand_dims(t2, 2)) ==&amp;gt; [2, 3, 1, 5]
		///   shape(expand_dims(t2, 3)) ==&amp;gt; [2, 3, 5, 1]
		///   ```
		///   
		///   This operation requires that:
		///   
		///   `-1-input.dims() &amp;lt;= dim &amp;lt;= input.dims()`
		///   
		///   This operation is related to `squeeze()`, which removes dimensions of
		///   size 1.
		/// </remarks>
		public TFOutput ExpandDims (TFOutput input, TFOutput dim, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ExpandDims", MakeName ("ExpandDims", operName));
			desc.AddInput (input);
			desc.AddInput (dim);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes exponential of x - 1 element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Expm1'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = (\exp x) - 1\\).
		/// </remarks>
		public TFOutput Expm1 (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Expm1", MakeName ("Expm1", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Extracts a glimpse from the input tensor.
		/// </summary>
		/// <param name="input">
		///   A 4-D float tensor of shape `[batch_size, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   A 1-D tensor of 2 elements containing the size of the glimpses
		///   to extract.  The glimpse height must be specified first, following
		///   by the glimpse width.
		/// </param>
		/// <param name="offsets">
		///   A 2-D integer tensor of shape `[batch_size, 2]` containing
		///   the y, x locations of the center of each window.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ExtractGlimpse'.
		/// </param>
		/// <param name="centered">
		///   Optional argument
		///   indicates if the offset coordinates are centered relative to
		///   the image, in which case the (0, 0) offset is relative to the center
		///   of the input images. If false, the (0,0) offset corresponds to the
		///   upper left corner of the input images.
		/// </param>
		/// <param name="normalized">
		///   Optional argument
		///   indicates if the offset coordinates are normalized.
		/// </param>
		/// <param name="uniform_noise">
		///   Optional argument
		///   indicates if the noise should be generated using a
		///   uniform distribution or a Gaussian distribution.
		/// </param>
		/// <returns>
		///   A tensor representing the glimpses `[batch_size,
		///   glimpse_height, glimpse_width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Returns a set of windows called glimpses extracted at location
		///   `offsets` from the input tensor. If the windows only partially
		///   overlaps the inputs, the non overlapping areas will be filled with
		///   random noise.
		///   
		///   The result is a 4-D tensor of shape `[batch_size, glimpse_height,
		///   glimpse_width, channels]`. The channels and batch dimensions are the
		///   same as that of the input tensor. The height and width of the output
		///   windows are specified in the `size` parameter.
		///   
		///   The argument `normalized` and `centered` controls how the windows are built:
		///   
		///   * If the coordinates are normalized but not centered, 0.0 and 1.0
		///     correspond to the minimum and maximum of each height and width
		///     dimension.
		///   * If the coordinates are both normalized and centered, they range from
		///     -1.0 to 1.0. The coordinates (-1.0, -1.0) correspond to the upper
		///     left corner, the lower right corner is located at (1.0, 1.0) and the
		///     center is at (0, 0).
		///   * If the coordinates are not normalized they are interpreted as
		///     numbers of pixels.
		/// </remarks>
		public TFOutput ExtractGlimpse (TFOutput input, TFOutput size, TFOutput offsets, bool? centered = null, bool? normalized = null, bool? uniform_noise = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ExtractGlimpse", MakeName ("ExtractGlimpse", operName));
			desc.AddInput (input);
			desc.AddInput (size);
			desc.AddInput (offsets);
			if (centered.HasValue)
				desc.SetAttr ("centered", centered.Value);
			
			if (normalized.HasValue)
				desc.SetAttr ("normalized", normalized.Value);
			
			if (uniform_noise.HasValue)
				desc.SetAttr ("uniform_noise", uniform_noise.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var glimpse = new TFOutput (op, _idx++);
			return glimpse;
		}

		/// <summary>
		///   Extract `patches` from `images` and put them in the "depth" output dimension.
		/// </summary>
		/// <param name="images">
		///   4-D Tensor with shape `[batch, in_rows, in_cols, depth]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ExtractImagePatches'.
		/// </param>
		/// <param name="ksizes">
		///   The size of the sliding window for each dimension of `images`.
		/// </param>
		/// <param name="strides">
		///   1-D of length 4. How far the centers of two consecutive patches are in
		///   the images. Must be: `[1, stride_rows, stride_cols, 1]`.
		/// </param>
		/// <param name="rates">
		///   1-D of length 4. Must be: `[1, rate_rows, rate_cols, 1]`. This is the
		///   input stride, specifying how far two consecutive patch samples are in the
		///   input. Equivalent to extracting patches with
		///   `patch_sizes_eff = patch_sizes + (patch_sizes - 1) * (rates - 1)`, followed by
		///   subsampling them spatially by a factor of `rates`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		///   
		///   We specify the size-related attributes as:
		///   
		///   ```python
		///         ksizes = [1, ksize_rows, ksize_cols, 1]
		///         strides = [1, strides_rows, strides_cols, 1]
		///         rates = [1, rates_rows, rates_cols, 1]
		///   ```
		/// </param>
		/// <returns>
		///   4-D Tensor with shape `[batch, out_rows, out_cols, ksize_rows *
		///   ksize_cols * depth]` containing image patches with size
		///   `ksize_rows x ksize_cols x depth` vectorized in the "depth" dimension.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ExtractImagePatches (TFOutput images, long[] ksizes, long[] strides, long[] rates, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ExtractImagePatches", MakeName ("ExtractImagePatches", operName));
			desc.AddInput (images);
			desc.SetAttr ("ksizes", ksizes);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("rates", rates);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var patches = new TFOutput (op, _idx++);
			return patches;
		}

		/// <summary>
		///   Output a fact about factorials.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Fact'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Fact (string operName = null)
		{
			var desc = new TFOperationDesc (this, "Fact", MakeName ("Fact", operName));
			var op = desc.FinishOperation ();
			int _idx = 0;
			var fact = new TFOutput (op, _idx++);
			return fact;
		}

		/// <summary>
		///   Fake-quantize the 'inputs' tensor, type float to 'outputs' tensor of same type.
		/// </summary>
		/// <param name="inputs">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxArgs'.
		/// </param>
		/// <param name="min">
		///   Optional argument
		/// </param>
		/// <param name="max">
		///   Optional argument
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Attributes [min; max] define the clamping range for the 'inputs' data.  Op
		///   divides this range into 255 steps (total of 256 values), then replaces each
		///   'inputs' value with the closest of the quantized step values.
		///   'num_bits' is the bitwidth of the quantization; between 2 and 8, inclusive.
		///   
		///   Quantization is called fake since the output is still in floating point.
		/// </remarks>
		public TFOutput FakeQuantWithMinMaxArgs (TFOutput inputs, float? min = null, float? max = null, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxArgs", MakeName ("FakeQuantWithMinMaxArgs", operName));
			desc.AddInput (inputs);
			if (min.HasValue)
				desc.SetAttr ("min", min.Value);
			
			if (max.HasValue)
				desc.SetAttr ("max", max.Value);
			
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var outputs = new TFOutput (op, _idx++);
			return outputs;
		}

		/// <summary>
		///   Compute gradients for a FakeQuantWithMinMaxArgs operation.
		/// </summary>
		/// <param name="gradients">
		///   Backpropagated gradients above the FakeQuantWithMinMaxArgs operation.
		/// </param>
		/// <param name="inputs">
		///   Values passed as inputs to the FakeQuantWithMinMaxArgs operation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxArgsGradient'.
		/// </param>
		/// <param name="min">
		///   Optional argument
		/// </param>
		/// <param name="max">
		///   Optional argument
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Backpropagated gradients below the FakeQuantWithMinMaxArgs operation:
		///   `gradients * (inputs &amp;gt;= min &amp;&amp; inputs &amp;lt;= max)`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput FakeQuantWithMinMaxArgsGradient (TFOutput gradients, TFOutput inputs, float? min = null, float? max = null, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxArgsGradient", MakeName ("FakeQuantWithMinMaxArgsGradient", operName));
			desc.AddInput (gradients);
			desc.AddInput (inputs);
			if (min.HasValue)
				desc.SetAttr ("min", min.Value);
			
			if (max.HasValue)
				desc.SetAttr ("max", max.Value);
			
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   Fake-quantize the 'inputs' tensor of type float via global float scalars `min`
		/// </summary>
		/// <param name="inputs">
		/// </param>
		/// <param name="min">
		/// </param>
		/// <param name="max">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxVars'.
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   and `max` to 'outputs' tensor of same shape as `inputs`.
		///   
		///   [min; max] is the clamping range for the 'inputs' data.  Op divides this range
		///   into 255 steps (total of 256 values), then replaces each 'inputs' value with the
		///   closest of the quantized step values.
		///   'num_bits' is the bitwidth of the quantization; between 2 and 8, inclusive.
		///   
		///   This operation has a gradient and thus allows for training `min` and `max` values.
		/// </remarks>
		public TFOutput FakeQuantWithMinMaxVars (TFOutput inputs, TFOutput min, TFOutput max, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxVars", MakeName ("FakeQuantWithMinMaxVars", operName));
			desc.AddInput (inputs);
			desc.AddInput (min);
			desc.AddInput (max);
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var outputs = new TFOutput (op, _idx++);
			return outputs;
		}

		/// <summary>
		///   Compute gradients for a FakeQuantWithMinMaxVars operation.
		/// </summary>
		/// <param name="gradients">
		///   Backpropagated gradients above the FakeQuantWithMinMaxVars operation.
		/// </param>
		/// <param name="inputs">
		///   Values passed as inputs to the FakeQuantWithMinMaxVars operation.
		///   min, max: Quantization interval, scalar floats.
		/// </param>
		/// <param name="min">
		/// </param>
		/// <param name="max">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxVarsGradient'.
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		///   The bitwidth of the quantization; between 2 and 8, inclusive.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   backprops_wrt_input: Backpropagated gradients w.r.t. inputs:
		///   `gradients * (inputs &amp;gt;= min &amp;&amp; inputs &amp;lt;= max)`.
		///   backprop_wrt_min: Backpropagated gradients w.r.t. min parameter:
		///   `sum(gradients * (inputs &amp;lt; min))`.
		///   backprop_wrt_max: Backpropagated gradients w.r.t. max parameter:
		///   `sum(gradients * (inputs &amp;gt; max))`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput backprops_wrt_input, TFOutput backprop_wrt_min, TFOutput backprop_wrt_max) FakeQuantWithMinMaxVarsGradient (TFOutput gradients, TFOutput inputs, TFOutput min, TFOutput max, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxVarsGradient", MakeName ("FakeQuantWithMinMaxVarsGradient", operName));
			desc.AddInput (gradients);
			desc.AddInput (inputs);
			desc.AddInput (min);
			desc.AddInput (max);
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops_wrt_input = new TFOutput (op, _idx++);
			var backprop_wrt_min = new TFOutput (op, _idx++);
			var backprop_wrt_max = new TFOutput (op, _idx++);
			return (backprops_wrt_input, backprop_wrt_min, backprop_wrt_max);
		}

		/// <summary>
		///   Fake-quantize the 'inputs' tensor of type float and one of the shapes: `[d]`,
		/// </summary>
		/// <param name="inputs">
		/// </param>
		/// <param name="min">
		/// </param>
		/// <param name="max">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxVarsPerChannel'.
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `[b, d]` `[b, h, w, d]` via per-channel floats `min` and `max` of shape `[d]`
		///   to 'outputs' tensor of same shape as `inputs`.
		///   
		///   [min; max] is the clamping range for the 'inputs' data in the corresponding
		///   depth channel.  Op divides this range into 255 steps (total of 256 values), then
		///   replaces each 'inputs' value with the closest of the quantized step values.
		///   'num_bits' is the bitwidth of the quantization; between 2 and 8, inclusive.
		///   
		///   This operation has a gradient and thus allows for training `min` and `max` values.
		/// </remarks>
		public TFOutput FakeQuantWithMinMaxVarsPerChannel (TFOutput inputs, TFOutput min, TFOutput max, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxVarsPerChannel", MakeName ("FakeQuantWithMinMaxVarsPerChannel", operName));
			desc.AddInput (inputs);
			desc.AddInput (min);
			desc.AddInput (max);
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var outputs = new TFOutput (op, _idx++);
			return outputs;
		}

		/// <summary>
		///   Compute gradients for a FakeQuantWithMinMaxVarsPerChannel operation.
		/// </summary>
		/// <param name="gradients">
		///   Backpropagated gradients above the FakeQuantWithMinMaxVars operation,
		///   shape one of: `[d]`, `[b, d]`,  `[b, h, w, d]`.
		/// </param>
		/// <param name="inputs">
		///   Values passed as inputs to the FakeQuantWithMinMaxVars operation, shape
		///     same as `gradients`.
		///   min, max: Quantization interval, floats of shape `[d]`.
		/// </param>
		/// <param name="min">
		/// </param>
		/// <param name="max">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FakeQuantWithMinMaxVarsPerChannelGradient'.
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		///   The bitwidth of the quantization; between 2 and 8, inclusive.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   backprops_wrt_input: Backpropagated gradients w.r.t. inputs, shape same as
		///   `inputs`:
		///     `gradients * (inputs &amp;gt;= min &amp;&amp; inputs &amp;lt;= max)`.
		///   backprop_wrt_min: Backpropagated gradients w.r.t. min parameter, shape `[d]`:
		///   `sum_per_d(gradients * (inputs &amp;lt; min))`.
		///   backprop_wrt_max: Backpropagated gradients w.r.t. max parameter, shape `[d]`:
		///   `sum_per_d(gradients * (inputs &amp;gt; max))`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput backprops_wrt_input, TFOutput backprop_wrt_min, TFOutput backprop_wrt_max) FakeQuantWithMinMaxVarsPerChannelGradient (TFOutput gradients, TFOutput inputs, TFOutput min, TFOutput max, long? num_bits = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FakeQuantWithMinMaxVarsPerChannelGradient", MakeName ("FakeQuantWithMinMaxVarsPerChannelGradient", operName));
			desc.AddInput (gradients);
			desc.AddInput (inputs);
			desc.AddInput (min);
			desc.AddInput (max);
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops_wrt_input = new TFOutput (op, _idx++);
			var backprop_wrt_min = new TFOutput (op, _idx++);
			var backprop_wrt_max = new TFOutput (op, _idx++);
			return (backprops_wrt_input, backprop_wrt_min, backprop_wrt_max);
		}

		/// <summary>
		///   Fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FFT'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most
		///     dimension of `input` is replaced with its 1D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.fft
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 1-dimensional discrete Fourier transform over the inner-most
		///   dimension of `input`.
		/// </remarks>
		public TFOutput FFT (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FFT", MakeName ("FFT", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   2D fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FFT2D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most 2
		///     dimensions of `input` are replaced with their 2D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.fft2
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 2-dimensional discrete Fourier transform over the inner-most
		///   2 dimensions of `input`.
		/// </remarks>
		public TFOutput FFT2D (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FFT2D", MakeName ("FFT2D", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   3D fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FFT3D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most 3
		///     dimensions of `input` are replaced with their 3D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.fftn with 3 dimensions.
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 3-dimensional discrete Fourier transform over the inner-most 3
		///   dimensions of `input`.
		/// </remarks>
		public TFOutput FFT3D (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FFT3D", MakeName ("FFT3D", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A queue that produces elements in first-in first-out order.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FIFOQueueV2'.
		/// </param>
		/// <param name="shapes">
		///   Optional argument
		///   The shape of each component in a value. The length of this attr must
		///   be either 0 or the same as the length of component_types. If the length of
		///   this attr is 0, the shapes of queue elements are not constrained, and
		///   only one element may be dequeued at a time.
		/// </param>
		/// <param name="capacity">
		///   Optional argument
		///   The upper bound on the number of elements in this queue.
		///   Negative numbers mean no limit.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this queue is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this queue will be shared under the given name
		///   across multiple sessions.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a value.
		/// </param>
		/// <returns>
		///   The handle to the queue.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput FIFOQueueV2 (TFDataType[] component_types, TFShape[] shapes = null, long? capacity = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FIFOQueueV2", MakeName ("FIFOQueueV2", operName));
			desc.SetAttrType ("component_types", component_types);
			if (shapes != null)
				desc.SetAttrShape ("shapes", shapes);
			
			if (capacity.HasValue)
				desc.SetAttr ("capacity", capacity.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Creates a tensor filled with a scalar value.
		/// </summary>
		/// <param name="dims">
		///   1-D. Represents the shape of the output tensor.
		/// </param>
		/// <param name="value">
		///   0-D (scalar). Value to fill the returned tensor.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.full
		///   @end_compatibility
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Fill'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation creates a tensor of shape `dims` and fills it with `value`.
		///   
		///   For example:
		///   
		///   ```
		///   # Output tensor has shape [2, 3].
		///   fill([2, 3], 9) ==&amp;gt; [[9, 9, 9]
		///                        [9, 9, 9]]
		///   ```
		/// </remarks>
		public TFOutput Fill (TFOutput dims, TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Fill", MakeName ("Fill", operName));
			desc.AddInput (dims);
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a dataset that emits the records from one or more binary files.
		/// </summary>
		/// <param name="filenames">
		///   A scalar or a vector containing the name(s) of the file(s) to be
		///   read.
		/// </param>
		/// <param name="header_bytes">
		///   A scalar representing the number of bytes to skip at the
		///   beginning of a file.
		/// </param>
		/// <param name="record_bytes">
		///   A scalar representing the number of bytes in each record.
		/// </param>
		/// <param name="footer_bytes">
		///   A scalar representing the number of bytes to skip at the end
		///   of a file.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FixedLengthRecordDataset'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput FixedLengthRecordDataset (TFOutput filenames, TFOutput header_bytes, TFOutput record_bytes, TFOutput footer_bytes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FixedLengthRecordDataset", MakeName ("FixedLengthRecordDataset", operName));
			desc.AddInput (filenames);
			desc.AddInput (header_bytes);
			desc.AddInput (record_bytes);
			desc.AddInput (footer_bytes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   A Reader that outputs fixed-length records from a file.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FixedLengthRecordReaderV2'.
		/// </param>
		/// <param name="header_bytes">
		///   Optional argument
		///   Number of bytes in the header, defaults to 0.
		/// </param>
		/// <param name="footer_bytes">
		///   Optional argument
		///   Number of bytes in the footer, defaults to 0.
		/// </param>
		/// <param name="hop_bytes">
		///   Optional argument
		///   Number of bytes to hop before each read. Default of 0 means using
		///   record_bytes.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this reader is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this reader is named in the given bucket
		///   with this shared_name. Otherwise, the node name is used instead.
		/// </param>
		/// <param name="record_bytes">
		///   Number of bytes in the record.
		/// </param>
		/// <returns>
		///   The handle to reference the Reader.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput FixedLengthRecordReaderV2 (long record_bytes, long? header_bytes = null, long? footer_bytes = null, long? hop_bytes = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FixedLengthRecordReaderV2", MakeName ("FixedLengthRecordReaderV2", operName));
			desc.SetAttr ("record_bytes", record_bytes);
			if (header_bytes.HasValue)
				desc.SetAttr ("header_bytes", header_bytes.Value);
			
			if (footer_bytes.HasValue)
				desc.SetAttr ("footer_bytes", footer_bytes.Value);
			
			if (hop_bytes.HasValue)
				desc.SetAttr ("hop_bytes", hop_bytes.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var reader_handle = new TFOutput (op, _idx++);
			return reader_handle;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a learned unigram distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FixedUnigramCandidateSampler'.
		/// </param>
		/// <param name="vocab_file">
		///   Optional argument
		///   Each valid line in this file (which should have a CSV-like format)
		///   corresponds to a valid word ID. IDs are in sequential order, starting from
		///   num_reserved_ids. The last entry in each line is expected to be a value
		///   corresponding to the count or relative probability. Exactly one of vocab_file
		///   and unigrams needs to be passed to this op.
		/// </param>
		/// <param name="distortion">
		///   Optional argument
		///   The distortion is used to skew the unigram probability distribution.
		///   Each weight is first raised to the distortion's power before adding to the
		///   internal unigram distribution. As a result, distortion = 1.0 gives regular
		///   unigram sampling (as defined by the vocab file), and distortion = 0.0 gives
		///   a uniform distribution.
		/// </param>
		/// <param name="num_reserved_ids">
		///   Optional argument
		///   Optionally some reserved IDs can be added in the range [0,
		///   ..., num_reserved_ids) by the users. One use case is that a special unknown
		///   word token is used as ID 0. These IDs will have a sampling probability of 0.
		/// </param>
		/// <param name="num_shards">
		///   Optional argument
		///   A sampler can be used to sample from a subset of the original range
		///   in order to speed up the whole computation through parallelism. This parameter
		///   (together with 'shard') indicates the number of partitions that are being
		///   used in the overall computation.
		/// </param>
		/// <param name="shard">
		///   Optional argument
		///   A sampler can be used to sample from a subset of the original range
		///   in order to speed up the whole computation through parallelism. This parameter
		///   (together with 'num_shards') indicates the particular partition number of a
		///   sampler op, when partitioning is being used.
		/// </param>
		/// <param name="unigrams">
		///   Optional argument
		///   A list of unigram counts or probabilities, one per ID in sequential
		///   order. Exactly one of vocab_file and unigrams should be passed to this op.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to randomly sample.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <param name="range_max">
		///   The sampler will sample integers from the interval [0, range_max).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   A unigram sampler could use a fixed unigram distribution read from a
		///   file or passed in as an in-memory array instead of building up the distribution
		///   from data on the fly. There is also an option to skew the distribution by
		///   applying a distortion power to the weights.
		///   
		///   The vocabulary file should be in CSV-like format, with the last field
		///   being the weight associated with the word.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) FixedUnigramCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long range_max, string vocab_file = null, float? distortion = null, long? num_reserved_ids = null, long? num_shards = null, long? shard = null, float[] unigrams = null, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FixedUnigramCandidateSampler", MakeName ("FixedUnigramCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			desc.SetAttr ("range_max", range_max);
			if (vocab_file != null)
				desc.SetAttr ("vocab_file", vocab_file);
			
			if (distortion.HasValue)
				desc.SetAttr ("distortion", distortion.Value);
			
			if (num_reserved_ids.HasValue)
				desc.SetAttr ("num_reserved_ids", num_reserved_ids.Value);
			
			if (num_shards.HasValue)
				desc.SetAttr ("num_shards", num_shards.Value);
			
			if (shard.HasValue)
				desc.SetAttr ("shard", shard.Value);
			
			if (unigrams != null)
				desc.SetAttr ("unigrams", unigrams);
			
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Returns element-wise largest integer not greater than x.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Floor'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Floor (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Floor", MakeName ("Floor", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns x // y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FloorDiv'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `FloorDiv` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput FloorDiv (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FloorDiv", MakeName ("FloorDiv", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns element-wise remainder of division. When `x &amp;lt; 0` xor `y &amp;lt; 0` is
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FloorMod'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   true, this follows Python semantics in that the result here is consistent
		///   with a flooring divide. E.g. `floor(x / y) * y + mod(x, y) = x`.
		///   
		///   *NOTE*: `FloorMod` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput FloorMod (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FloorMod", MakeName ("FloorMod", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Performs fractional average pooling on the input.
		/// </summary>
		/// <param name="value">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FractionalAvgPool'.
		/// </param>
		/// <param name="pseudo_random">
		///   Optional argument
		///   When set to True, generates the pooling sequence in a
		///   pseudorandom fashion, otherwise, in a random fashion. Check paper [Benjamin
		///   Graham, Fractional Max-Pooling](http://arxiv.org/abs/1412.6071) for
		///   difference between pseudorandom and random.
		/// </param>
		/// <param name="overlapping">
		///   Optional argument
		///   When set to True, it means when pooling, the values at the boundary
		///   of adjacent pooling cells are used by both cells. For example:
		///   
		///   `index  0  1  2  3  4`
		///   
		///   `value  20 5  16 3  7`
		///   
		///   If the pooling sequence is [0, 2, 4], then 16, at index 2 will be used twice.
		///   The result would be [41/3, 26/3] for fractional avg pooling.
		/// </param>
		/// <param name="deterministic">
		///   Optional argument
		///   When set to True, a fixed pooling region will be used when
		///   iterating over a FractionalAvgPool node in the computation graph. Mainly used
		///   in unit test to make FractionalAvgPool deterministic.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="pooling_ratio">
		///   Pooling ratio for each dimension of `value`, currently only
		///   supports row and col dimension and should be &amp;gt;= 1.0. For example, a valid
		///   pooling ratio looks like [1.0, 1.44, 1.73, 1.0]. The first and last elements
		///   must be 1.0 because we don't allow pooling on batch and channels
		///   dimensions. 1.44 and 1.73 are pooling ratio on height and width dimensions
		///   respectively.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: output tensor after fractional avg pooling.
		///   row_pooling_sequence: row pooling sequence, needed to calculate gradient.
		///   col_pooling_sequence: column pooling sequence, needed to calculate gradient.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Fractional average pooling is similar to Fractional max pooling in the pooling
		///   region generation step. The only difference is that after pooling regions are
		///   generated, a mean operation is performed instead of a max operation in each
		///   pooling region.
		/// </remarks>
		public (TFOutput output, TFOutput row_pooling_sequence, TFOutput col_pooling_sequence) FractionalAvgPool (TFOutput value, float[] pooling_ratio, bool? pseudo_random = null, bool? overlapping = null, bool? deterministic = null, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FractionalAvgPool", MakeName ("FractionalAvgPool", operName));
			desc.AddInput (value);
			desc.SetAttr ("pooling_ratio", pooling_ratio);
			if (pseudo_random.HasValue)
				desc.SetAttr ("pseudo_random", pseudo_random.Value);
			
			if (overlapping.HasValue)
				desc.SetAttr ("overlapping", overlapping.Value);
			
			if (deterministic.HasValue)
				desc.SetAttr ("deterministic", deterministic.Value);
			
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var row_pooling_sequence = new TFOutput (op, _idx++);
			var col_pooling_sequence = new TFOutput (op, _idx++);
			return (output, row_pooling_sequence, col_pooling_sequence);
		}

		/// <summary>
		///   Computes gradient of the FractionalAvgPool function.
		/// </summary>
		/// <param name="orig_input_tensor_shape">
		///   Original input tensor shape for `fractional_avg_pool`
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, height, width, channels]`.  Gradients
		///   w.r.t. the output of `fractional_avg_pool`.
		/// </param>
		/// <param name="row_pooling_sequence">
		///   row pooling sequence, form pooling region with
		///   col_pooling_sequence.
		/// </param>
		/// <param name="col_pooling_sequence">
		///   column pooling sequence, form pooling region with
		///   row_pooling sequence.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FractionalAvgPoolGrad'.
		/// </param>
		/// <param name="overlapping">
		///   Optional argument
		///   When set to True, it means when pooling, the values at the boundary
		///   of adjacent pooling cells are used by both cells. For example:
		///   
		///   `index  0  1  2  3  4`
		///   
		///   `value  20 5  16 3  7`
		///   
		///   If the pooling sequence is [0, 2, 4], then 16, at index 2 will be used twice.
		///   The result would be [41/3, 26/3] for fractional avg pooling.
		/// </param>
		/// <returns>
		///   4-D.  Gradients w.r.t. the input of `fractional_avg_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Unlike FractionalMaxPoolGrad, we don't need to find arg_max for
		///   FractionalAvgPoolGrad, we just need to evenly back-propagate each element of
		///   out_backprop to those indices that form the same pooling cell. Therefore, we
		///   just need to know the shape of original input tensor, instead of the whole
		///   tensor.
		/// </remarks>
		public TFOutput FractionalAvgPoolGrad (TFOutput orig_input_tensor_shape, TFOutput out_backprop, TFOutput row_pooling_sequence, TFOutput col_pooling_sequence, bool? overlapping = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FractionalAvgPoolGrad", MakeName ("FractionalAvgPoolGrad", operName));
			desc.AddInput (orig_input_tensor_shape);
			desc.AddInput (out_backprop);
			desc.AddInput (row_pooling_sequence);
			desc.AddInput (col_pooling_sequence);
			if (overlapping.HasValue)
				desc.SetAttr ("overlapping", overlapping.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Performs fractional max pooling on the input.
		/// </summary>
		/// <param name="value">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FractionalMaxPool'.
		/// </param>
		/// <param name="pseudo_random">
		///   Optional argument
		///   When set to True, generates the pooling sequence in a
		///   pseudorandom fashion, otherwise, in a random fashion. Check paper [Benjamin
		///   Graham, Fractional Max-Pooling](http://arxiv.org/abs/1412.6071) for
		///   difference between pseudorandom and random.
		/// </param>
		/// <param name="overlapping">
		///   Optional argument
		///   When set to True, it means when pooling, the values at the boundary
		///   of adjacent pooling cells are used by both cells. For example:
		///   
		///   `index  0  1  2  3  4`
		///   
		///   `value  20 5  16 3  7`
		///   
		///   If the pooling sequence is [0, 2, 4], then 16, at index 2 will be used twice.
		///   The result would be [20, 16] for fractional max pooling.
		/// </param>
		/// <param name="deterministic">
		///   Optional argument
		///   When set to True, a fixed pooling region will be used when
		///   iterating over a FractionalMaxPool node in the computation graph. Mainly used
		///   in unit test to make FractionalMaxPool deterministic.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="pooling_ratio">
		///   Pooling ratio for each dimension of `value`, currently only
		///   supports row and col dimension and should be &amp;gt;= 1.0. For example, a valid
		///   pooling ratio looks like [1.0, 1.44, 1.73, 1.0]. The first and last elements
		///   must be 1.0 because we don't allow pooling on batch and channels
		///   dimensions. 1.44 and 1.73 are pooling ratio on height and width dimensions
		///   respectively.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: output tensor after fractional max pooling.
		///   row_pooling_sequence: row pooling sequence, needed to calculate gradient.
		///   col_pooling_sequence: column pooling sequence, needed to calculate gradient.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Fractional max pooling is slightly different than regular max pooling.  In
		///   regular max pooling, you downsize an input set by taking the maximum value of
		///   smaller N x N subsections of the set (often 2x2), and try to reduce the set by
		///   a factor of N, where N is an integer.  Fractional max pooling, as you might
		///   expect from the word "fractional", means that the overall reduction ratio N
		///   does not have to be an integer.
		///   
		///   The sizes of the pooling regions are generated randomly but are fairly uniform.
		///   For example, let's look at the height dimension, and the constraints on the
		///   list of rows that will be pool boundaries.
		///   
		///   First we define the following:
		///   
		///   1.  input_row_length : the number of rows from the input set
		///   2.  output_row_length : which will be smaller than the input
		///   3.  alpha = input_row_length / output_row_length : our reduction ratio
		///   4.  K = floor(alpha)
		///   5.  row_pooling_sequence : this is the result list of pool boundary rows
		///   
		///   Then, row_pooling_sequence should satisfy:
		///   
		///   1.  a[0] = 0 : the first value of the sequence is 0
		///   2.  a[end] = input_row_length : the last value of the sequence is the size
		///   3.  K &amp;lt;= (a[i+1] - a[i]) &amp;lt;= K+1 : all intervals are K or K+1 size
		///   4.  length(row_pooling_sequence) = output_row_length+1
		///   
		///   For more details on fractional max pooling, see this paper:
		///   [Benjamin Graham, Fractional Max-Pooling](http://arxiv.org/abs/1412.6071)
		/// </remarks>
		public (TFOutput output, TFOutput row_pooling_sequence, TFOutput col_pooling_sequence) FractionalMaxPool (TFOutput value, float[] pooling_ratio, bool? pseudo_random = null, bool? overlapping = null, bool? deterministic = null, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FractionalMaxPool", MakeName ("FractionalMaxPool", operName));
			desc.AddInput (value);
			desc.SetAttr ("pooling_ratio", pooling_ratio);
			if (pseudo_random.HasValue)
				desc.SetAttr ("pseudo_random", pseudo_random.Value);
			
			if (overlapping.HasValue)
				desc.SetAttr ("overlapping", overlapping.Value);
			
			if (deterministic.HasValue)
				desc.SetAttr ("deterministic", deterministic.Value);
			
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var row_pooling_sequence = new TFOutput (op, _idx++);
			var col_pooling_sequence = new TFOutput (op, _idx++);
			return (output, row_pooling_sequence, col_pooling_sequence);
		}

		/// <summary>
		///   Computes gradient of the FractionalMaxPool function.
		/// </summary>
		/// <param name="orig_input">
		///   Original input for `fractional_max_pool`
		/// </param>
		/// <param name="orig_output">
		///   Original output for `fractional_max_pool`
		/// </param>
		/// <param name="out_backprop">
		///   4-D with shape `[batch, height, width, channels]`.  Gradients
		///   w.r.t. the output of `fractional_max_pool`.
		/// </param>
		/// <param name="row_pooling_sequence">
		///   row pooling sequence, form pooling region with
		///   col_pooling_sequence.
		/// </param>
		/// <param name="col_pooling_sequence">
		///   column pooling sequence, form pooling region with
		///   row_pooling sequence.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FractionalMaxPoolGrad'.
		/// </param>
		/// <param name="overlapping">
		///   Optional argument
		///   When set to True, it means when pooling, the values at the boundary
		///   of adjacent pooling cells are used by both cells. For example:
		///   
		///   `index  0  1  2  3  4`
		///   
		///   `value  20 5  16 3  7`
		///   
		///   If the pooling sequence is [0, 2, 4], then 16, at index 2 will be used twice.
		///   The result would be [20, 16] for fractional max pooling.
		/// </param>
		/// <returns>
		///   4-D.  Gradients w.r.t. the input of `fractional_max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput FractionalMaxPoolGrad (TFOutput orig_input, TFOutput orig_output, TFOutput out_backprop, TFOutput row_pooling_sequence, TFOutput col_pooling_sequence, bool? overlapping = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FractionalMaxPoolGrad", MakeName ("FractionalMaxPoolGrad", operName));
			desc.AddInput (orig_input);
			desc.AddInput (orig_output);
			desc.AddInput (out_backprop);
			desc.AddInput (row_pooling_sequence);
			desc.AddInput (col_pooling_sequence);
			if (overlapping.HasValue)
				desc.SetAttr ("overlapping", overlapping.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Batch normalization.
		/// </summary>
		/// <param name="x">
		///   A 4D Tensor for input data.
		/// </param>
		/// <param name="scale">
		///   A 1D Tensor for scaling factor, to scale the normalized x.
		/// </param>
		/// <param name="offset">
		///   A 1D Tensor for offset, to shift to the normalized x.
		/// </param>
		/// <param name="mean">
		///   A 1D Tensor for population mean. Used for inference only;
		///   must be empty for training.
		/// </param>
		/// <param name="variance">
		///   A 1D Tensor for population variance. Used for inference only;
		///   must be empty for training.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FusedBatchNorm'.
		/// </param>
		/// <param name="epsilon">
		///   Optional argument
		///   A small float number added to the variance of x.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format for x and y. Either "NHWC" (default) or "NCHW".
		/// </param>
		/// <param name="is_training">
		///   Optional argument
		///   A bool value to indicate the operation is for training (default)
		///   or inference.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   y: A 4D Tensor for output data.
		///   batch_mean: A 1D Tensor for the computed batch mean, to be used by TensorFlow
		///   to compute the running mean.
		///   batch_variance: A 1D Tensor for the computed batch variance, to be used by
		///   TensorFlow to compute the running variance.
		///   reserve_space_1: A 1D Tensor for the computed batch mean, to be reused
		///   in the gradient computation.
		///   reserve_space_2: A 1D Tensor for the computed batch variance (inverted variance
		///   in the cuDNN case), to be used in the gradient computation.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Note that the size of 4D Tensors are defined by either "NHWC" or "NCHW".
		///   The size of 1D Tensors matches the dimension C of the 4D Tensors.
		/// </remarks>
		public (TFOutput y, TFOutput batch_mean, TFOutput batch_variance, TFOutput reserve_space_1, TFOutput reserve_space_2) FusedBatchNorm (TFOutput x, TFOutput scale, TFOutput offset, TFOutput mean, TFOutput variance, float? epsilon = null, string data_format = null, bool? is_training = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FusedBatchNorm", MakeName ("FusedBatchNorm", operName));
			desc.AddInput (x);
			desc.AddInput (scale);
			desc.AddInput (offset);
			desc.AddInput (mean);
			desc.AddInput (variance);
			if (epsilon.HasValue)
				desc.SetAttr ("epsilon", epsilon.Value);
			
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			if (is_training.HasValue)
				desc.SetAttr ("is_training", is_training.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			var batch_mean = new TFOutput (op, _idx++);
			var batch_variance = new TFOutput (op, _idx++);
			var reserve_space_1 = new TFOutput (op, _idx++);
			var reserve_space_2 = new TFOutput (op, _idx++);
			return (y, batch_mean, batch_variance, reserve_space_1, reserve_space_2);
		}

		/// <summary>
		///   Gradient for batch normalization.
		/// </summary>
		/// <param name="y_backprop">
		///   A 4D Tensor for the gradient with respect to y.
		/// </param>
		/// <param name="x">
		///   A 4D Tensor for input data.
		/// </param>
		/// <param name="scale">
		///   A 1D Tensor for scaling factor, to scale the normalized x.
		/// </param>
		/// <param name="reserve_space_1">
		///   A 1D Tensor for the computed batch mean, to be reused
		///   in the gradient computation.
		/// </param>
		/// <param name="reserve_space_2">
		///   A 1D Tensor for the computed batch variance (inverted variance
		///   in the cuDNN case), to be used in the gradient computation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FusedBatchNormGrad'.
		/// </param>
		/// <param name="epsilon">
		///   Optional argument
		///   A small float number added to the variance of x.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format for y_backprop, x, x_backprop.
		///   Either "NHWC" (default) or "NCHW".
		/// </param>
		/// <param name="is_training">
		///   Optional argument
		///   A bool value to indicate the operation is for training (default)
		///   or inference.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   x_backprop: A 4D Tensor for the gradient with respect to x.
		///   scale_backprop: A 1D Tensor for the gradient with respect to scale.
		///   offset_backprop: A 1D Tensor for the gradient with respect to offset.
		///   reserve_space_3: Unused placeholder to match the mean input in FusedBatchNorm.
		///   reserve_space_4: Unused placeholder to match the variance input
		///   in FusedBatchNorm.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Note that the size of 4D Tensors are defined by either "NHWC" or "NCHW".
		///   The size of 1D Tensors matches the dimension C of the 4D Tensors.
		/// </remarks>
		public (TFOutput x_backprop, TFOutput scale_backprop, TFOutput offset_backprop, TFOutput reserve_space_3, TFOutput reserve_space_4) FusedBatchNormGrad (TFOutput y_backprop, TFOutput x, TFOutput scale, TFOutput reserve_space_1, TFOutput reserve_space_2, float? epsilon = null, string data_format = null, bool? is_training = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FusedBatchNormGrad", MakeName ("FusedBatchNormGrad", operName));
			desc.AddInput (y_backprop);
			desc.AddInput (x);
			desc.AddInput (scale);
			desc.AddInput (reserve_space_1);
			desc.AddInput (reserve_space_2);
			if (epsilon.HasValue)
				desc.SetAttr ("epsilon", epsilon.Value);
			
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			if (is_training.HasValue)
				desc.SetAttr ("is_training", is_training.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var x_backprop = new TFOutput (op, _idx++);
			var scale_backprop = new TFOutput (op, _idx++);
			var offset_backprop = new TFOutput (op, _idx++);
			var reserve_space_3 = new TFOutput (op, _idx++);
			var reserve_space_4 = new TFOutput (op, _idx++);
			return (x_backprop, scale_backprop, offset_backprop, reserve_space_3, reserve_space_4);
		}

		/// <summary>
		///   Performs a padding as a preprocess during a convolution.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, in_channels]`.
		/// </param>
		/// <param name="paddings">
		///   A two-column matrix specifying the padding sizes. The number of
		///   rows must be the same as the rank of `input`.
		/// </param>
		/// <param name="filter">
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FusedPadConv2D'.
		/// </param>
		/// <param name="mode">
		/// </param>
		/// <param name="strides">
		///   1-D of length 4.  The stride of the sliding window for each dimension
		///   of `input`. Must be in the same order as the dimension specified with format.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Similar to FusedResizeAndPadConv2d, this op allows for an optimized
		///   implementation where the spatial padding transformation stage is fused with the
		///   im2col lookup, but in this case without the bilinear filtering required for
		///   resizing. Fusing the padding prevents the need to write out the intermediate
		///   results as whole tensors, reducing memory pressure, and we can get some latency
		///   gains by merging the transformation calculations.
		///   The data_format attribute for Conv2D isn't supported by this op, and 'NHWC'
		///   order is used instead.
		///   Internally this op uses a single per-graph scratch buffer, which means that it
		///   will block if multiple versions are being run in parallel. This is because this
		///   operator is primarily an optimization to minimize memory usage.
		/// </remarks>
		public TFOutput FusedPadConv2D (TFOutput input, TFOutput paddings, TFOutput filter, string mode, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FusedPadConv2D", MakeName ("FusedPadConv2D", operName));
			desc.AddInput (input);
			desc.AddInput (paddings);
			desc.AddInput (filter);
			desc.SetAttr ("mode", mode);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Performs a resize and padding as a preprocess during a convolution.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, in_height, in_width, in_channels]`.
		/// </param>
		/// <param name="size">
		///   A 1-D int32 Tensor of 2 elements: `new_height, new_width`.  The
		///   new size for the images.
		/// </param>
		/// <param name="paddings">
		///   A two-column matrix specifying the padding sizes. The number of
		///   rows must be the same as the rank of `input`.
		/// </param>
		/// <param name="filter">
		///   4-D with shape
		///   `[filter_height, filter_width, in_channels, out_channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'FusedResizeAndPadConv2D'.
		/// </param>
		/// <param name="resize_align_corners">
		///   Optional argument
		///   If true, rescale input by (new_height - 1) / (height - 1),
		///   which exactly aligns the 4 corners of images and resized images. If false, rescale
		///   by new_height / height. Treat similarly the width dimension.
		/// </param>
		/// <param name="mode">
		/// </param>
		/// <param name="strides">
		///   1-D of length 4.  The stride of the sliding window for each dimension
		///   of `input`. Must be in the same order as the dimension specified with format.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   It's often possible to do spatial transformations more efficiently as part of
		///   the packing stage of a convolution, so this op allows for an optimized
		///   implementation where these stages are fused together. This prevents the need to
		///   write out the intermediate results as whole tensors, reducing memory pressure,
		///   and we can get some latency gains by merging the transformation calculations.
		///   The data_format attribute for Conv2D isn't supported by this op, and defaults to
		///   'NHWC' order.
		///   Internally this op uses a single per-graph scratch buffer, which means that it
		///   will block if multiple versions are being run in parallel. This is because this
		///   operator is primarily an optimization to minimize memory usage.
		/// </remarks>
		public TFOutput FusedResizeAndPadConv2D (TFOutput input, TFOutput size, TFOutput paddings, TFOutput filter, string mode, long[] strides, string padding, bool? resize_align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "FusedResizeAndPadConv2D", MakeName ("FusedResizeAndPadConv2D", operName));
			desc.AddInput (input);
			desc.AddInput (size);
			desc.AddInput (paddings);
			desc.AddInput (filter);
			desc.SetAttr ("mode", mode);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (resize_align_corners.HasValue)
				desc.SetAttr ("resize_align_corners", resize_align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Gather slices from `params` according to `indices`.
		/// </summary>
		/// <param name="parameters">
		/// </param>
		/// <param name="indices">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Gather'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `indices` must be an integer tensor of any dimension (usually 0-D or 1-D).
		///   Produces an output tensor with shape `indices.shape + params.shape[1:]` where:
		///   
		///   ```python
		///       # Scalar indices
		///       output[:, ..., :] = params[indices, :, ... :]
		///   
		///       # Vector indices
		///       output[i, :, ..., :] = params[indices[i], :, ... :]
		///   
		///       # Higher rank indices
		///       output[i, ..., j, :, ... :] = params[indices[i, ..., j], :, ..., :]
		///   ```
		///   
		///   If `indices` is a permutation and `len(indices) == params.shape[0]` then
		///   this operation will permute `params` accordingly.
		///   
		///   `validate_indices`: DEPRECATED. If this operation is assigned to CPU, values in
		///   `indices` are always validated to be within range. If assigned to GPU,
		///   out-of-bound indices result in safe but unspecified behavior, which may include
		///   raising an error.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/Gather.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput Gather (TFOutput parameters, TFOutput indices, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Gather", MakeName ("Gather", operName));
			desc.AddInput (parameters);
			desc.AddInput (indices);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Gather values or slices from `params` according to `indices`.
		/// </summary>
		/// <param name="parameters">
		///   The tensor from which to gather values.
		/// </param>
		/// <param name="indices">
		///   Index tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'GatherNd'.
		/// </param>
		/// <returns>
		///   Values from `params` gathered from indices given by `indices`, with
		///   shape `indices.shape[:-1] + params.shape[indices.shape[-1]:]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `indices` is an integer tensor containing indices into `params`.  The last
		///   dimension of `indices` can be at most the rank of `params`:
		///   
		///       indices.shape[-1] &amp;lt;= params.rank
		///   
		///   The last dimension of `indices` corresponds to elements
		///   (if `indices.shape[-1] = params.rank`) or slices
		///   (if `indices.shape[-1] &amp;lt; params.rank`) along dimension `indices.shape[-1]`
		///   of `params`.  The output tensor has shape
		///   
		///       indices.shape[:-1] + params.shape[indices.shape[-1]:]
		///   
		///   Some examples below.
		///   
		///   Simple indexing into a matrix:
		///   
		///   ```python
		///       indices = [[0, 0], [1, 1]]
		///       params = [['a', 'b'], ['c', 'd']]
		///       output = ['a', 'd']
		///   ```
		///   
		///   Slice indexing into a matrix:
		///   
		///   ```python
		///       indices = [[1], [0]]
		///       params = [['a', 'b'], ['c', 'd']]
		///       output = [['c', 'd'], ['a', 'b']]
		///   ```
		///   
		///   Indexing into a 3-tensor:
		///   
		///   ```python
		///       indices = [[1]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = [[['a1', 'b1'], ['c1', 'd1']]]
		///   
		///   
		///       indices = [[0, 1], [1, 0]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = [['c0', 'd0'], ['a1', 'b1']]
		///   
		///   
		///       indices = [[0, 0, 1], [1, 0, 1]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = ['b0', 'b1']
		///   ```
		///   
		///   Batched indexing into a matrix:
		///   
		///   ```python
		///       indices = [[[0, 0]], [[0, 1]]]
		///       params = [['a', 'b'], ['c', 'd']]
		///       output = [['a'], ['b']]
		///   ```
		///   
		///   Batched slice indexing into a matrix:
		///   
		///   ```python
		///       indices = [[[1]], [[0]]]
		///       params = [['a', 'b'], ['c', 'd']]
		///       output = [[['c', 'd']], [['a', 'b']]]
		///   ```
		///   
		///   Batched indexing into a 3-tensor:
		///   
		///   ```python
		///       indices = [[[1]], [[0]]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = [[[['a1', 'b1'], ['c1', 'd1']]],
		///                 [[['a0', 'b0'], ['c0', 'd0']]]]
		///   
		///       indices = [[[0, 1], [1, 0]], [[0, 0], [1, 1]]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = [[['c0', 'd0'], ['a1', 'b1']],
		///                 [['a0', 'b0'], ['c1', 'd1']]]
		///   
		///   
		///       indices = [[[0, 0, 1], [1, 0, 1]], [[0, 1, 1], [1, 1, 0]]]
		///       params = [[['a0', 'b0'], ['c0', 'd0']],
		///                 [['a1', 'b1'], ['c1', 'd1']]]
		///       output = [['b0', 'b1'], ['d0', 'c1']]
		///   ```
		/// </remarks>
		public TFOutput GatherNd (TFOutput parameters, TFOutput indices, string operName = null)
		{
			var desc = new TFOperationDesc (this, "GatherNd", MakeName ("GatherNd", operName));
			desc.AddInput (parameters);
			desc.AddInput (indices);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Store the input tensor in the state of the current session.
		/// </summary>
		/// <param name="value">
		///   The tensor to be stored.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'GetSessionHandle'.
		/// </param>
		/// <returns>
		///   The handle for the tensor stored in the session state, represented
		///   as a string.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput GetSessionHandle (TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "GetSessionHandle", MakeName ("GetSessionHandle", operName));
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Store the input tensor in the state of the current session.
		/// </summary>
		/// <param name="value">
		///   The tensor to be stored.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'GetSessionHandleV2'.
		/// </param>
		/// <returns>
		///   The handle for the tensor stored in the session state, represented
		///   as a ResourceHandle object.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput GetSessionHandleV2 (TFOutput value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "GetSessionHandleV2", MakeName ("GetSessionHandleV2", operName));
			desc.AddInput (value);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Get the value of the tensor specified by its handle.
		/// </summary>
		/// <param name="handle">
		///   The handle for a tensor stored in the session state.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'GetSessionTensor'.
		/// </param>
		/// <param name="dtype">
		///   The type of the output value.
		/// </param>
		/// <returns>
		///   The tensor for the given handle.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput GetSessionTensor (TFOutput handle, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "GetSessionTensor", MakeName ("GetSessionTensor", operName));
			desc.AddInput (handle);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Returns the truth value of (x &amp;gt; y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Greater'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Greater` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Greater (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Greater", MakeName ("Greater", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns the truth value of (x &amp;gt;= y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'GreaterEqual'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `GreaterEqual` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput GreaterEqual (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "GreaterEqual", MakeName ("GreaterEqual", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Creates a non-initialized hash table.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'HashTableV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this table is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this table is shared under the given name across
		///   multiple sessions.
		/// </param>
		/// <param name="use_node_name_sharing">
		///   Optional argument
		///   If true and shared_name is empty, the table is shared
		///   using the node name.
		/// </param>
		/// <param name="key_dtype">
		///   Type of the table keys.
		/// </param>
		/// <param name="value_dtype">
		///   Type of the table values.
		/// </param>
		/// <returns>
		///   Handle to a table.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op creates a hash table, specifying the type of its keys and values.
		///   Before using the table you will have to initialize it.  After initialization the
		///   table will be immutable.
		/// </remarks>
		public TFOutput HashTableV2 (TFDataType key_dtype, TFDataType value_dtype, string container = null, string shared_name = null, bool? use_node_name_sharing = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "HashTableV2", MakeName ("HashTableV2", operName));
			desc.SetAttrType ("key_dtype", key_dtype);
			desc.SetAttrType ("value_dtype", value_dtype);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			if (use_node_name_sharing.HasValue)
				desc.SetAttr ("use_node_name_sharing", use_node_name_sharing.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var table_handle = new TFOutput (op, _idx++);
			return table_handle;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with a histogram.
		/// </summary>
		/// <param name="tag">
		///   Scalar.  Tag to use for the `Summary.Value`.
		/// </param>
		/// <param name="values">
		///   Any shape. Values to use to build the histogram.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'HistogramSummary'.
		/// </param>
		/// <returns>
		///   Scalar. Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated
		///   [`Summary`](https://www.tensorflow.org/code/tensorflow/core/framework/summary.proto)
		///   has one summary value containing a histogram for `values`.
		///   
		///   This op reports an `InvalidArgument` error if any value is not finite.
		/// </remarks>
		public TFOutput HistogramSummary (TFOutput tag, TFOutput values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "HistogramSummary", MakeName ("HistogramSummary", operName));
			desc.AddInput (tag);
			desc.AddInput (values);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Convert one or more images from HSV to RGB.
		/// </summary>
		/// <param name="images">
		///   1-D or higher rank. HSV data to convert. Last dimension must be size 3.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'HSVToRGB'.
		/// </param>
		/// <returns>
		///   `images` converted to RGB.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Outputs a tensor of the same shape as the `images` tensor, containing the RGB
		///   value of the pixels. The output is only well defined if the value in `images`
		///   are in `[0,1]`.
		///   
		///   See `rgb_to_hsv` for a description of the HSV encoding.
		/// </remarks>
		public TFOutput HSVToRGB (TFOutput images, string operName = null)
		{
			var desc = new TFOperationDesc (this, "HSVToRGB", MakeName ("HSVToRGB", operName));
			desc.AddInput (images);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Return a tensor with the same shape and contents as the input tensor or value.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Identity'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Identity (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Identity", MakeName ("Identity", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A Reader that outputs the queued work as both the key and value.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IdentityReaderV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this reader is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this reader is named in the given bucket
		///   with this shared_name. Otherwise, the node name is used instead.
		/// </param>
		/// <returns>
		///   The handle to reference the Reader.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   To use, enqueue strings in a Queue.  ReaderRead will take the front
		///   work string and output (work, work).
		/// </remarks>
		public TFOutput IdentityReaderV2 (string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IdentityReaderV2", MakeName ("IdentityReaderV2", operName));
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var reader_handle = new TFOutput (op, _idx++);
			return reader_handle;
		}

		/// <summary>
		///   Inverse fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IFFT'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most
		///     dimension of `input` is replaced with its inverse 1D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.ifft
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 1-dimensional discrete Fourier transform over the
		///   inner-most dimension of `input`.
		/// </remarks>
		public TFOutput IFFT (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IFFT", MakeName ("IFFT", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Inverse 2D fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IFFT2D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most 2
		///     dimensions of `input` are replaced with their inverse 2D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.ifft2
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 2-dimensional discrete Fourier transform over the
		///   inner-most 2 dimensions of `input`.
		/// </remarks>
		public TFOutput IFFT2D (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IFFT2D", MakeName ("IFFT2D", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Inverse 3D fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IFFT3D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same shape as `input`. The inner-most 3
		///     dimensions of `input` are replaced with their inverse 3D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.ifftn with 3 dimensions.
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 3-dimensional discrete Fourier transform over the
		///   inner-most 3 dimensions of `input`.
		/// </remarks>
		public TFOutput IFFT3D (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IFFT3D", MakeName ("IFFT3D", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Compute the lower regularized incomplete Gamma function `Q(a, x)`.
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Igamma'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The lower regularized incomplete Gamma function is defined as:
		///   
		///   
		///   \\(P(a, x) = gamma(a, x) / Gamma(a) = 1 - Q(a, x)\\)
		///   
		///   where
		///   
		///   \\(gamma(a, x) = int_{0}^{x} t^{a-1} exp(-t) dt\\)
		///   
		///   is the lower incomplete Gamma function.
		///   
		///   Note, above `Q(a, x)` (`Igammac`) is the upper regularized complete
		///   Gamma function.
		/// </remarks>
		public TFOutput Igamma (TFOutput a, TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Igamma", MakeName ("Igamma", operName));
			desc.AddInput (a);
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Compute the upper regularized incomplete Gamma function `Q(a, x)`.
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Igammac'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The upper regularized incomplete Gamma function is defined as:
		///   
		///   \\(Q(a, x) = Gamma(a, x) / Gamma(a) = 1 - P(a, x)\\)
		///   
		///   where
		///   
		///   \\(Gamma(a, x) = int_{x}^{\infty} t^{a-1} exp(-t) dt\\)
		///   
		///   is the upper incomplete Gama function.
		///   
		///   Note, above `P(a, x)` (`Igamma`) is the lower regularized complete
		///   Gamma function.
		/// </remarks>
		public TFOutput Igammac (TFOutput a, TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Igammac", MakeName ("Igammac", operName));
			desc.AddInput (a);
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns the imaginary part of a complex number.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Imag'.
		/// </param>
		/// <param name="Tout">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input` of complex numbers, this operation returns a tensor of
		///   type `float` that is the imaginary part of each element in `input`. All
		///   elements in `input` must be complex numbers of the form \\(a + bj\\), where *a*
		///   is the real part and *b* is the imaginary part returned by this operation.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'input' is [-2.25 + 4.75j, 3.25 + 5.75j]
		///   tf.imag(input) ==&amp;gt; [4.75, 5.75]
		///   ```
		/// </remarks>
		public TFOutput Imag (TFOutput input, TFDataType? Tout = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Imag", MakeName ("Imag", operName));
			desc.AddInput (input);
			if (Tout.HasValue)
				desc.SetAttrType ("Tout", Tout.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with images.
		/// </summary>
		/// <param name="tag">
		///   Scalar. Used to build the `tag` attribute of the summary values.
		/// </param>
		/// <param name="tensor">
		///   4-D of shape `[batch_size, height, width, channels]` where
		///   `channels` is 1, 3, or 4.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ImageSummary'.
		/// </param>
		/// <param name="max_images">
		///   Optional argument
		///   Max number of batch elements to generate images for.
		/// </param>
		/// <param name="bad_color">
		///   Optional argument
		///   Color to use for pixels with non-finite values.
		/// </param>
		/// <returns>
		///   Scalar. Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The summary has up to `max_images` summary values containing images. The
		///   images are built from `tensor` which must be 4-D with shape `[batch_size,
		///   height, width, channels]` and where `channels` can be:
		///   
		///   *  1: `tensor` is interpreted as Grayscale.
		///   *  3: `tensor` is interpreted as RGB.
		///   *  4: `tensor` is interpreted as RGBA.
		///   
		///   The images have the same number of channels as the input tensor. For float
		///   input, the values are normalized one image at a time to fit in the range
		///   `[0, 255]`.  `uint8` values are unchanged.  The op uses two different
		///   normalization algorithms:
		///   
		///   *  If the input values are all positive, they are rescaled so the largest one
		///      is 255.
		///   
		///   *  If any input value is negative, the values are shifted so input value 0.0
		///      is at 127.  They are then rescaled so that either the smallest value is 0,
		///      or the largest one is 255.
		///   
		///   The `tag` argument is a scalar `Tensor` of type `string`.  It is used to
		///   build the `tag` of the summary values:
		///   
		///   *  If `max_images` is 1, the summary value tag is '*tag*/image'.
		///   *  If `max_images` is greater than 1, the summary value tags are
		///      generated sequentially as '*tag*/image/0', '*tag*/image/1', etc.
		///   
		///   The `bad_color` argument is the color to use in the generated images for
		///   non-finite input values.  It is a `unit8` 1-D tensor of length `channels`.
		///   Each element must be in the range `[0, 255]` (It represents the value of a
		///   pixel in the output image).  Non-finite values in the input tensor are
		///   replaced by this tensor in the output image.  The default value is the color
		///   red.
		/// </remarks>
		public TFOutput ImageSummary (TFOutput tag, TFOutput tensor, long? max_images = null, TFTensor bad_color = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ImageSummary", MakeName ("ImageSummary", operName));
			desc.AddInput (tag);
			desc.AddInput (tensor);
			if (max_images.HasValue)
				desc.SetAttr ("max_images", max_images.Value);
			
			if (bad_color != null)
				desc.SetAttr ("bad_color", bad_color /* cstatus */);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Returns immutable tensor from memory region.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ImmutableConst'.
		/// </param>
		/// <param name="dtype">
		///   Type of the returned tensor.
		/// </param>
		/// <param name="shape">
		///   Shape of the returned tensor.
		/// </param>
		/// <param name="memory_region_name">
		///   Name of readonly memory region used by the tensor, see
		///   NewReadOnlyMemoryRegionFromFile in tensorflow::Env.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The current implementation memmaps the tensor from a file.
		/// </remarks>
		public TFOutput ImmutableConst (TFDataType dtype, TFShape shape, string memory_region_name, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ImmutableConst", MakeName ("ImmutableConst", operName));
			desc.SetAttrType ("dtype", dtype);
			desc.SetAttrShape ("shape", shape);
			desc.SetAttr ("memory_region_name", memory_region_name);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var tensor = new TFOutput (op, _idx++);
			return tensor;
		}

		/// <summary>
		///   Initializes a table from a text file.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to a table which will be initialized.
		/// </param>
		/// <param name="filename">
		///   Filename of a vocabulary text file.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'InitializeTableFromTextFileV2'.
		/// </param>
		/// <param name="vocab_size">
		///   Optional argument
		///   Number of elements of the file, use -1 if unknown.
		/// </param>
		/// <param name="delimiter">
		///   Optional argument
		///   Delimiter to separate fields in a line.
		/// </param>
		/// <param name="key_index">
		///   Column index in a line to get the table `key` values from.
		/// </param>
		/// <param name="value_index">
		///   Column index that represents information of a line to get the table
		///   `value` values from.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   It inserts one key-value pair into the table for each line of the file.
		///   The key and value is extracted from the whole line content, elements from the
		///   split line based on `delimiter` or the line number (starting from zero).
		///   Where to extract the key and value from a line is specified by `key_index` and
		///   `value_index`.
		///   
		///   - A value of -1 means use the line number(starting from zero), expects `int64`.
		///   - A value of -2 means use the whole line content, expects `string`.
		///   - A value &amp;gt;= 0 means use the index (starting at zero) of the split line based
		///     on `delimiter`.
		/// </remarks>
		public TFOperation InitializeTableFromTextFileV2 (TFOutput table_handle, TFOutput filename, long key_index, long value_index, long? vocab_size = null, string delimiter = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "InitializeTableFromTextFileV2", MakeName ("InitializeTableFromTextFileV2", operName));
			desc.AddInput (table_handle);
			desc.AddInput (filename);
			desc.SetAttr ("key_index", key_index);
			desc.SetAttr ("value_index", value_index);
			if (vocab_size.HasValue)
				desc.SetAttr ("vocab_size", vocab_size.Value);
			
			if (delimiter != null)
				desc.SetAttr ("delimiter", delimiter);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Table initializer that takes two tensors for keys and values respectively.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to a table which will be initialized.
		/// </param>
		/// <param name="keys">
		///   Keys of type Tkey.
		/// </param>
		/// <param name="values">
		///   Values of type Tval.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'InitializeTableV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation InitializeTableV2 (TFOutput table_handle, TFOutput keys, TFOutput values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "InitializeTableV2", MakeName ("InitializeTableV2", operName));
			desc.AddInput (table_handle);
			desc.AddInput (keys);
			desc.AddInput (values);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Says whether the targets are in the top `K` predictions.
		/// </summary>
		/// <param name="predictions">
		///   A `batch_size` x `classes` tensor.
		/// </param>
		/// <param name="targets">
		///   A `batch_size` vector of class ids.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'InTopK'.
		/// </param>
		/// <param name="k">
		///   Number of top elements to look at for computing precision.
		/// </param>
		/// <returns>
		///   Computed Precision at `k` as a `bool Tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This outputs a `batch_size` bool array, an entry `out[i]` is `true` if the
		///   prediction for the target class is among the top `k` predictions among
		///   all predictions for example `i`. Note that the behavior of `InTopK` differs
		///   from the `TopK` op in its handling of ties; if multiple classes have the
		///   same prediction value and straddle the top-`k` boundary, all of those
		///   classes are considered to be in the top `k`.
		///   
		///   More formally, let
		///   
		///     \\(predictions_i\\) be the predictions for all classes for example `i`,
		///     \\(targets_i\\) be the target class for example `i`,
		///     \\(out_i\\) be the output for example `i`,
		///   
		///   $$out_i = predictions_{i, targets_i} \in TopKIncludingTies(predictions_i)$$
		/// </remarks>
		public TFOutput InTopK (TFOutput predictions, TFOutput targets, long k, string operName = null)
		{
			var desc = new TFOperationDesc (this, "InTopK", MakeName ("InTopK", operName));
			desc.AddInput (predictions);
			desc.AddInput (targets);
			desc.SetAttr ("k", k);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var precision = new TFOutput (op, _idx++);
			return precision;
		}

		/// <summary>
		///   Computes the reciprocal of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Inv'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = 1 / x\\).
		/// </remarks>
		public TFOutput Inv (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Inv", MakeName ("Inv", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the inverse permutation of a tensor.
		/// </summary>
		/// <param name="x">
		///   1-D.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'InvertPermutation'.
		/// </param>
		/// <returns>
		///   1-D.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation computes the inverse of an index permutation. It takes a 1-D
		///   integer tensor `x`, which represents the indices of a zero-based array, and
		///   swaps each value with its index position. In other words, for an output tensor
		///   `y` and an input tensor `x`, this operation computes the following:
		///   
		///   `y[x[i]] = i for i in [0, 1, ..., len(x) - 1]`
		///   
		///   The values must include 0. There can be no duplicate values or negative values.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor `x` is [3, 4, 0, 2, 1]
		///   invert_permutation(x) ==&amp;gt; [2, 4, 3, 0, 1]
		///   ```
		/// </remarks>
		public TFOutput InvertPermutation (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "InvertPermutation", MakeName ("InvertPermutation", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient for the inverse of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'InvGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = -dy * y*y`, where `y = 1/x`, and `dy`
		///   is the corresponding input gradient.
		/// </remarks>
		public TFOutput InvGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "InvGrad", MakeName ("InvGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Inverse real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [1]. The FFT length.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IRFFT'.
		/// </param>
		/// <returns>
		///   A float32 tensor of the same rank as `input`. The inner-most
		///     dimension of `input` is replaced with the `fft_length` samples of its inverse
		///     1D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.irfft
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 1-dimensional discrete Fourier transform of a real-valued
		///   signal over the inner-most dimension of `input`.
		///   
		///   The inner-most dimension of `input` is assumed to be the result of `RFFT`: the
		///   `fft_length / 2 + 1` unique components of the DFT of a real-valued signal. If
		///   `fft_length` is not provided, it is computed from the size of the inner-most
		///   dimension of `input` (`fft_length = 2 * (inner - 1)`). If the FFT length used to
		///   compute `input` is odd, it should be provided since it cannot be inferred
		///   properly.
		/// </remarks>
		public TFOutput IRFFT (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IRFFT", MakeName ("IRFFT", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Inverse 2D real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [2]. The FFT length for each dimension.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IRFFT2D'.
		/// </param>
		/// <returns>
		///   A float32 tensor of the same rank as `input`. The inner-most 2
		///     dimensions of `input` are replaced with the `fft_length` samples of their
		///     inverse 2D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.irfft2
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 2-dimensional discrete Fourier transform of a real-valued
		///   signal over the inner-most 2 dimensions of `input`.
		///   
		///   The inner-most 2 dimensions of `input` are assumed to be the result of `RFFT2D`:
		///   The inner-most dimension contains the `fft_length / 2 + 1` unique components of
		///   the DFT of a real-valued signal. If `fft_length` is not provided, it is computed
		///   from the size of the inner-most 2 dimensions of `input`. If the FFT length used
		///   to compute `input` is odd, it should be provided since it cannot be inferred
		///   properly.
		/// </remarks>
		public TFOutput IRFFT2D (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IRFFT2D", MakeName ("IRFFT2D", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Inverse 3D real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A complex64 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [3]. The FFT length for each dimension.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IRFFT3D'.
		/// </param>
		/// <returns>
		///   A float32 tensor of the same rank as `input`. The inner-most 3
		///     dimensions of `input` are replaced with the `fft_length` samples of their
		///     inverse 3D real Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.irfftn with 3 dimensions.
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the inverse 3-dimensional discrete Fourier transform of a real-valued
		///   signal over the inner-most 3 dimensions of `input`.
		///   
		///   The inner-most 3 dimensions of `input` are assumed to be the result of `RFFT3D`:
		///   The inner-most dimension contains the `fft_length / 2 + 1` unique components of
		///   the DFT of a real-valued signal. If `fft_length` is not provided, it is computed
		///   from the size of the inner-most 3 dimensions of `input`. If the FFT length used
		///   to compute `input` is odd, it should be provided since it cannot be inferred
		///   properly.
		/// </remarks>
		public TFOutput IRFFT3D (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IRFFT3D", MakeName ("IRFFT3D", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns which elements of x are finite.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IsFinite'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   @compatibility(numpy)
		///   Equivalent to np.isfinite
		///   @end_compatibility
		/// </remarks>
		public TFOutput IsFinite (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IsFinite", MakeName ("IsFinite", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns which elements of x are Inf.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IsInf'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   @compatibility(numpy)
		///   Equivalent to np.isinf
		///   @end_compatibility
		/// </remarks>
		public TFOutput IsInf (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IsInf", MakeName ("IsInf", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns which elements of x are NaN.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IsNan'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   @compatibility(numpy)
		///   Equivalent to np.isnan
		///   @end_compatibility
		/// </remarks>
		public TFOutput IsNan (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IsNan", MakeName ("IsNan", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   A container for an iterator resource.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Iterator'.
		/// </param>
		/// <param name="shared_name">
		/// </param>
		/// <param name="container">
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   A handle to the iterator that can be passed to a "MakeIterator"
		///   or "IteratorGetNext" op.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Iterator (string shared_name, string container, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Iterator", MakeName ("Iterator", operName));
			desc.SetAttr ("shared_name", shared_name);
			desc.SetAttr ("container", container);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Releases any resources used by the given iterator.
		/// </summary>
		/// <param name="iterator">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IteratorDispose'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation IteratorDispose (TFOutput iterator, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IteratorDispose", MakeName ("IteratorDispose", operName));
			desc.AddInput (iterator);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Gets the next output from the given iterator.
		/// </summary>
		/// <param name="iterator">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'IteratorGetNext'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput[] IteratorGetNext (TFOutput iterator, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "IteratorGetNext", MakeName ("IteratorGetNext", operName));
			desc.AddInput (iterator);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("components");
			var components = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				components [i] = new TFOutput (op, _idx++);
			
			return components;
		}

		/// <summary>
		///   L2 Loss.
		/// </summary>
		/// <param name="t">
		///   Typically 2-D, but may have any dimensions.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'L2Loss'.
		/// </param>
		/// <returns>
		///   0-D.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes half the L2 norm of a tensor without the `sqrt`:
		///   
		///       output = sum(t ** 2) / 2
		/// </remarks>
		public TFOutput L2Loss (TFOutput t, string operName = null)
		{
			var desc = new TFOperationDesc (this, "L2Loss", MakeName ("L2Loss", operName));
			desc.AddInput (t);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a learned unigram distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LearnedUnigramCandidateSampler'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to randomly sample.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <param name="range_max">
		///   The sampler will sample integers from the interval [0, range_max).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See explanations of candidate sampling and the data formats at
		///   go/candidate-sampling.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) LearnedUnigramCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long range_max, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LearnedUnigramCandidateSampler", MakeName ("LearnedUnigramCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			desc.SetAttr ("range_max", range_max);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Returns the truth value of (x &amp;lt; y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Less'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Less` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Less (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Less", MakeName ("Less", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns the truth value of (x &amp;lt;= y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LessEqual'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `LessEqual` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput LessEqual (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LessEqual", MakeName ("LessEqual", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes the log of the absolute value of `Gamma(x)` element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Lgamma'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Lgamma (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Lgamma", MakeName ("Lgamma", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Generates values in an interval.
		/// </summary>
		/// <param name="start">
		///   First entry in the range.
		/// </param>
		/// <param name="stop">
		///   Last entry in the range.
		/// </param>
		/// <param name="num">
		///   Number of values to generate.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LinSpace'.
		/// </param>
		/// <returns>
		///   1-D. The generated values.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   A sequence of `num` evenly-spaced values are generated beginning at `start`.
		///   If `num &amp;gt; 1`, the values in the sequence increase by `stop - start / num - 1`,
		///   so that the last one is exactly `stop`.
		///   
		///   For example:
		///   
		///   ```
		///   tf.linspace(10.0, 12.0, 3, name="linspace") =&amp;gt; [ 10.0  11.0  12.0]
		///   ```
		/// </remarks>
		public TFOutput LinSpace (TFOutput start, TFOutput stop, TFOutput num, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LinSpace", MakeName ("LinSpace", operName));
			desc.AddInput (start);
			desc.AddInput (stop);
			desc.AddInput (num);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the difference between two lists of numbers or strings.
		/// </summary>
		/// <param name="x">
		///   1-D. Values to keep.
		/// </param>
		/// <param name="y">
		///   1-D. Values to remove.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ListDiff'.
		/// </param>
		/// <param name="out_idx">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 1-D. Values present in `x` but not in `y`.
		///   idx: 1-D. Positions of `x` values preserved in `out`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Given a list `x` and a list `y`, this operation returns a list `out` that
		///   represents all values that are in `x` but not in `y`. The returned list `out`
		///   is sorted in the same order that the numbers appear in `x` (duplicates are
		///   preserved). This operation also returns a list `idx` that represents the
		///   position of each `out` element in `x`. In other words:
		///   
		///   `out[i] = x[idx[i]] for i in [0, 1, ..., len(out) - 1]`
		///   
		///   For example, given this input:
		///   
		///   ```
		///   x = [1, 2, 3, 4, 5, 6]
		///   y = [1, 3, 5]
		///   ```
		///   
		///   This operation would return:
		///   
		///   ```
		///   out ==&amp;gt; [2, 4, 6]
		///   idx ==&amp;gt; [1, 3, 5]
		///   ```
		/// </remarks>
		public (TFOutput output, TFOutput idx) ListDiff (TFOutput x, TFOutput y, TFDataType? out_idx = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ListDiff", MakeName ("ListDiff", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			if (out_idx.HasValue)
				desc.SetAttrType ("out_idx", out_idx.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var idx = new TFOutput (op, _idx++);
			return (output, idx);
		}

		/// <summary>
		///   Computes natural logarithm of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Log'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = \log_e x\\).
		/// </remarks>
		public TFOutput Log (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Log", MakeName ("Log", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes natural logarithm of (1 + x) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Log1p'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = \log_e (1 + x)\\).
		/// </remarks>
		public TFOutput Log1p (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Log1p", MakeName ("Log1p", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns the truth value of x AND y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LogicalAnd'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `LogicalAnd` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput LogicalAnd (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LogicalAnd", MakeName ("LogicalAnd", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns the truth value of NOT x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LogicalNot'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput LogicalNot (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LogicalNot", MakeName ("LogicalNot", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns the truth value of x OR y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LogicalOr'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `LogicalOr` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput LogicalOr (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LogicalOr", MakeName ("LogicalOr", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes log softmax activations.
		/// </summary>
		/// <param name="logits">
		///   2-D with shape `[batch_size, num_classes]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LogSoftmax'.
		/// </param>
		/// <returns>
		///   Same shape as `logits`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For each batch `i` and class `j` we have
		///   
		///       logsoftmax[i, j] = logits[i, j] - log(sum(exp(logits[i])))
		/// </remarks>
		public TFOutput LogSoftmax (TFOutput logits, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LogSoftmax", MakeName ("LogSoftmax", operName));
			desc.AddInput (logits);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var logsoftmax = new TFOutput (op, _idx++);
			return logsoftmax;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a log-uniform distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LogUniformCandidateSampler'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to randomly sample.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <param name="range_max">
		///   The sampler will sample integers from the interval [0, range_max).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See explanations of candidate sampling and the data formats at
		///   go/candidate-sampling.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) LogUniformCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long range_max, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LogUniformCandidateSampler", MakeName ("LogUniformCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			desc.SetAttr ("range_max", range_max);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Outputs all keys and values in the table.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to the table.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LookupTableExportV2'.
		/// </param>
		/// <param name="Tkeys">
		/// </param>
		/// <param name="Tvalues">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   keys: Vector of all keys present in the table.
		///   values: Tensor of all values in the table. Indexed in parallel with `keys`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput keys, TFOutput values) LookupTableExportV2 (TFOutput table_handle, TFDataType Tkeys, TFDataType Tvalues, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LookupTableExportV2", MakeName ("LookupTableExportV2", operName));
			desc.AddInput (table_handle);
			desc.SetAttrType ("Tkeys", Tkeys);
			desc.SetAttrType ("Tvalues", Tvalues);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var keys = new TFOutput (op, _idx++);
			var values = new TFOutput (op, _idx++);
			return (keys, values);
		}

		/// <summary>
		///   Looks up keys in a table, outputs the corresponding values.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to the table.
		/// </param>
		/// <param name="keys">
		///   Any shape.  Keys to look up.
		/// </param>
		/// <param name="default_value">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LookupTableFindV2'.
		/// </param>
		/// <returns>
		///   Same shape as `keys`.  Values found in the table, or `default_values`
		///   for missing keys.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The tensor `keys` must of the same type as the keys of the table.
		///   The output `values` is of the type of the table values.
		///   
		///   The scalar `default_value` is the value output for keys not present in the
		///   table. It must also be of the same type as the table values.
		/// </remarks>
		public TFOutput LookupTableFindV2 (TFOutput table_handle, TFOutput keys, TFOutput default_value, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LookupTableFindV2", MakeName ("LookupTableFindV2", operName));
			desc.AddInput (table_handle);
			desc.AddInput (keys);
			desc.AddInput (default_value);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var values = new TFOutput (op, _idx++);
			return values;
		}

		/// <summary>
		///   Replaces the contents of the table with the specified keys and values.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to the table.
		/// </param>
		/// <param name="keys">
		///   Any shape.  Keys to look up.
		/// </param>
		/// <param name="values">
		///   Values to associate with keys.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LookupTableImportV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The tensor `keys` must be of the same type as the keys of the table.
		///   The tensor `values` must be of the type of the table values.
		/// </remarks>
		public TFOperation LookupTableImportV2 (TFOutput table_handle, TFOutput keys, TFOutput values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LookupTableImportV2", MakeName ("LookupTableImportV2", operName));
			desc.AddInput (table_handle);
			desc.AddInput (keys);
			desc.AddInput (values);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Updates the table to associates keys with values.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to the table.
		/// </param>
		/// <param name="keys">
		///   Any shape.  Keys to look up.
		/// </param>
		/// <param name="values">
		///   Values to associate with keys.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LookupTableInsertV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The tensor `keys` must be of the same type as the keys of the table.
		///   The tensor `values` must be of the type of the table values.
		/// </remarks>
		public TFOperation LookupTableInsertV2 (TFOutput table_handle, TFOutput keys, TFOutput values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LookupTableInsertV2", MakeName ("LookupTableInsertV2", operName));
			desc.AddInput (table_handle);
			desc.AddInput (keys);
			desc.AddInput (values);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Computes the number of elements in the given table.
		/// </summary>
		/// <param name="table_handle">
		///   Handle to the table.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LookupTableSizeV2'.
		/// </param>
		/// <returns>
		///   Scalar that contains number of elements in the table.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput LookupTableSizeV2 (TFOutput table_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LookupTableSizeV2", MakeName ("LookupTableSizeV2", operName));
			desc.AddInput (table_handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var size = new TFOutput (op, _idx++);
			return size;
		}

		/// <summary>
		///   Forwards the input to the output.
		/// </summary>
		/// <param name="input">
		///   A boolean scalar, representing the branch predicate of the Switch op.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LoopCond'.
		/// </param>
		/// <returns>
		///   The same tensor as `input`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operator represents the loop termination condition used by the
		///   "pivot" switches of a loop.
		/// </remarks>
		public TFOutput LoopCond (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LoopCond", MakeName ("LoopCond", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Local Response Normalization.
		/// </summary>
		/// <param name="input">
		///   4-D.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LRN'.
		/// </param>
		/// <param name="depth_radius">
		///   Optional argument
		///   0-D.  Half-width of the 1-D normalization window.
		/// </param>
		/// <param name="bias">
		///   Optional argument
		///   An offset (usually positive to avoid dividing by 0).
		/// </param>
		/// <param name="alpha">
		///   Optional argument
		///   A scale factor, usually positive.
		/// </param>
		/// <param name="beta">
		///   Optional argument
		///   An exponent.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The 4-D `input` tensor is treated as a 3-D array of 1-D vectors (along the last
		///   dimension), and each vector is normalized independently.  Within a given vector,
		///   each component is divided by the weighted, squared sum of inputs within
		///   `depth_radius`.  In detail,
		///   
		///       sqr_sum[a, b, c, d] =
		///           sum(input[a, b, c, d - depth_radius : d + depth_radius + 1] ** 2)
		///       output = input / (bias + alpha * sqr_sum) ** beta
		///   
		///   For details, see [Krizhevsky et al., ImageNet classification with deep
		///   convolutional neural networks (NIPS 2012)](http://papers.nips.cc/paper/4824-imagenet-classification-with-deep-convolutional-neural-networks).
		/// </remarks>
		public TFOutput LRN (TFOutput input, long? depth_radius = null, float? bias = null, float? alpha = null, float? beta = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LRN", MakeName ("LRN", operName));
			desc.AddInput (input);
			if (depth_radius.HasValue)
				desc.SetAttr ("depth_radius", depth_radius.Value);
			
			if (bias.HasValue)
				desc.SetAttr ("bias", bias.Value);
			
			if (alpha.HasValue)
				desc.SetAttr ("alpha", alpha.Value);
			
			if (beta.HasValue)
				desc.SetAttr ("beta", beta.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Gradients for Local Response Normalization.
		/// </summary>
		/// <param name="input_grads">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="input_image">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="output_image">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'LRNGrad'.
		/// </param>
		/// <param name="depth_radius">
		///   Optional argument
		///   A depth radius.
		/// </param>
		/// <param name="bias">
		///   Optional argument
		///   An offset (usually &amp;gt; 0 to avoid dividing by 0).
		/// </param>
		/// <param name="alpha">
		///   Optional argument
		///   A scale factor, usually positive.
		/// </param>
		/// <param name="beta">
		///   Optional argument
		///   An exponent.
		/// </param>
		/// <returns>
		///   The gradients for LRN.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput LRNGrad (TFOutput input_grads, TFOutput input_image, TFOutput output_image, long? depth_radius = null, float? bias = null, float? alpha = null, float? beta = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "LRNGrad", MakeName ("LRNGrad", operName));
			desc.AddInput (input_grads);
			desc.AddInput (input_image);
			desc.AddInput (output_image);
			if (depth_radius.HasValue)
				desc.SetAttr ("depth_radius", depth_radius.Value);
			
			if (bias.HasValue)
				desc.SetAttr ("bias", bias.Value);
			
			if (alpha.HasValue)
				desc.SetAttr ("alpha", alpha.Value);
			
			if (beta.HasValue)
				desc.SetAttr ("beta", beta.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Makes a new iterator from the given `dataset` and stores it in `iterator`.
		/// </summary>
		/// <param name="dataset">
		/// </param>
		/// <param name="iterator">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MakeIterator'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This operation may be executed multiple times. Each execution will reset the
		///   iterator in `iterator` to the first element of `dataset`.
		/// </remarks>
		public TFOperation MakeIterator (TFOutput dataset, TFOutput iterator, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MakeIterator", MakeName ("MakeIterator", operName));
			desc.AddInput (dataset);
			desc.AddInput (iterator);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Returns the set of files matching one or more glob patterns.
		/// </summary>
		/// <param name="pattern">
		///   Shell wildcard pattern(s). Scalar or vector of type string.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatchingFiles'.
		/// </param>
		/// <returns>
		///   A vector of matching filenames.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Note that this routine only supports wildcard characters in the
		///   basename portion of the pattern, not in the directory portion.
		/// </remarks>
		public TFOutput MatchingFiles (TFOutput pattern, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatchingFiles", MakeName ("MatchingFiles", operName));
			desc.AddInput (pattern);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var filenames = new TFOutput (op, _idx++);
			return filenames;
		}

		/// <summary>
		///   Multiply the matrix "a" by the matrix "b".
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="b">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatMul'.
		/// </param>
		/// <param name="transpose_a">
		///   Optional argument
		///   If true, "a" is transposed before multiplication.
		/// </param>
		/// <param name="transpose_b">
		///   Optional argument
		///   If true, "b" is transposed before multiplication.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The inputs must be two-dimensional matrices and the inner dimension of
		///   "a" (after being transposed if transpose_a is true) must match the
		///   outer dimension of "b" (after being transposed if transposed_b is
		///   true).
		///   
		///   *Note*: The default kernel implementation for MatMul on GPUs uses
		///   cublas.
		/// </remarks>
		public TFOutput MatMul (TFOutput a, TFOutput b, bool? transpose_a = null, bool? transpose_b = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatMul", MakeName ("MatMul", operName));
			desc.AddInput (a);
			desc.AddInput (b);
			if (transpose_a.HasValue)
				desc.SetAttr ("transpose_a", transpose_a.Value);
			
			if (transpose_b.HasValue)
				desc.SetAttr ("transpose_b", transpose_b.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var product = new TFOutput (op, _idx++);
			return product;
		}

		/// <summary>
		///   Copy a tensor setting everything outside a central band in each innermost matrix
		/// </summary>
		/// <param name="input">
		///   Rank `k` tensor.
		/// </param>
		/// <param name="num_lower">
		///   0-D tensor. Number of subdiagonals to keep. If negative, keep entire
		///   lower triangle.
		/// </param>
		/// <param name="num_upper">
		///   0-D tensor. Number of superdiagonals to keep. If negative, keep
		///   entire upper triangle.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixBandPart'.
		/// </param>
		/// <returns>
		///   Rank `k` tensor of the same shape as input. The extracted banded tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   to zero.
		///   
		///   The `band` part is computed as follows:
		///   Assume `input` has `k` dimensions `[I, J, K, ..., M, N]`, then the output is a
		///   tensor with the same shape where
		///   
		///   `band[i, j, k, ..., m, n] = in_band(m, n) * input[i, j, k, ..., m, n]`.
		///   
		///   The indicator function
		///   
		///   `in_band(m, n) = (num_lower &amp;lt; 0 || (m-n) &amp;lt;= num_lower)) &amp;&amp;
		///                    (num_upper &amp;lt; 0 || (n-m) &amp;lt;= num_upper)`.
		///   
		///   For example:
		///   
		///   ```
		///   # if 'input' is [[ 0,  1,  2, 3]
		///                    [-1,  0,  1, 2]
		///                    [-2, -1,  0, 1]
		///                    [-3, -2, -1, 0]],
		///   
		///   tf.matrix_band_part(input, 1, -1) ==&amp;gt; [[ 0,  1,  2, 3]
		///                                          [-1,  0,  1, 2]
		///                                          [ 0, -1,  0, 1]
		///                                          [ 0,  0, -1, 0]],
		///   
		///   tf.matrix_band_part(input, 2, 1) ==&amp;gt; [[ 0,  1,  0, 0]
		///                                         [-1,  0,  1, 0]
		///                                         [-2, -1,  0, 1]
		///                                         [ 0, -2, -1, 0]]
		///   ```
		///   
		///   Useful special cases:
		///   
		///   ```
		///    tf.matrix_band_part(input, 0, -1) ==&amp;gt; Upper triangular part.
		///    tf.matrix_band_part(input, -1, 0) ==&amp;gt; Lower triangular part.
		///    tf.matrix_band_part(input, 0, 0) ==&amp;gt; Diagonal.
		///   ```
		/// </remarks>
		public TFOutput MatrixBandPart (TFOutput input, TFOutput num_lower, TFOutput num_upper, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixBandPart", MakeName ("MatrixBandPart", operName));
			desc.AddInput (input);
			desc.AddInput (num_lower);
			desc.AddInput (num_upper);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var band = new TFOutput (op, _idx++);
			return band;
		}

		/// <summary>
		///   Computes the determinant of one ore more square matrices.
		/// </summary>
		/// <param name="input">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixDeterminant'.
		/// </param>
		/// <returns>
		///   Shape is `[...]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The input is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions
		///   form square matrices. The output is a tensor containing the determinants
		///   for all input submatrices `[..., :, :]`.
		/// </remarks>
		public TFOutput MatrixDeterminant (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixDeterminant", MakeName ("MatrixDeterminant", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns a batched diagonal tensor with a given batched diagonal values.
		/// </summary>
		/// <param name="diagonal">
		///   Rank `k`, where `k &amp;gt;= 1`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixDiag'.
		/// </param>
		/// <returns>
		///   Rank `k+1`, with `output.shape = diagonal.shape + [diagonal.shape[-1]]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a `diagonal`, this operation returns a tensor with the `diagonal` and
		///   everything else padded with zeros. The diagonal is computed as follows:
		///   
		///   Assume `diagonal` has `k` dimensions `[I, J, K, ..., N]`, then the output is a
		///   tensor of rank `k+1` with dimensions [I, J, K, ..., N, N]` where:
		///   
		///   `output[i, j, k, ..., m, n] = 1{m=n} * diagonal[i, j, k, ..., n]`.
		///   
		///   For example:
		///   
		///   ```
		///   # 'diagonal' is [[1, 2, 3, 4], [5, 6, 7, 8]]
		///   
		///   and diagonal.shape = (2, 4)
		///   
		///   tf.matrix_diag(diagonal) ==&amp;gt; [[[1, 0, 0, 0]
		///                                        [0, 2, 0, 0]
		///                                        [0, 0, 3, 0]
		///                                        [0, 0, 0, 4]],
		///                                       [[5, 0, 0, 0]
		///                                        [0, 6, 0, 0]
		///                                        [0, 0, 7, 0]
		///                                        [0, 0, 0, 8]]]
		///   
		///   which has shape (2, 4, 4)
		///   ```
		/// </remarks>
		public TFOutput MatrixDiag (TFOutput diagonal, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixDiag", MakeName ("MatrixDiag", operName));
			desc.AddInput (diagonal);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the batched diagonal part of a batched tensor.
		/// </summary>
		/// <param name="input">
		///   Rank `k` tensor where `k &amp;gt;= 2`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixDiagPart'.
		/// </param>
		/// <returns>
		///   The extracted diagonal(s) having shape
		///   `diagonal.shape = input.shape[:-2] + [min(input.shape[-2:])]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns a tensor with the `diagonal` part
		///   of the batched `input`. The `diagonal` part is computed as follows:
		///   
		///   Assume `input` has `k` dimensions `[I, J, K, ..., M, N]`, then the output is a
		///   tensor of rank `k - 1` with dimensions `[I, J, K, ..., min(M, N)]` where:
		///   
		///   `diagonal[i, j, k, ..., n] = input[i, j, k, ..., n, n]`.
		///   
		///   The input must be at least a matrix.
		///   
		///   For example:
		///   
		///   ```
		///   # 'input' is [[[1, 0, 0, 0]
		///                  [0, 2, 0, 0]
		///                  [0, 0, 3, 0]
		///                  [0, 0, 0, 4]],
		///                 [[5, 0, 0, 0]
		///                  [0, 6, 0, 0]
		///                  [0, 0, 7, 0]
		///                  [0, 0, 0, 8]]]
		///   
		///   and input.shape = (2, 4, 4)
		///   
		///   tf.matrix_diag_part(input) ==&amp;gt; [[1, 2, 3, 4], [5, 6, 7, 8]]
		///   
		///   which has shape (2, 4)
		///   ```
		/// </remarks>
		public TFOutput MatrixDiagPart (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixDiagPart", MakeName ("MatrixDiagPart", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var diagonal = new TFOutput (op, _idx++);
			return diagonal;
		}

		/// <summary>
		///   Computes the inverse of one or more square invertible matrices or their
		/// </summary>
		/// <param name="input">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixInverse'.
		/// </param>
		/// <param name="adjoint">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Shape is `[..., M, M]`.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.linalg.inv
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   adjoints (conjugate transposes).
		///   
		///   The input is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions
		///   form square matrices. The output is a tensor of the same shape as the input
		///   containing the inverse for all input submatrices `[..., :, :]`.
		///   
		///   The op uses LU decomposition with partial pivoting to compute the inverses.
		///   
		///   If a matrix is not invertible there is no guarantee what the op does. It
		///   may detect the condition and raise an exception or it may simply return a
		///   garbage result.
		/// </remarks>
		public TFOutput MatrixInverse (TFOutput input, bool? adjoint = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixInverse", MakeName ("MatrixInverse", operName));
			desc.AddInput (input);
			if (adjoint.HasValue)
				desc.SetAttr ("adjoint", adjoint.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns a batched matrix tensor with new batched diagonal values.
		/// </summary>
		/// <param name="input">
		///   Rank `k+1`, where `k &amp;gt;= 1`.
		/// </param>
		/// <param name="diagonal">
		///   Rank `k`, where `k &amp;gt;= 1`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixSetDiag'.
		/// </param>
		/// <returns>
		///   Rank `k+1`, with `output.shape = input.shape`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given `input` and `diagonal`, this operation returns a tensor with the
		///   same shape and values as `input`, except for the main diagonal of the
		///   innermost matrices.  These will be overwritten by the values in `diagonal`.
		///   
		///   The output is computed as follows:
		///   
		///   Assume `input` has `k+1` dimensions `[I, J, K, ..., M, N]` and `diagonal` has
		///   `k` dimensions `[I, J, K, ..., min(M, N)]`.  Then the output is a
		///   tensor of rank `k+1` with dimensions `[I, J, K, ..., M, N]` where:
		///   
		///     * `output[i, j, k, ..., m, n] = diagonal[i, j, k, ..., n]` for `m == n`.
		///     * `output[i, j, k, ..., m, n] = input[i, j, k, ..., m, n]` for `m != n`.
		/// </remarks>
		public TFOutput MatrixSetDiag (TFOutput input, TFOutput diagonal, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixSetDiag", MakeName ("MatrixSetDiag", operName));
			desc.AddInput (input);
			desc.AddInput (diagonal);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Solves systems of linear equations.
		/// </summary>
		/// <param name="matrix">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="rhs">
		///   Shape is `[..., M, K]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixSolve'.
		/// </param>
		/// <param name="adjoint">
		///   Optional argument
		///   Boolean indicating whether to solve with `matrix` or its (block-wise)
		///   adjoint.
		/// </param>
		/// <returns>
		///   Shape is `[..., M, K]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `Matrix` is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions
		///   form square matrices. `Rhs` is a tensor of shape `[..., M, K]`. The `output` is
		///   a tensor shape `[..., M, K]`.  If `adjoint` is `False` then each output matrix
		///   satisfies `matrix[..., :, :] * output[..., :, :] = rhs[..., :, :]`.
		///   If `adjoint` is `True` then each output matrix satisfies
		///   `adjoint(matrix[..., :, :]) * output[..., :, :] = rhs[..., :, :]`.
		/// </remarks>
		public TFOutput MatrixSolve (TFOutput matrix, TFOutput rhs, bool? adjoint = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixSolve", MakeName ("MatrixSolve", operName));
			desc.AddInput (matrix);
			desc.AddInput (rhs);
			if (adjoint.HasValue)
				desc.SetAttr ("adjoint", adjoint.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Solves one or more linear least-squares problems.
		/// </summary>
		/// <param name="matrix">
		///   Shape is `[..., M, N]`.
		/// </param>
		/// <param name="rhs">
		///   Shape is `[..., M, K]`.
		/// </param>
		/// <param name="l2_regularizer">
		///   Scalar tensor.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.linalg.lstsq
		///   @end_compatibility
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixSolveLs'.
		/// </param>
		/// <param name="fast">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Shape is `[..., N, K]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `matrix` is a tensor of shape `[..., M, N]` whose inner-most 2 dimensions
		///   form matrices of size `[M, N]`. Rhs is a tensor of shape `[..., M, K]`.
		///   The output is a tensor shape `[..., N, K]` where each output matrix solves
		///   each of the equations matrix[..., :, :] * output[..., :, :] = rhs[..., :, :]
		///   in the least squares sense.
		///   
		///   matrix and right-hand sides in the batch:
		///   
		///   `matrix`=\\(A \in \Re^{m \times n}\\),
		///   `rhs`=\\(B  \in \Re^{m \times k}\\),
		///   `output`=\\(X  \in \Re^{n \times k}\\),
		///   `l2_regularizer`=\\(\lambda\\).
		///   
		///   If `fast` is `True`, then the solution is computed by solving the normal
		///   equations using Cholesky decomposition. Specifically, if \\(m \ge n\\) then
		///   \\(X = (A^T A + \lambda I)^{-1} A^T B\\), which solves the least-squares
		///   problem \\(X = \mathrm{argmin}_{Z \in \Re^{n \times k} } ||A Z - B||_F^2 +
		///   \lambda ||Z||_F^2\\). If \\(m \lt n\\) then `output` is computed as
		///   \\(X = A^T (A A^T + \lambda I)^{-1} B\\), which (for \\(\lambda = 0\\)) is the
		///   minimum-norm solution to the under-determined linear system, i.e.
		///   \\(X = \mathrm{argmin}_{Z \in \Re^{n \times k} } ||Z||_F^2 \\), subject to
		///   \\(A Z = B\\). Notice that the fast path is only numerically stable when
		///   \\(A\\) is numerically full rank and has a condition number
		///   \\(\mathrm{cond}(A) \lt \frac{1}{\sqrt{\epsilon_{mach} } }\\) or\\(\lambda\\) is
		///   sufficiently large.
		///   
		///   If `fast` is `False` an algorithm based on the numerically robust complete
		///   orthogonal decomposition is used. This computes the minimum-norm
		///   least-squares solution, even when \\(A\\) is rank deficient. This path is
		///   typically 6-7 times slower than the fast path. If `fast` is `False` then
		///   `l2_regularizer` is ignored.
		/// </remarks>
		public TFOutput MatrixSolveLs (TFOutput matrix, TFOutput rhs, TFOutput l2_regularizer, bool? fast = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixSolveLs", MakeName ("MatrixSolveLs", operName));
			desc.AddInput (matrix);
			desc.AddInput (rhs);
			desc.AddInput (l2_regularizer);
			if (fast.HasValue)
				desc.SetAttr ("fast", fast.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Solves systems of linear equations with upper or lower triangular matrices by
		/// </summary>
		/// <param name="matrix">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="rhs">
		///   Shape is `[..., M, K]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MatrixTriangularSolve'.
		/// </param>
		/// <param name="lower">
		///   Optional argument
		///   Boolean indicating whether the innermost matrices in `matrix` are
		///   lower or upper triangular.
		/// </param>
		/// <param name="adjoint">
		///   Optional argument
		///   Boolean indicating whether to solve with `matrix` or its (block-wise)
		///            adjoint.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.linalg.triangular_solve
		///   @end_compatibility
		/// </param>
		/// <returns>
		///   Shape is `[..., M, K]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   backsubstitution.
		///   
		///   `matrix` is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions form
		///   square matrices. If `lower` is `True` then the strictly upper triangular part
		///   of each inner-most matrix is assumed to be zero and not accessed.
		///   If `lower` is False then the strictly lower triangular part of each inner-most
		///   matrix is assumed to be zero and not accessed.
		///   `rhs` is a tensor of shape `[..., M, K]`.
		///   
		///   The output is a tensor of shape `[..., M, K]`. If `adjoint` is
		///   `True` then the innermost matrices in output` satisfy matrix equations
		///   `matrix[..., :, :] * output[..., :, :] = rhs[..., :, :]`.
		///   If `adjoint` is `False` then the strictly then the  innermost matrices in
		///   `output` satisfy matrix equations
		///   `adjoint(matrix[..., i, k]) * output[..., k, j] = rhs[..., i, j]`.
		/// </remarks>
		public TFOutput MatrixTriangularSolve (TFOutput matrix, TFOutput rhs, bool? lower = null, bool? adjoint = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MatrixTriangularSolve", MakeName ("MatrixTriangularSolve", operName));
			desc.AddInput (matrix);
			desc.AddInput (rhs);
			if (lower.HasValue)
				desc.SetAttr ("lower", lower.Value);
			
			if (adjoint.HasValue)
				desc.SetAttr ("adjoint", adjoint.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the maximum of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Max'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Max (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Max", MakeName ("Max", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the max of x and y (i.e. x &amp;gt; y ? x : y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Maximum'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Maximum` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Maximum (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Maximum", MakeName ("Maximum", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Performs max pooling on the input.
		/// </summary>
		/// <param name="input">
		///   4-D input to pool over.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPool'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The max pooled output tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPool (TFOutput input, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPool", MakeName ("MaxPool", operName));
			desc.AddInput (input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Performs 3D max pooling on the input.
		/// </summary>
		/// <param name="input">
		///   Shape `[batch, depth, rows, cols, channels]` tensor to pool over.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPool3D'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   1-D tensor of length 5. The size of the window for each dimension of
		///   the input tensor. Must have `ksize[0] = ksize[4] = 1`.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The max pooled output tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPool3D (TFOutput input, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPool3D", MakeName ("MaxPool3D", operName));
			desc.AddInput (input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients of max pooling function.
		/// </summary>
		/// <param name="orig_input">
		///   The original input tensor.
		/// </param>
		/// <param name="orig_output">
		///   The original output tensor.
		/// </param>
		/// <param name="grad">
		///   Output backprop of shape `[batch, depth, rows, cols, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPool3DGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   1-D tensor of length 5. The size of the window for each dimension of
		///   the input tensor. Must have `ksize[0] = ksize[4] = 1`.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPool3DGrad (TFOutput orig_input, TFOutput orig_output, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPool3DGrad", MakeName ("MaxPool3DGrad", operName));
			desc.AddInput (orig_input);
			desc.AddInput (orig_output);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes second-order gradients of the maxpooling function.
		/// </summary>
		/// <param name="orig_input">
		///   The original input tensor.
		/// </param>
		/// <param name="orig_output">
		///   The original output tensor.
		/// </param>
		/// <param name="grad">
		///   Output backprop of shape `[batch, depth, rows, cols, channels]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPool3DGradGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   The data format of the input and output data. With the
		///   default format "NDHWC", the data is stored in the order of:
		///       [batch, in_depth, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCDHW", the data storage order is:
		///       [batch, in_channels, in_depth, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   1-D tensor of length 5. The size of the window for each dimension of
		///   the input tensor. Must have `ksize[0] = ksize[4] = 1`.
		/// </param>
		/// <param name="strides">
		///   1-D tensor of length 5. The stride of the sliding window for each
		///   dimension of `input`. Must have `strides[0] = strides[4] = 1`.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Gradients of gradients w.r.t. the input to `max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPool3DGradGrad (TFOutput orig_input, TFOutput orig_output, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPool3DGradGrad", MakeName ("MaxPool3DGradGrad", operName));
			desc.AddInput (orig_input);
			desc.AddInput (orig_output);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients of the maxpooling function.
		/// </summary>
		/// <param name="orig_input">
		///   The original input tensor.
		/// </param>
		/// <param name="orig_output">
		///   The original output tensor.
		/// </param>
		/// <param name="grad">
		///   4-D.  Gradients w.r.t. the output of `max_pool`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPoolGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Gradients w.r.t. the input to `max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPoolGrad (TFOutput orig_input, TFOutput orig_output, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPoolGrad", MakeName ("MaxPoolGrad", operName));
			desc.AddInput (orig_input);
			desc.AddInput (orig_output);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes second-order gradients of the maxpooling function.
		/// </summary>
		/// <param name="orig_input">
		///   The original input tensor.
		/// </param>
		/// <param name="orig_output">
		///   The original output tensor.
		/// </param>
		/// <param name="grad">
		///   4-D.  Gradients of gradients w.r.t. the input of `max_pool`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPoolGradGrad'.
		/// </param>
		/// <param name="data_format">
		///   Optional argument
		///   Specify the data format of the input and output data. With the
		///   default format "NHWC", the data is stored in the order of:
		///       [batch, in_height, in_width, in_channels].
		///   Alternatively, the format could be "NCHW", the data storage order of:
		///       [batch, in_channels, in_height, in_width].
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Gradients of gradients w.r.t. the input to `max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPoolGradGrad (TFOutput orig_input, TFOutput orig_output, TFOutput grad, long[] ksize, long[] strides, string padding, string data_format = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPoolGradGrad", MakeName ("MaxPoolGradGrad", operName));
			desc.AddInput (orig_input);
			desc.AddInput (orig_output);
			desc.AddInput (grad);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (data_format != null)
				desc.SetAttr ("data_format", data_format);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes second-order gradients of the maxpooling function.
		/// </summary>
		/// <param name="input">
		///   The original input.
		/// </param>
		/// <param name="grad">
		///   4-D with shape `[batch, height, width, channels]`.  Gradients w.r.t. the
		///   input of `max_pool`.
		/// </param>
		/// <param name="argmax">
		///   The indices of the maximum values chosen for each output of `max_pool`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPoolGradGradWithArgmax'.
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Gradients of gradients w.r.t. the input of `max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPoolGradGradWithArgmax (TFOutput input, TFOutput grad, TFOutput argmax, long[] ksize, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPoolGradGradWithArgmax", MakeName ("MaxPoolGradGradWithArgmax", operName));
			desc.AddInput (input);
			desc.AddInput (grad);
			desc.AddInput (argmax);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients of the maxpooling function.
		/// </summary>
		/// <param name="input">
		///   The original input.
		/// </param>
		/// <param name="grad">
		///   4-D with shape `[batch, height, width, channels]`.  Gradients w.r.t. the
		///   output of `max_pool`.
		/// </param>
		/// <param name="argmax">
		///   The indices of the maximum values chosen for each output of `max_pool`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPoolGradWithArgmax'.
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Gradients w.r.t. the input of `max_pool`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput MaxPoolGradWithArgmax (TFOutput input, TFOutput grad, TFOutput argmax, long[] ksize, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPoolGradWithArgmax", MakeName ("MaxPoolGradWithArgmax", operName));
			desc.AddInput (input);
			desc.AddInput (grad);
			desc.AddInput (argmax);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Performs max pooling on the input and outputs both max values and indices.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, height, width, channels]`.  Input to pool over.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MaxPoolWithArgmax'.
		/// </param>
		/// <param name="Targmax">
		///   Optional argument
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the
		///   input tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: The max pooled output tensor.
		///   argmax: 4-D.  The flattened indices of the max values chosen for each output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The indices in `argmax` are flattened, so that a maximum value at position
		///   `[b, y, x, c]` becomes flattened index
		///   `((b * height + y) * width + x) * channels + c`.
		/// </remarks>
		public (TFOutput output, TFOutput argmax) MaxPoolWithArgmax (TFOutput input, long[] ksize, long[] strides, string padding, TFDataType? Targmax = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MaxPoolWithArgmax", MakeName ("MaxPoolWithArgmax", operName));
			desc.AddInput (input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (Targmax.HasValue)
				desc.SetAttrType ("Targmax", Targmax.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var argmax = new TFOutput (op, _idx++);
			return (output, argmax);
		}

		/// <summary>
		///   Computes the mean of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Mean'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Mean (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Mean", MakeName ("Mean", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Forwards the value of an available tensor from `inputs` to `output`.
		/// </summary>
		/// <param name="inputs">
		///   The input tensors, exactly one of which will become available.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Merge'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: Will be set to the available input tensor.
		///   value_index: The index of the chosen input tensor in `inputs`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   `Merge` waits for at least one of the tensors in `inputs` to become available.
		///   It is usually combined with `Switch` to implement branching.
		///   
		///   `Merge` forwards the first tensor to become available to `output`, and sets
		///   `value_index` to its index in `inputs`.
		/// </remarks>
		public (TFOutput output, TFOutput value_index) Merge (TFOutput[] inputs, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Merge", MakeName ("Merge", operName));
			desc.AddInputs (inputs);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var value_index = new TFOutput (op, _idx++);
			return (output, value_index);
		}

		/// <summary>
		///   Merges summaries.
		/// </summary>
		/// <param name="inputs">
		///   Can be of any shape.  Each must contain serialized `Summary` protocol
		///   buffers.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MergeSummary'.
		/// </param>
		/// <returns>
		///   Scalar. Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op creates a
		///   [`Summary`](https://www.tensorflow.org/code/tensorflow/core/framework/summary.proto)
		///   protocol buffer that contains the union of all the values in the input
		///   summaries.
		///   
		///   When the Op is run, it reports an `InvalidArgument` error if multiple values
		///   in the summaries to merge use the same tag.
		/// </remarks>
		public TFOutput MergeSummary (TFOutput[] inputs, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MergeSummary", MakeName ("MergeSummary", operName));
			desc.AddInputs (inputs);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   V2 format specific: merges the metadata files of sharded checkpoints.  The
		/// </summary>
		/// <param name="checkpoint_prefixes">
		///   prefixes of V2 checkpoints to merge.
		/// </param>
		/// <param name="destination_prefix">
		///   scalar.  The desired final prefix.  Allowed to be the same
		///   as one of the checkpoint_prefixes.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MergeV2Checkpoints'.
		/// </param>
		/// <param name="delete_old_dirs">
		///   Optional argument
		///   see above.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   result is one logical checkpoint, with one physical metadata file and renamed
		///   data files.
		///   
		///   Intended for "grouping" multiple checkpoints in a sharded checkpoint setup.
		///   
		///   If delete_old_dirs is true, attempts to delete recursively the dirname of each
		///   path in the input checkpoint_prefixes.  This is useful when those paths are non
		///   user-facing temporary locations.
		/// </remarks>
		public TFOperation MergeV2Checkpoints (TFOutput checkpoint_prefixes, TFOutput destination_prefix, bool? delete_old_dirs = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MergeV2Checkpoints", MakeName ("MergeV2Checkpoints", operName));
			desc.AddInput (checkpoint_prefixes);
			desc.AddInput (destination_prefix);
			if (delete_old_dirs.HasValue)
				desc.SetAttr ("delete_old_dirs", delete_old_dirs.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Transforms a spectrogram into a form that's useful for speech recognition.
		/// </summary>
		/// <param name="spectrogram">
		///   Typically produced by the Spectrogram op, with magnitude_squared
		///   set to true.
		/// </param>
		/// <param name="sample_rate">
		///   How many samples per second the source audio used.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Mfcc'.
		/// </param>
		/// <param name="upper_frequency_limit">
		///   Optional argument
		///   The highest frequency to use when calculating the
		///   ceptstrum.
		/// </param>
		/// <param name="lower_frequency_limit">
		///   Optional argument
		///   The lowest frequency to use when calculating the
		///   ceptstrum.
		/// </param>
		/// <param name="filterbank_channel_count">
		///   Optional argument
		///   Resolution of the Mel bank used internally.
		/// </param>
		/// <param name="dct_coefficient_count">
		///   Optional argument
		///   How many output channels to produce per time slice.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Mel Frequency Cepstral Coefficients are a way of representing audio data that's
		///   been effective as an input feature for machine learning. They are created by
		///   taking the spectrum of a spectrogram (a 'cepstrum'), and discarding some of the
		///   higher frequencies that are less significant to the human ear. They have a long
		///   history in the speech recognition world, and https://en.wikipedia.org/wiki/Mel-frequency_cepstrum
		///   is a good resource to learn more.
		/// </remarks>
		public TFOutput Mfcc (TFOutput spectrogram, TFOutput sample_rate, float? upper_frequency_limit = null, float? lower_frequency_limit = null, long? filterbank_channel_count = null, long? dct_coefficient_count = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Mfcc", MakeName ("Mfcc", operName));
			desc.AddInput (spectrogram);
			desc.AddInput (sample_rate);
			if (upper_frequency_limit.HasValue)
				desc.SetAttr ("upper_frequency_limit", upper_frequency_limit.Value);
			
			if (lower_frequency_limit.HasValue)
				desc.SetAttr ("lower_frequency_limit", lower_frequency_limit.Value);
			
			if (filterbank_channel_count.HasValue)
				desc.SetAttr ("filterbank_channel_count", filterbank_channel_count.Value);
			
			if (dct_coefficient_count.HasValue)
				desc.SetAttr ("dct_coefficient_count", dct_coefficient_count.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the minimum of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Min'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Min (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Min", MakeName ("Min", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the min of x and y (i.e. x &amp;lt; y ? x : y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Minimum'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Minimum` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Minimum (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Minimum", MakeName ("Minimum", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Pads a tensor with mirrored values.
		/// </summary>
		/// <param name="input">
		///   The input tensor to be padded.
		/// </param>
		/// <param name="paddings">
		///   A two-column matrix specifying the padding sizes. The number of
		///   rows must be the same as the rank of `input`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MirrorPad'.
		/// </param>
		/// <param name="mode">
		///   Either `REFLECT` or `SYMMETRIC`. In reflect mode the padded regions
		///   do not include the borders, while in symmetric mode the padded regions
		///   do include the borders. For example, if `input` is `[1, 2, 3]` and `paddings`
		///   is `[0, 2]`, then the output is `[1, 2, 3, 2, 1]` in reflect mode, and
		///   it is `[1, 2, 3, 3, 2]` in symmetric mode.
		/// </param>
		/// <returns>
		///   The padded tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation pads a `input` with mirrored values according to the `paddings`
		///   you specify. `paddings` is an integer tensor with shape `[n, 2]`, where n is
		///   the rank of `input`. For each dimension D of `input`, `paddings[D, 0]` indicates
		///   how many values to add before the contents of `input` in that dimension, and
		///   `paddings[D, 1]` indicates how many values to add after the contents of `input`
		///   in that dimension. Both `paddings[D, 0]` and `paddings[D, 1]` must be no greater
		///   than `input.dim_size(D)` (or `input.dim_size(D) - 1`) if `copy_border` is true
		///   (if false, respectively).
		///   
		///   The padded size of each dimension D of the output is:
		///   
		///   `paddings(D, 0) + input.dim_size(D) + paddings(D, 1)`
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[1, 2, 3], [4, 5, 6]].
		///   # 'paddings' is [[1, 1]], [2, 2]].
		///   # 'mode' is SYMMETRIC.
		///   # rank of 't' is 2.
		///   pad(t, paddings) ==&amp;gt; [[2, 1, 1, 2, 3, 3, 2]
		///                         [2, 1, 1, 2, 3, 3, 2]
		///                         [5, 4, 4, 5, 6, 6, 5]
		///                         [5, 4, 4, 5, 6, 6, 5]]
		///   ```
		/// </remarks>
		public TFOutput MirrorPad (TFOutput input, TFOutput paddings, string mode, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MirrorPad", MakeName ("MirrorPad", operName));
			desc.AddInput (input);
			desc.AddInput (paddings);
			desc.SetAttr ("mode", mode);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Gradient op for `MirrorPad` op. This op folds a mirror-padded tensor.
		/// </summary>
		/// <param name="input">
		///   The input tensor to be folded.
		/// </param>
		/// <param name="paddings">
		///   A two-column matrix specifying the padding sizes. The number of
		///   rows must be the same as the rank of `input`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MirrorPadGrad'.
		/// </param>
		/// <param name="mode">
		///   The mode used in the `MirrorPad` op.
		/// </param>
		/// <returns>
		///   The folded tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation folds the padded areas of `input` by `MirrorPad` according to the
		///   `paddings` you specify. `paddings` must be the same as `paddings` argument
		///   given to the corresponding `MirrorPad` op.
		///   
		///   The folded size of each dimension D of the output is:
		///   
		///   `input.dim_size(D) - paddings(D, 0) - paddings(D, 1)`
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[1, 2, 3], [4, 5, 6], [7, 8, 9]].
		///   # 'paddings' is [[0, 1]], [0, 1]].
		///   # 'mode' is SYMMETRIC.
		///   # rank of 't' is 2.
		///   pad(t, paddings) ==&amp;gt; [[ 1,  5]
		///                         [11, 28]]
		///   ```
		/// </remarks>
		public TFOutput MirrorPadGrad (TFOutput input, TFOutput paddings, string mode, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MirrorPadGrad", MakeName ("MirrorPadGrad", operName));
			desc.AddInput (input);
			desc.AddInput (paddings);
			desc.SetAttr ("mode", mode);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns element-wise remainder of division. This emulates C semantics in that
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Mod'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   the result here is consistent with a truncating divide. E.g. `truncate(x / y) *
		///   y + truncate_mod(x, y) = x`.
		///   
		///   *NOTE*: `Mod` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Mod (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Mod", MakeName ("Mod", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns x * y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Mul'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Mul` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Mul (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Mul", MakeName ("Mul", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Draws samples from a multinomial distribution.
		/// </summary>
		/// <param name="logits">
		///   2-D Tensor with shape `[batch_size, num_classes]`.  Each slice `[i, :]`
		///   represents the unnormalized log probabilities for all classes.
		/// </param>
		/// <param name="num_samples">
		///   0-D.  Number of independent samples to draw for each row slice.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Multinomial'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 is set to be non-zero, the internal random number
		///   generator is seeded by the given seed.  Otherwise, a random seed is used.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   2-D Tensor with shape `[batch_size, num_samples]`.  Each slice `[i, :]`
		///   contains the drawn class labels with range `[0, num_classes)`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Multinomial (TFOutput logits, TFOutput num_samples, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Multinomial", MakeName ("Multinomial", operName));
			desc.AddInput (logits);
			desc.AddInput (num_samples);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates an empty hash table that uses tensors as the backing store.
		/// </summary>
		/// <param name="empty_key">
		///   The key used to represent empty key buckets internally. Must not
		///   be used in insert or lookup operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MutableDenseHashTableV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this table is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this table is shared under the given name across
		///   multiple sessions.
		/// </param>
		/// <param name="use_node_name_sharing">
		///   Optional argument
		/// </param>
		/// <param name="value_shape">
		///   Optional argument
		///   The shape of each value.
		/// </param>
		/// <param name="initial_num_buckets">
		///   Optional argument
		///   The initial number of hash table buckets. Must be a power
		///   to 2.
		/// </param>
		/// <param name="max_load_factor">
		///   Optional argument
		///   The maximum ratio between number of entries and number of
		///   buckets before growing the table. Must be between 0 and 1.
		/// </param>
		/// <param name="value_dtype">
		///   Type of the table values.
		/// </param>
		/// <returns>
		///   Handle to a table.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   It uses "open addressing" with quadratic reprobing to resolve
		///   collisions.
		///   
		///   This op creates a mutable hash table, specifying the type of its keys and
		///   values. Each value must be a scalar. Data can be inserted into the table using
		///   the insert operations. It does not support the initialization operation.
		/// </remarks>
		public TFOutput MutableDenseHashTableV2 (TFOutput empty_key, TFDataType value_dtype, string container = null, string shared_name = null, bool? use_node_name_sharing = null, TFShape value_shape = null, long? initial_num_buckets = null, float? max_load_factor = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MutableDenseHashTableV2", MakeName ("MutableDenseHashTableV2", operName));
			desc.AddInput (empty_key);
			desc.SetAttrType ("value_dtype", value_dtype);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			if (use_node_name_sharing.HasValue)
				desc.SetAttr ("use_node_name_sharing", use_node_name_sharing.Value);
			
			if (value_shape != null)
				desc.SetAttrShape ("value_shape", value_shape);
			
			if (initial_num_buckets.HasValue)
				desc.SetAttr ("initial_num_buckets", initial_num_buckets.Value);
			
			if (max_load_factor.HasValue)
				desc.SetAttr ("max_load_factor", max_load_factor.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var table_handle = new TFOutput (op, _idx++);
			return table_handle;
		}

		/// <summary>
		///   Creates an empty hash table.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MutableHashTableOfTensorsV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this table is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this table is shared under the given name across
		///   multiple sessions.
		/// </param>
		/// <param name="use_node_name_sharing">
		///   Optional argument
		/// </param>
		/// <param name="value_shape">
		///   Optional argument
		/// </param>
		/// <param name="key_dtype">
		///   Type of the table keys.
		/// </param>
		/// <param name="value_dtype">
		///   Type of the table values.
		/// </param>
		/// <returns>
		///   Handle to a table.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op creates a mutable hash table, specifying the type of its keys and
		///   values. Each value must be a vector. Data can be inserted into the table using
		///   the insert operations. It does not support the initialization operation.
		/// </remarks>
		public TFOutput MutableHashTableOfTensorsV2 (TFDataType key_dtype, TFDataType value_dtype, string container = null, string shared_name = null, bool? use_node_name_sharing = null, TFShape value_shape = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MutableHashTableOfTensorsV2", MakeName ("MutableHashTableOfTensorsV2", operName));
			desc.SetAttrType ("key_dtype", key_dtype);
			desc.SetAttrType ("value_dtype", value_dtype);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			if (use_node_name_sharing.HasValue)
				desc.SetAttr ("use_node_name_sharing", use_node_name_sharing.Value);
			
			if (value_shape != null)
				desc.SetAttrShape ("value_shape", value_shape);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var table_handle = new TFOutput (op, _idx++);
			return table_handle;
		}

		/// <summary>
		///   Creates an empty hash table.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'MutableHashTableV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this table is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this table is shared under the given name across
		///   multiple sessions.
		/// </param>
		/// <param name="use_node_name_sharing">
		///   Optional argument
		///   If true and shared_name is empty, the table is shared
		///   using the node name.
		/// </param>
		/// <param name="key_dtype">
		///   Type of the table keys.
		/// </param>
		/// <param name="value_dtype">
		///   Type of the table values.
		/// </param>
		/// <returns>
		///   Handle to a table.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op creates a mutable hash table, specifying the type of its keys and
		///   values. Each value must be a scalar. Data can be inserted into the table using
		///   the insert operations. It does not support the initialization operation.
		/// </remarks>
		public TFOutput MutableHashTableV2 (TFDataType key_dtype, TFDataType value_dtype, string container = null, string shared_name = null, bool? use_node_name_sharing = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "MutableHashTableV2", MakeName ("MutableHashTableV2", operName));
			desc.SetAttrType ("key_dtype", key_dtype);
			desc.SetAttrType ("value_dtype", value_dtype);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			if (use_node_name_sharing.HasValue)
				desc.SetAttr ("use_node_name_sharing", use_node_name_sharing.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var table_handle = new TFOutput (op, _idx++);
			return table_handle;
		}

		/// <summary>
		///   Computes numerical negative value element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Neg'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = -x\\).
		/// </remarks>
		public TFOutput Neg (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Neg", MakeName ("Neg", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Makes its input available to the next iteration.
		/// </summary>
		/// <param name="data">
		///   The tensor to be made available to the next iteration.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'NextIteration'.
		/// </param>
		/// <returns>
		///   The same tensor as `data`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput NextIteration (TFOutput data, string operName = null)
		{
			var desc = new TFOperationDesc (this, "NextIteration", MakeName ("NextIteration", operName));
			desc.AddInput (data);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Greedily selects a subset of bounding boxes in descending order of score,
		/// </summary>
		/// <param name="boxes">
		///   A 2-D float tensor of shape `[num_boxes, 4]`.
		/// </param>
		/// <param name="scores">
		///   A 1-D float tensor of shape `[num_boxes]` representing a single
		///   score corresponding to each box (each row of boxes).
		/// </param>
		/// <param name="max_output_size">
		///   A scalar integer tensor representing the maximum number of
		///   boxes to be selected by non max suppression.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'NonMaxSuppression'.
		/// </param>
		/// <param name="iou_threshold">
		///   Optional argument
		///   A float representing the threshold for deciding whether boxes
		///   overlap too much with respect to IOU.
		/// </param>
		/// <returns>
		///   A 1-D integer tensor of shape `[M]` representing the selected
		///   indices from the boxes tensor, where `M &amp;lt;= max_output_size`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   pruning away boxes that have high intersection-over-union (IOU) overlap
		///   with previously selected boxes.  Bounding boxes are supplied as
		///   [y1, x1, y2, x2], where (y1, x1) and (y2, x2) are the coordinates of any
		///   diagonal pair of box corners and the coordinates can be provided as normalized
		///   (i.e., lying in the interval [0, 1]) or absolute.  Note that this algorithm
		///   is agnostic to where the origin is in the coordinate system.  Note that this
		///   algorithm is invariant to orthogonal transformations and translations
		///   of the coordinate system; thus translating or reflections of the coordinate
		///   system result in the same boxes being selected by the algorithm.
		///   The output of this operation is a set of integers indexing into the input
		///   collection of bounding boxes representing the selected boxes.  The bounding
		///   box coordinates corresponding to the selected indices can then be obtained
		///   using the `tf.gather operation`.  For example:
		///     selected_indices = tf.image.non_max_suppression(
		///         boxes, scores, max_output_size, iou_threshold)
		///     selected_boxes = tf.gather(boxes, selected_indices)
		/// </remarks>
		public TFOutput NonMaxSuppression (TFOutput boxes, TFOutput scores, TFOutput max_output_size, float? iou_threshold = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "NonMaxSuppression", MakeName ("NonMaxSuppression", operName));
			desc.AddInput (boxes);
			desc.AddInput (scores);
			desc.AddInput (max_output_size);
			if (iou_threshold.HasValue)
				desc.SetAttr ("iou_threshold", iou_threshold.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var selected_indices = new TFOutput (op, _idx++);
			return selected_indices;
		}

		/// <summary>
		///   Greedily selects a subset of bounding boxes in descending order of score,
		/// </summary>
		/// <param name="boxes">
		///   A 2-D float tensor of shape `[num_boxes, 4]`.
		/// </param>
		/// <param name="scores">
		///   A 1-D float tensor of shape `[num_boxes]` representing a single
		///   score corresponding to each box (each row of boxes).
		/// </param>
		/// <param name="max_output_size">
		///   A scalar integer tensor representing the maximum number of
		///   boxes to be selected by non max suppression.
		/// </param>
		/// <param name="iou_threshold">
		///   A 0-D float tensor representing the threshold for deciding whether
		///   boxes overlap too much with respect to IOU.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'NonMaxSuppressionV2'.
		/// </param>
		/// <returns>
		///   A 1-D integer tensor of shape `[M]` representing the selected
		///   indices from the boxes tensor, where `M &amp;lt;= max_output_size`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   pruning away boxes that have high intersection-over-union (IOU) overlap
		///   with previously selected boxes.  Bounding boxes are supplied as
		///   [y1, x1, y2, x2], where (y1, x1) and (y2, x2) are the coordinates of any
		///   diagonal pair of box corners and the coordinates can be provided as normalized
		///   (i.e., lying in the interval [0, 1]) or absolute.  Note that this algorithm
		///   is agnostic to where the origin is in the coordinate system.  Note that this
		///   algorithm is invariant to orthogonal transformations and translations
		///   of the coordinate system; thus translating or reflections of the coordinate
		///   system result in the same boxes being selected by the algorithm.
		///   
		///   The output of this operation is a set of integers indexing into the input
		///   collection of bounding boxes representing the selected boxes.  The bounding
		///   box coordinates corresponding to the selected indices can then be obtained
		///   using the `tf.gather operation`.  For example:
		///   
		///     selected_indices = tf.image.non_max_suppression_v2(
		///         boxes, scores, max_output_size, iou_threshold)
		///     selected_boxes = tf.gather(boxes, selected_indices)
		/// </remarks>
		public TFOutput NonMaxSuppressionV2 (TFOutput boxes, TFOutput scores, TFOutput max_output_size, TFOutput iou_threshold, string operName = null)
		{
			var desc = new TFOperationDesc (this, "NonMaxSuppressionV2", MakeName ("NonMaxSuppressionV2", operName));
			desc.AddInput (boxes);
			desc.AddInput (scores);
			desc.AddInput (max_output_size);
			desc.AddInput (iou_threshold);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var selected_indices = new TFOutput (op, _idx++);
			return selected_indices;
		}

		/// <summary>
		///   Does nothing. Only useful as a placeholder for control edges.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'NoOp'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation NoOp (string operName = null)
		{
			var desc = new TFOperationDesc (this, "NoOp", MakeName ("NoOp", operName));
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Returns the truth value of (x != y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'NotEqual'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `NotEqual` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput NotEqual (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "NotEqual", MakeName ("NotEqual", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns a one-hot tensor.
		/// </summary>
		/// <param name="indices">
		///   A tensor of indices.
		/// </param>
		/// <param name="depth">
		///   A scalar defining the depth of the one hot dimension.
		/// </param>
		/// <param name="on_value">
		///   A scalar defining the value to fill in output when `indices[j] = i`.
		/// </param>
		/// <param name="off_value">
		///   A scalar defining the value to fill in output when `indices[j] != i`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'OneHot'.
		/// </param>
		/// <param name="axis">
		///   Optional argument
		///   The axis to fill (default: -1, a new inner-most axis).
		/// </param>
		/// <returns>
		///   The one-hot tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The locations represented by indices in `indices` take value `on_value`,
		///   while all other locations take value `off_value`.
		///   
		///   If the input `indices` is rank `N`, the output will have rank `N+1`,
		///   The new axis is created at dimension `axis` (default: the new axis is
		///   appended at the end).
		///   
		///   If `indices` is a scalar the output shape will be a vector of length `depth`.
		///   
		///   If `indices` is a vector of length `features`, the output shape will be:
		///   ```
		///     features x depth if axis == -1
		///     depth x features if axis == 0
		///   ```
		///   
		///   If `indices` is a matrix (batch) with shape `[batch, features]`,
		///   the output shape will be:
		///   ```
		///     batch x features x depth if axis == -1
		///     batch x depth x features if axis == 1
		///     depth x batch x features if axis == 0
		///   ```
		///   
		///   
		///   Examples
		///   =========
		///   
		///   Suppose that
		///   
		///   ```
		///     indices = [0, 2, -1, 1]
		///     depth = 3
		///     on_value = 5.0
		///     off_value = 0.0
		///     axis = -1
		///   ```
		///   
		///   Then output is `[4 x 3]`:
		///   
		///       ```output =
		///         [5.0 0.0 0.0]  // one_hot(0)
		///         [0.0 0.0 5.0]  // one_hot(2)
		///         [0.0 0.0 0.0]  // one_hot(-1)
		///         [0.0 5.0 0.0]  // one_hot(1)
		///       ```
		///   
		///   Suppose that
		///   
		///   ```
		///     indices = [0, 2, -1, 1]
		///     depth = 3
		///     on_value = 0.0
		///     off_value = 3.0
		///     axis = 0
		///   ```
		///   
		///   Then output is `[3 x 4]`:
		///   
		///       ```output =
		///         [0.0 3.0 3.0 3.0]
		///         [3.0 3.0 3.0 0.0]
		///         [3.0 3.0 3.0 3.0]
		///         [3.0 0.0 3.0 3.0]
		///       //  ^                one_hot(0)
		///       //      ^            one_hot(2)
		///       //          ^        one_hot(-1)
		///       //              ^    one_hot(1)
		///       ```
		///   Suppose that
		///   
		///   ```
		///     indices = [[0, 2], [1, -1]]
		///     depth = 3
		///     on_value = 1.0
		///     off_value = 0.0
		///     axis = -1
		///   ```
		///   
		///   Then output is `[2 x 2 x 3]`:
		///   
		///       ```output =
		///         [
		///           [1.0, 0.0, 0.0]  // one_hot(0)
		///           [0.0, 0.0, 1.0]  // one_hot(2)
		///         ][
		///           [0.0, 1.0, 0.0]  // one_hot(1)
		///           [0.0, 0.0, 0.0]  // one_hot(-1)
		///         ]```
		/// </remarks>
		public TFOutput OneHot (TFOutput indices, TFOutput depth, TFOutput on_value, TFOutput off_value, long? axis = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "OneHot", MakeName ("OneHot", operName));
			desc.AddInput (indices);
			desc.AddInput (depth);
			desc.AddInput (on_value);
			desc.AddInput (off_value);
			if (axis.HasValue)
				desc.SetAttr ("axis", axis.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns a tensor of ones with the same shape and type as x.
		/// </summary>
		/// <param name="x">
		///   a tensor of type T.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'OnesLike'.
		/// </param>
		/// <returns>
		///   a tensor of the same shape and type as x but filled with ones.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput OnesLike (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "OnesLike", MakeName ("OnesLike", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Packs a list of `N` rank-`R` tensors into one rank-`(R+1)` tensor.
		/// </summary>
		/// <param name="values">
		///   Must be of same shape and type.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Pack'.
		/// </param>
		/// <param name="axis">
		///   Optional argument
		///   Dimension along which to pack.  Negative values wrap around, so the
		///   valid range is `[-(R+1), R+1)`.
		/// </param>
		/// <returns>
		///   The packed tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Packs the `N` tensors in `values` into a tensor with rank one higher than each
		///   tensor in `values`, by packing them along the `axis` dimension.
		///   Given a list of tensors of shape `(A, B, C)`;
		///   
		///   if `axis == 0` then the `output` tensor will have the shape `(N, A, B, C)`.
		///   if `axis == 1` then the `output` tensor will have the shape `(A, N, B, C)`.
		///   Etc.
		///   
		///   For example:
		///   
		///   ```
		///   # 'x' is [1, 4]
		///   # 'y' is [2, 5]
		///   # 'z' is [3, 6]
		///   pack([x, y, z]) =&amp;gt; [[1, 4], [2, 5], [3, 6]]  # Pack along first dim.
		///   pack([x, y, z], axis=1) =&amp;gt; [[1, 2, 3], [4, 5, 6]]
		///   ```
		///   
		///   This is the opposite of `unpack`.
		/// </remarks>
		public TFOutput Pack (TFOutput[] values, long? axis = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Pack", MakeName ("Pack", operName));
			desc.AddInputs (values);
			if (axis.HasValue)
				desc.SetAttr ("axis", axis.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Pads a tensor with zeros.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="paddings">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Pad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation pads a `input` with zeros according to the `paddings` you
		///   specify. `paddings` is an integer tensor with shape `[Dn, 2]`, where n is the
		///   rank of `input`. For each dimension D of `input`, `paddings[D, 0]` indicates
		///   how many zeros to add before the contents of `input` in that dimension, and
		///   `paddings[D, 1]` indicates how many zeros to add after the contents of `input`
		///   in that dimension.
		///   
		///   The padded size of each dimension D of the output is:
		///   
		///   `paddings(D, 0) + input.dim_size(D) + paddings(D, 1)`
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[1, 1], [2, 2]]
		///   # 'paddings' is [[1, 1], [2, 2]]
		///   # rank of 't' is 2
		///   pad(t, paddings) ==&amp;gt; [[0, 0, 0, 0, 0, 0]
		///                         [0, 0, 1, 1, 0, 0]
		///                         [0, 0, 2, 2, 0, 0]
		///                         [0, 0, 0, 0, 0, 0]]
		///   ```
		/// </remarks>
		public TFOutput Pad (TFOutput input, TFOutput paddings, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Pad", MakeName ("Pad", operName));
			desc.AddInput (input);
			desc.AddInput (paddings);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a dataset that batches and pads `batch_size` elements from the input.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="batch_size">
		///   A scalar representing the number of elements to accumulate in a
		///   batch.
		/// </param>
		/// <param name="padded_shapes">
		///   A list of int64 tensors representing the desired padded shapes
		///   of the corresponding output components. These shapes may be partially
		///   specified, using `-1` to indicate that a particular dimension should be
		///   padded to the maximum size of all batch elements.
		/// </param>
		/// <param name="padding_values">
		///   A list of scalars containing the padding value to use for
		///   each of the outputs.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PaddedBatchDataset'.
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput PaddedBatchDataset (TFOutput input_dataset, TFOutput batch_size, TFOutput[] padded_shapes, TFOutput[] padding_values, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PaddedBatchDataset", MakeName ("PaddedBatchDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (batch_size);
			desc.AddInputs (padded_shapes);
			desc.AddInputs (padding_values);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   A queue that produces elements in first-in first-out order.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PaddingFIFOQueueV2'.
		/// </param>
		/// <param name="shapes">
		///   Optional argument
		///   The shape of each component in a value. The length of this attr must
		///   be either 0 or the same as the length of component_types.
		///   Shapes of fixed rank but variable size are allowed by setting
		///   any shape dimension to -1.  In this case, the inputs' shape may vary along
		///   the given dimension, and DequeueMany will pad the given dimension with
		///   zeros up to the maximum shape of all elements in the given batch.
		///   If the length of this attr is 0, different queue elements may have
		///   different ranks and shapes, but only one element may be dequeued at a time.
		/// </param>
		/// <param name="capacity">
		///   Optional argument
		///   The upper bound on the number of elements in this queue.
		///   Negative numbers mean no limit.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this queue is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this queue will be shared under the given name
		///   across multiple sessions.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a value.
		/// </param>
		/// <returns>
		///   The handle to the queue.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Variable-size shapes are allowed by setting the corresponding shape dimensions
		///   to 0 in the shape attr.  In this case DequeueMany will pad up to the maximum
		///   size of any given element in the minibatch.  See below for details.
		/// </remarks>
		public TFOutput PaddingFIFOQueueV2 (TFDataType[] component_types, TFShape[] shapes = null, long? capacity = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PaddingFIFOQueueV2", MakeName ("PaddingFIFOQueueV2", operName));
			desc.SetAttrType ("component_types", component_types);
			if (shapes != null)
				desc.SetAttrShape ("shapes", shapes);
			
			if (capacity.HasValue)
				desc.SetAttr ("capacity", capacity.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Concatenates a list of `N` tensors along the first dimension.
		/// </summary>
		/// <param name="values">
		///   Tensors to be concatenated. All must have size 1 in the first dimension
		///   and same shape.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ParallelConcat'.
		/// </param>
		/// <param name="shape">
		///   the final shape of the result; should be equal to the shapes of any input
		///   but with the number of input values in the first dimension.
		/// </param>
		/// <returns>
		///   The concatenated tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The input tensors are all required to have size 1 in the first dimension.
		///   
		///   For example:
		///   
		///   ```
		///   # 'x' is [[1, 4]]
		///   # 'y' is [[2, 5]]
		///   # 'z' is [[3, 6]]
		///   parallel_concat([x, y, z]) =&amp;gt; [[1, 4], [2, 5], [3, 6]]  # Pack along first dim.
		///   ```
		///   
		///   The difference between concat and parallel_concat is that concat requires all
		///   of the inputs be computed before the operation will begin but doesn't require
		///   that the input shapes be known during graph construction.  Parallel concat
		///   will copy pieces of the input into the output as they become available, in
		///   some situations this can provide a performance benefit.
		/// </remarks>
		public TFOutput ParallelConcat (TFOutput[] values, TFShape shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ParallelConcat", MakeName ("ParallelConcat", operName));
			desc.AddInputs (values);
			desc.SetAttrShape ("shape", shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs random values from a normal distribution. The parameters may each be a
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor. Batches are indexed by the 0th dimension.
		/// </param>
		/// <param name="means">
		///   The mean parameter of each batch.
		/// </param>
		/// <param name="stdevs">
		///   The standard deviation parameter of each batch. Must be greater than 0.
		/// </param>
		/// <param name="minvals">
		///   The minimum cutoff. May be -infinity.
		/// </param>
		/// <param name="maxvals">
		///   The maximum cutoff. May be +infinity, and must be more than the minval
		///   for each batch.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ParameterizedTruncatedNormal'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   A matrix of shape num_batches x samples_per_batch, filled with random
		///   truncated normal values using the parameters for each row.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   scalar which applies to the entire output, or a vector of length shape[0] which
		///   stores the parameters for each batch.
		/// </remarks>
		public TFOutput ParameterizedTruncatedNormal (TFOutput shape, TFOutput means, TFOutput stdevs, TFOutput minvals, TFOutput maxvals, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ParameterizedTruncatedNormal", MakeName ("ParameterizedTruncatedNormal", operName));
			desc.AddInput (shape);
			desc.AddInput (means);
			desc.AddInput (stdevs);
			desc.AddInput (minvals);
			desc.AddInput (maxvals);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Transforms a vector of brain.Example protos (as strings) into typed tensors.
		/// </summary>
		/// <param name="serialized">
		///   A vector containing a batch of binary serialized Example protos.
		/// </param>
		/// <param name="names">
		///   A vector containing the names of the serialized protos.
		///   May contain, for example, table key (descriptive) names for the
		///   corresponding serialized protos.  These are purely useful for debugging
		///   purposes, and the presence of values here has no effect on the output.
		///   May also be an empty vector if no names are available.
		///   If non-empty, this vector must be the same length as "serialized".
		/// </param>
		/// <param name="sparse_keys">
		///   A list of Nsparse string Tensors (scalars).
		///   The keys expected in the Examples' features associated with sparse values.
		/// </param>
		/// <param name="dense_keys">
		///   A list of Ndense string Tensors (scalars).
		///   The keys expected in the Examples' features associated with dense values.
		/// </param>
		/// <param name="dense_defaults">
		///   A list of Ndense Tensors (some may be empty).
		///   dense_defaults[j] provides default values
		///   when the example's feature_map lacks dense_key[j].  If an empty Tensor is
		///   provided for dense_defaults[j], then the Feature dense_keys[j] is required.
		///   The input type is inferred from dense_defaults[j], even when it's empty.
		///   If dense_defaults[j] is not empty, and dense_shapes[j] is fully defined,
		///   then the shape of dense_defaults[j] must match that of dense_shapes[j].
		///   If dense_shapes[j] has an undefined major dimension (variable strides dense
		///   feature), dense_defaults[j] must contain a single element:
		///   the padding element.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ParseExample'.
		/// </param>
		/// <param name="sparse_types">
		///   A list of Nsparse types; the data types of data in each Feature
		///   given in sparse_keys.
		///   Currently the ParseExample supports DT_FLOAT (FloatList),
		///   DT_INT64 (Int64List), and DT_STRING (BytesList).
		/// </param>
		/// <param name="dense_shapes">
		///   A list of Ndense shapes; the shapes of data in each Feature
		///   given in dense_keys.
		///   The number of elements in the Feature corresponding to dense_key[j]
		///   must always equal dense_shapes[j].NumEntries().
		///   If dense_shapes[j] == (D0, D1, ..., DN) then the shape of output
		///   Tensor dense_values[j] will be (|serialized|, D0, D1, ..., DN):
		///   The dense outputs are just the inputs row-stacked by batch.
		///   This works for dense_shapes[j] = (-1, D1, ..., DN).  In this case
		///   the shape of the output Tensor dense_values[j] will be
		///   (|serialized|, M, D1, .., DN), where M is the maximum number of blocks
		///   of elements of length D1 * .... * DN, across all minibatch entries
		///   in the input.  Any minibatch entry with less than M blocks of elements of
		///   length D1 * ... * DN will be padded with the corresponding default_value
		///   scalar element along the second dimension.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sparse_indices: 
		///   sparse_values: 
		///   sparse_shapes: 
		///   dense_values: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput[] sparse_indices, TFOutput[] sparse_values, TFOutput[] sparse_shapes, TFOutput[] dense_values) ParseExample (TFOutput serialized, TFOutput names, TFOutput[] sparse_keys, TFOutput[] dense_keys, TFOutput[] dense_defaults, TFDataType[] sparse_types, TFShape[] dense_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ParseExample", MakeName ("ParseExample", operName));
			desc.AddInput (serialized);
			desc.AddInput (names);
			desc.AddInputs (sparse_keys);
			desc.AddInputs (dense_keys);
			desc.AddInputs (dense_defaults);
			desc.SetAttrType ("sparse_types", sparse_types);
			desc.SetAttrShape ("dense_shapes", dense_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("sparse_indices");
			var sparse_indices = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				sparse_indices [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("sparse_values");
			var sparse_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				sparse_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("sparse_shapes");
			var sparse_shapes = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				sparse_shapes [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("dense_values");
			var dense_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				dense_values [i] = new TFOutput (op, _idx++);
			
			return (sparse_indices, sparse_values, sparse_shapes, dense_values);
		}

		/// <summary>
		///   Transforms a scalar brain.SequenceExample proto (as strings) into typed tensors.
		/// </summary>
		/// <param name="serialized">
		///   A scalar containing a binary serialized SequenceExample proto.
		/// </param>
		/// <param name="feature_list_dense_missing_assumed_empty">
		///   A vector listing the
		///   FeatureList keys which may be missing from the SequenceExample.  If the
		///   associated FeatureList is missing, it is treated as empty.  By default,
		///   any FeatureList not listed in this vector must exist in the SequenceExample.
		/// </param>
		/// <param name="context_sparse_keys">
		///   A list of Ncontext_sparse string Tensors (scalars).
		///   The keys expected in the Examples' features associated with context_sparse
		///   values.
		/// </param>
		/// <param name="context_dense_keys">
		///   A list of Ncontext_dense string Tensors (scalars).
		///   The keys expected in the SequenceExamples' context features associated with
		///   dense values.
		/// </param>
		/// <param name="feature_list_sparse_keys">
		///   A list of Nfeature_list_sparse string Tensors
		///   (scalars).  The keys expected in the FeatureLists associated with sparse
		///   values.
		/// </param>
		/// <param name="feature_list_dense_keys">
		///   A list of Nfeature_list_dense string Tensors (scalars).
		///   The keys expected in the SequenceExamples' feature_lists associated
		///   with lists of dense values.
		/// </param>
		/// <param name="context_dense_defaults">
		///   A list of Ncontext_dense Tensors (some may be empty).
		///   context_dense_defaults[j] provides default values
		///   when the SequenceExample's context map lacks context_dense_key[j].
		///   If an empty Tensor is provided for context_dense_defaults[j],
		///   then the Feature context_dense_keys[j] is required.
		///   The input type is inferred from context_dense_defaults[j], even when it's
		///   empty.  If context_dense_defaults[j] is not empty, its shape must match
		///   context_dense_shapes[j].
		/// </param>
		/// <param name="debug_name">
		///   A scalar containing the name of the serialized proto.
		///   May contain, for example, table key (descriptive) name for the
		///   corresponding serialized proto.  This is purely useful for debugging
		///   purposes, and the presence of values here has no effect on the output.
		///   May also be an empty scalar if no name is available.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ParseSingleSequenceExample'.
		/// </param>
		/// <param name="context_sparse_types">
		///   Optional argument
		///   A list of Ncontext_sparse types; the data types of data in
		///   each context Feature given in context_sparse_keys.
		///   Currently the ParseSingleSequenceExample supports DT_FLOAT (FloatList),
		///   DT_INT64 (Int64List), and DT_STRING (BytesList).
		/// </param>
		/// <param name="feature_list_dense_types">
		///   Optional argument
		/// </param>
		/// <param name="context_dense_shapes">
		///   Optional argument
		///   A list of Ncontext_dense shapes; the shapes of data in
		///   each context Feature given in context_dense_keys.
		///   The number of elements in the Feature corresponding to context_dense_key[j]
		///   must always equal context_dense_shapes[j].NumEntries().
		///   The shape of context_dense_values[j] will match context_dense_shapes[j].
		/// </param>
		/// <param name="feature_list_sparse_types">
		///   Optional argument
		///   A list of Nfeature_list_sparse types; the data types
		///   of data in each FeatureList given in feature_list_sparse_keys.
		///   Currently the ParseSingleSequenceExample supports DT_FLOAT (FloatList),
		///   DT_INT64 (Int64List), and DT_STRING (BytesList).
		/// </param>
		/// <param name="feature_list_dense_shapes">
		///   Optional argument
		///   A list of Nfeature_list_dense shapes; the shapes of
		///   data in each FeatureList given in feature_list_dense_keys.
		///   The shape of each Feature in the FeatureList corresponding to
		///   feature_list_dense_key[j] must always equal
		///   feature_list_dense_shapes[j].NumEntries().
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   context_sparse_indices: 
		///   context_sparse_values: 
		///   context_sparse_shapes: 
		///   context_dense_values: 
		///   feature_list_sparse_indices: 
		///   feature_list_sparse_values: 
		///   feature_list_sparse_shapes: 
		///   feature_list_dense_values: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput[] context_sparse_indices, TFOutput[] context_sparse_values, TFOutput[] context_sparse_shapes, TFOutput[] context_dense_values, TFOutput[] feature_list_sparse_indices, TFOutput[] feature_list_sparse_values, TFOutput[] feature_list_sparse_shapes, TFOutput[] feature_list_dense_values) ParseSingleSequenceExample (TFOutput serialized, TFOutput feature_list_dense_missing_assumed_empty, TFOutput[] context_sparse_keys, TFOutput[] context_dense_keys, TFOutput[] feature_list_sparse_keys, TFOutput[] feature_list_dense_keys, TFOutput[] context_dense_defaults, TFOutput debug_name, TFDataType[] context_sparse_types = null, TFDataType[] feature_list_dense_types = null, TFShape[] context_dense_shapes = null, TFDataType[] feature_list_sparse_types = null, TFShape[] feature_list_dense_shapes = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ParseSingleSequenceExample", MakeName ("ParseSingleSequenceExample", operName));
			desc.AddInput (serialized);
			desc.AddInput (feature_list_dense_missing_assumed_empty);
			desc.AddInputs (context_sparse_keys);
			desc.AddInputs (context_dense_keys);
			desc.AddInputs (feature_list_sparse_keys);
			desc.AddInputs (feature_list_dense_keys);
			desc.AddInputs (context_dense_defaults);
			desc.AddInput (debug_name);
			if (context_sparse_types != null)
				desc.SetAttrType ("context_sparse_types", context_sparse_types);
			
			if (feature_list_dense_types != null)
				desc.SetAttrType ("feature_list_dense_types", feature_list_dense_types);
			
			if (context_dense_shapes != null)
				desc.SetAttrShape ("context_dense_shapes", context_dense_shapes);
			
			if (feature_list_sparse_types != null)
				desc.SetAttrType ("feature_list_sparse_types", feature_list_sparse_types);
			
			if (feature_list_dense_shapes != null)
				desc.SetAttrShape ("feature_list_dense_shapes", feature_list_dense_shapes);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("context_sparse_indices");
			var context_sparse_indices = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				context_sparse_indices [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("context_sparse_values");
			var context_sparse_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				context_sparse_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("context_sparse_shapes");
			var context_sparse_shapes = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				context_sparse_shapes [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("context_dense_values");
			var context_dense_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				context_dense_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("feature_list_sparse_indices");
			var feature_list_sparse_indices = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				feature_list_sparse_indices [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("feature_list_sparse_values");
			var feature_list_sparse_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				feature_list_sparse_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("feature_list_sparse_shapes");
			var feature_list_sparse_shapes = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				feature_list_sparse_shapes [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("feature_list_dense_values");
			var feature_list_dense_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				feature_list_dense_values [i] = new TFOutput (op, _idx++);
			
			return (context_sparse_indices, context_sparse_values, context_sparse_shapes, context_dense_values, feature_list_sparse_indices, feature_list_sparse_values, feature_list_sparse_shapes, feature_list_dense_values);
		}

		/// <summary>
		///   Transforms a serialized tensorflow.TensorProto proto into a Tensor.
		/// </summary>
		/// <param name="serialized">
		///   A scalar string containing a serialized TensorProto proto.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ParseTensor'.
		/// </param>
		/// <param name="out_type">
		///   The type of the serialized tensor.  The provided type must match the
		///   type of the serialized tensor and no implicit conversion will take place.
		/// </param>
		/// <returns>
		///   A Tensor of type `out_type`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ParseTensor (TFOutput serialized, TFDataType out_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ParseTensor", MakeName ("ParseTensor", operName));
			desc.AddInput (serialized);
			desc.SetAttrType ("out_type", out_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A placeholder op for a value that will be fed into the computation.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Placeholder'.
		/// </param>
		/// <param name="shape">
		///   Optional argument
		///   (Optional) The shape of the tensor. If the shape has 0 dimensions, the
		///   shape is unconstrained.
		/// </param>
		/// <param name="dtype">
		///   The type of elements in the tensor.
		/// </param>
		/// <returns>
		///   A placeholder tensor that must be replaced using the feed mechanism.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   N.B. This operation will fail with an error if it is executed. It is
		///   intended as a way to represent a value that will always be fed, and to
		///   provide attrs that enable the fed value to be checked at runtime.
		/// </remarks>
		public TFOutput Placeholder (TFDataType dtype, TFShape shape = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Placeholder", MakeName ("Placeholder", operName));
			desc.SetAttrType ("dtype", dtype);
			if (shape != null)
				desc.SetAttrShape ("shape", shape);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A placeholder op for a value that will be fed into the computation.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PlaceholderV2'.
		/// </param>
		/// <param name="dtype">
		///   The type of elements in the tensor.
		/// </param>
		/// <param name="shape">
		///   The shape of the tensor. The shape can be any partially-specified
		///   shape.  To be unconstrained, pass in a shape with unknown rank.
		/// </param>
		/// <returns>
		///   A placeholder tensor that must be replaced using the feed mechanism.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   N.B. This operation will fail with an error if it is executed. It is
		///   intended as a way to represent a value that will always be fed, and to
		///   provide attrs that enable the fed value to be checked at runtime.
		/// </remarks>
		public TFOutput PlaceholderV2 (TFDataType dtype, TFShape shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PlaceholderV2", MakeName ("PlaceholderV2", operName));
			desc.SetAttrType ("dtype", dtype);
			desc.SetAttrShape ("shape", shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A placeholder op that passes through `input` when its output is not fed.
		/// </summary>
		/// <param name="input">
		///   The default value to produce when `output` is not fed.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PlaceholderWithDefault'.
		/// </param>
		/// <param name="shape">
		///   The (possibly partial) shape of the tensor.
		/// </param>
		/// <returns>
		///   A placeholder tensor that defaults to `input` if it is not fed.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput PlaceholderWithDefault (TFOutput input, TFShape shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PlaceholderWithDefault", MakeName ("PlaceholderWithDefault", operName));
			desc.AddInput (input);
			desc.SetAttrShape ("shape", shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Compute the polygamma function \\(\psi^{(n)}(x)\\).
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Polygamma'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The polygamma function is defined as:
		///   
		///   
		///   \\(\psi^{(n)}(x) = \frac{d^n}{dx^n} \psi(x)\\)
		///   
		///   where \\(\psi(x)\\) is the digamma function.
		/// </remarks>
		public TFOutput Polygamma (TFOutput a, TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Polygamma", MakeName ("Polygamma", operName));
			desc.AddInput (a);
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes the power of one value to another.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Pow'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `x` and a tensor `y`, this operation computes \\(x^y\\) for
		///   corresponding elements in `x` and `y`. For example:
		///   
		///   ```
		///   # tensor 'x' is [[2, 2]], [3, 3]]
		///   # tensor 'y' is [[8, 16], [2, 3]]
		///   tf.pow(x, y) ==&amp;gt; [[256, 65536], [9, 27]]
		///   ```
		/// </remarks>
		public TFOutput Pow (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Pow", MakeName ("Pow", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   An identity op that triggers an error if a gradient is requested.
		/// </summary>
		/// <param name="input">
		///   any tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PreventGradient'.
		/// </param>
		/// <param name="message">
		///   Optional argument
		///   Will be printed in the error when anyone tries to differentiate
		///   this operation.
		/// </param>
		/// <returns>
		///   the same input tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   When executed in a graph, this op outputs its input tensor as-is.
		///   
		///   When building ops to compute gradients, the TensorFlow gradient system
		///   will return an error when trying to lookup the gradient of this op,
		///   because no gradient must ever be registered for this function.  This
		///   op exists to prevent subtle bugs from silently returning unimplemented
		///   gradients in some corner cases.
		/// </remarks>
		public TFOutput PreventGradient (TFOutput input, string message = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PreventGradient", MakeName ("PreventGradient", operName));
			desc.AddInput (input);
			if (message != null)
				desc.SetAttr ("message", message);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Prints a list of tensors.
		/// </summary>
		/// <param name="input">
		///   The tensor passed to `output`
		/// </param>
		/// <param name="data">
		///   A list of tensors to print out when op is evaluated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Print'.
		/// </param>
		/// <param name="message">
		///   Optional argument
		///   A string, prefix of the error message.
		/// </param>
		/// <param name="first_n">
		///   Optional argument
		///   Only log `first_n` number of times. -1 disables logging.
		/// </param>
		/// <param name="summarize">
		///   Optional argument
		///   Only print this many entries of each tensor.
		/// </param>
		/// <returns>
		///   = The unmodified `input` tensor
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Passes `input` through to `output` and prints `data` when evaluating.
		/// </remarks>
		public TFOutput Print (TFOutput input, TFOutput[] data, string message = null, long? first_n = null, long? summarize = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Print", MakeName ("Print", operName));
			desc.AddInput (input);
			desc.AddInputs (data);
			if (message != null)
				desc.SetAttr ("message", message);
			
			if (first_n.HasValue)
				desc.SetAttr ("first_n", first_n.Value);
			
			if (summarize.HasValue)
				desc.SetAttr ("summarize", summarize.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A queue that produces elements sorted by the first component value.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'PriorityQueueV2'.
		/// </param>
		/// <param name="component_types">
		///   Optional argument
		///   The type of each component in a value.
		/// </param>
		/// <param name="capacity">
		///   Optional argument
		///   The upper bound on the number of elements in this queue.
		///   Negative numbers mean no limit.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this queue is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this queue will be shared under the given name
		///   across multiple sessions.
		/// </param>
		/// <param name="shapes">
		///   The shape of each component in a value. The length of this attr must
		///   be either 0 or the same as the length of component_types. If the length of
		///   this attr is 0, the shapes of queue elements are not constrained, and
		///   only one element may be dequeued at a time.
		/// </param>
		/// <returns>
		///   The handle to the queue.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Note that the PriorityQueue requires the first component of any element
		///   to be a scalar int64, in addition to the other elements declared by
		///   component_types.  Therefore calls to Enqueue and EnqueueMany (resp. Dequeue
		///   and DequeueMany) on a PriorityQueue will all require (resp. output) one extra
		///   entry in their input (resp. output) lists.
		/// </remarks>
		public TFOutput PriorityQueueV2 (TFShape[] shapes, TFDataType[] component_types = null, long? capacity = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "PriorityQueueV2", MakeName ("PriorityQueueV2", operName));
			desc.SetAttrShape ("shapes", shapes);
			if (component_types != null)
				desc.SetAttrType ("component_types", component_types);
			
			if (capacity.HasValue)
				desc.SetAttr ("capacity", capacity.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Computes the product of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Prod'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Prod (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Prod", MakeName ("Prod", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the QR decompositions of one or more matrices.
		/// </summary>
		/// <param name="input">
		///   A tensor of shape `[..., M, N]` whose inner-most 2 dimensions
		///   form matrices of size `[M, N]`. Let `P` be the minimum of `M` and `N`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Qr'.
		/// </param>
		/// <param name="full_matrices">
		///   Optional argument
		///   If true, compute full-sized `q` and `r`. If false
		///   (the default), compute only the leading `P` columns of `q`.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   q: Orthonormal basis for range of `a`. If `full_matrices` is `False` then
		///   shape is `[..., M, P]`; if `full_matrices` is `True` then shape is
		///   `[..., M, M]`.
		///   r: Triangular factor. If `full_matrices` is `False` then shape is
		///   `[..., P, N]`. If `full_matrices` is `True` then shape is `[..., M, N]`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Computes the QR decomposition of each inner matrix in `tensor` such that
		///   `tensor[..., :, :] = q[..., :, :] * r[..., :,:])`
		///   
		///   ```prettyprint
		///   # a is a tensor.
		///   # q is a tensor of orthonormal matrices.
		///   # r is a tensor of upper triangular matrices.
		///   q, r = qr(a)
		///   q_full, r_full = qr(a, full_matrices=True)
		///   ```
		/// </remarks>
		public (TFOutput q, TFOutput r) Qr (TFOutput input, bool? full_matrices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Qr", MakeName ("Qr", operName));
			desc.AddInput (input);
			if (full_matrices.HasValue)
				desc.SetAttr ("full_matrices", full_matrices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var q = new TFOutput (op, _idx++);
			var r = new TFOutput (op, _idx++);
			return (q, r);
		}

		/// <summary>
		///   Use QuantizeAndDequantizeV2 instead.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizeAndDequantize'.
		/// </param>
		/// <param name="signed_input">
		///   Optional argument
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		/// </param>
		/// <param name="range_given">
		///   Optional argument
		/// </param>
		/// <param name="input_min">
		///   Optional argument
		/// </param>
		/// <param name="input_max">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput QuantizeAndDequantize (TFOutput input, bool? signed_input = null, long? num_bits = null, bool? range_given = null, float? input_min = null, float? input_max = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizeAndDequantize", MakeName ("QuantizeAndDequantize", operName));
			desc.AddInput (input);
			if (signed_input.HasValue)
				desc.SetAttr ("signed_input", signed_input.Value);
			
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			if (range_given.HasValue)
				desc.SetAttr ("range_given", range_given.Value);
			
			if (input_min.HasValue)
				desc.SetAttr ("input_min", input_min.Value);
			
			if (input_max.HasValue)
				desc.SetAttr ("input_max", input_max.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Quantizes then dequantizes a tensor.
		/// </summary>
		/// <param name="input">
		///   Tensor to quantize and then dequantize.
		/// </param>
		/// <param name="input_min">
		///   If range_given, this is the min of the range, otherwise this input
		///   will be ignored.
		/// </param>
		/// <param name="input_max">
		///   If range_given, this is the max of the range, otherwise this input
		///   will be ignored.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizeAndDequantizeV2'.
		/// </param>
		/// <param name="signed_input">
		///   Optional argument
		///   If the quantization is signed or unsigned.
		/// </param>
		/// <param name="num_bits">
		///   Optional argument
		///   The bitwidth of the quantization.
		/// </param>
		/// <param name="range_given">
		///   Optional argument
		///   If the range is given or should be computed from the tensor.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op simulates the precision loss from the quantized forward pass by:
		///   1. Quantizing the tensor to fixed point numbers, which should match the target
		///      quantization method when it is used in inference.
		///   2. Dequantizing it back to floating point numbers for the following ops, most
		///      likely matmul.
		///   
		///   There are different ways to quantize. This version does not use the full range
		///   of the output type, choosing to elide the lowest possible value for symmetry
		///   (e.g., output range is -127 to 127, not -128 to 127 for signed 8 bit
		///   quantization), so that 0.0 maps to 0.
		///   
		///   To perform this op, we first find the range of values in our tensor. The range
		///   we use is always centered on 0, so we find m such that
		///   
		///   1. m = max(abs(input_min), abs(input_max)) if range_given is true,
		///   2. m = max(abs(min_elem(input)), abs(max_elem(input))) otherwise.
		///   
		///   Our input tensor range is then [-m, m].
		///   
		///   Next, we choose our fixed-point quantization buckets, [min_fixed, max_fixed].
		///   If signed_input is true, this is
		///   
		///     [min_fixed, max_fixed ] =
		///         [-(1 &amp;lt;&amp;lt; (num_bits - 1) - 1), (1 &amp;lt;&amp;lt; (num_bits - 1)) - 1].
		///   
		///   Otherwise, if signed_input is false, the fixed-point range is
		///   
		///     [min_fixed, max_fixed] = [0, (1 &amp;lt;&amp;lt; num_bits) - 1].
		///   
		///   From this we compute our scaling factor, s:
		///   
		///     s = (max_fixed - min_fixed) / (2 * m).
		///   
		///   Now we can quantize and dequantize the elements of our tensor.  An element e
		///   is transformed into e':
		///   
		///     e' = (e * s).round_to_nearest() / s.
		///   
		///   Note that we have a different number of buckets in the signed vs. unsigned
		///   cases.  For example, if num_bits == 8, we get 254 buckets in the signed case
		///   vs. 255 in the unsigned case.
		///   
		///   For example, suppose num_bits = 8 and m = 1.  Then
		///   
		///     [min_fixed, max_fixed] = [-127, 127], and
		///     s = (127 + 127) / 2 = 127.
		///   
		///   Given the vector {-1, -0.5, 0, 0.3}, this is quantized to
		///   {-127, -63, 0, 38}, and dequantized to {-1, -63.0/127, 0, 38.0/127}.
		/// </remarks>
		public TFOutput QuantizeAndDequantizeV2 (TFOutput input, TFOutput input_min, TFOutput input_max, bool? signed_input = null, long? num_bits = null, bool? range_given = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizeAndDequantizeV2", MakeName ("QuantizeAndDequantizeV2", operName));
			desc.AddInput (input);
			desc.AddInput (input_min);
			desc.AddInput (input_max);
			if (signed_input.HasValue)
				desc.SetAttr ("signed_input", signed_input.Value);
			
			if (num_bits.HasValue)
				desc.SetAttr ("num_bits", num_bits.Value);
			
			if (range_given.HasValue)
				desc.SetAttr ("range_given", range_given.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Produces the average pool of the input tensor for quantized types.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="min_input">
		///   The float value that the lowest quantized input value represents.
		/// </param>
		/// <param name="max_input">
		///   The float value that the highest quantized input value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedAvgPool'.
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		///   The length must be 4 to match the number of dimensions of the input.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   tensor.  The length must be 4 to match the number of dimensions of the input.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   min_output: The float value that the lowest quantized output value represents.
		///   max_output: The float value that the highest quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput output, TFOutput min_output, TFOutput max_output) QuantizedAvgPool (TFOutput input, TFOutput min_input, TFOutput max_input, long[] ksize, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedAvgPool", MakeName ("QuantizedAvgPool", operName));
			desc.AddInput (input);
			desc.AddInput (min_input);
			desc.AddInput (max_input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var min_output = new TFOutput (op, _idx++);
			var max_output = new TFOutput (op, _idx++);
			return (output, min_output, max_output);
		}

		/// <summary>
		///   Quantized Batch normalization.
		/// </summary>
		/// <param name="t">
		///   A 4D input Tensor.
		/// </param>
		/// <param name="t_min">
		///   The value represented by the lowest quantized input.
		/// </param>
		/// <param name="t_max">
		///   The value represented by the highest quantized input.
		/// </param>
		/// <param name="m">
		///   A 1D mean Tensor with size matching the last dimension of t.
		///   This is the first output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="m_min">
		///   The value represented by the lowest quantized mean.
		/// </param>
		/// <param name="m_max">
		///   The value represented by the highest quantized mean.
		/// </param>
		/// <param name="v">
		///   A 1D variance Tensor with size matching the last dimension of t.
		///   This is the second output from tf.nn.moments,
		///   or a saved moving average thereof.
		/// </param>
		/// <param name="v_min">
		///   The value represented by the lowest quantized variance.
		/// </param>
		/// <param name="v_max">
		///   The value represented by the highest quantized variance.
		/// </param>
		/// <param name="beta">
		///   A 1D beta Tensor with size matching the last dimension of t.
		///   An offset to be added to the normalized tensor.
		/// </param>
		/// <param name="beta_min">
		///   The value represented by the lowest quantized offset.
		/// </param>
		/// <param name="beta_max">
		///   The value represented by the highest quantized offset.
		/// </param>
		/// <param name="gamma">
		///   A 1D gamma Tensor with size matching the last dimension of t.
		///   If "scale_after_normalization" is true, this tensor will be multiplied
		///   with the normalized tensor.
		/// </param>
		/// <param name="gamma_min">
		///   The value represented by the lowest quantized gamma.
		/// </param>
		/// <param name="gamma_max">
		///   The value represented by the highest quantized gamma.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedBatchNormWithGlobalNormalization'.
		/// </param>
		/// <param name="out_type">
		/// </param>
		/// <param name="variance_epsilon">
		///   A small float number to avoid dividing by 0.
		/// </param>
		/// <param name="scale_after_normalization">
		///   A bool indicating whether the resulted tensor
		///   needs to be multiplied with gamma.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   result: 
		///   result_min: 
		///   result_max: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This op is deprecated and will be removed in the future. Prefer
		///   `tf.nn.batch_normalization`.
		/// </remarks>
		public (TFOutput result, TFOutput result_min, TFOutput result_max) QuantizedBatchNormWithGlobalNormalization (TFOutput t, TFOutput t_min, TFOutput t_max, TFOutput m, TFOutput m_min, TFOutput m_max, TFOutput v, TFOutput v_min, TFOutput v_max, TFOutput beta, TFOutput beta_min, TFOutput beta_max, TFOutput gamma, TFOutput gamma_min, TFOutput gamma_max, TFDataType out_type, float variance_epsilon, bool scale_after_normalization, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedBatchNormWithGlobalNormalization", MakeName ("QuantizedBatchNormWithGlobalNormalization", operName));
			desc.AddInput (t);
			desc.AddInput (t_min);
			desc.AddInput (t_max);
			desc.AddInput (m);
			desc.AddInput (m_min);
			desc.AddInput (m_max);
			desc.AddInput (v);
			desc.AddInput (v_min);
			desc.AddInput (v_max);
			desc.AddInput (beta);
			desc.AddInput (beta_min);
			desc.AddInput (beta_max);
			desc.AddInput (gamma);
			desc.AddInput (gamma_min);
			desc.AddInput (gamma_max);
			desc.SetAttrType ("out_type", out_type);
			desc.SetAttr ("variance_epsilon", variance_epsilon);
			desc.SetAttr ("scale_after_normalization", scale_after_normalization);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var result = new TFOutput (op, _idx++);
			var result_min = new TFOutput (op, _idx++);
			var result_max = new TFOutput (op, _idx++);
			return (result, result_min, result_max);
		}

		/// <summary>
		///   Adds Tensor 'bias' to Tensor 'input' for Quantized types.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="bias">
		///   A 1D bias Tensor with size matching the last dimension of 'input'.
		/// </param>
		/// <param name="min_input">
		///   The float value that the lowest quantized input value represents.
		/// </param>
		/// <param name="max_input">
		///   The float value that the highest quantized input value represents.
		/// </param>
		/// <param name="min_bias">
		///   The float value that the lowest quantized bias value represents.
		/// </param>
		/// <param name="max_bias">
		///   The float value that the highest quantized bias value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedBiasAdd'.
		/// </param>
		/// <param name="out_type">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   min_out: The float value that the lowest quantized output value represents.
		///   max_out: The float value that the highest quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Broadcasts the values of bias on dimensions 0..N-2 of 'input'.
		/// </remarks>
		public (TFOutput output, TFOutput min_out, TFOutput max_out) QuantizedBiasAdd (TFOutput input, TFOutput bias, TFOutput min_input, TFOutput max_input, TFOutput min_bias, TFOutput max_bias, TFDataType out_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedBiasAdd", MakeName ("QuantizedBiasAdd", operName));
			desc.AddInput (input);
			desc.AddInput (bias);
			desc.AddInput (min_input);
			desc.AddInput (max_input);
			desc.AddInput (min_bias);
			desc.AddInput (max_bias);
			desc.SetAttrType ("out_type", out_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var min_out = new TFOutput (op, _idx++);
			var max_out = new TFOutput (op, _idx++);
			return (output, min_out, max_out);
		}

		/// <summary>
		///   Concatenates quantized tensors along one dimension.
		/// </summary>
		/// <param name="concat_dim">
		///   0-D.  The dimension along which to concatenate.  Must be in the
		///   range [0, rank(values)).
		/// </param>
		/// <param name="values">
		///   The `N` Tensors to concatenate. Their ranks and types must match,
		///   and their sizes must match in all dimensions except `concat_dim`.
		/// </param>
		/// <param name="input_mins">
		///   The minimum scalar values for each of the input tensors.
		/// </param>
		/// <param name="input_maxes">
		///   The maximum scalar values for each of the input tensors.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedConcat'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: A `Tensor` with the concatenation of values stacked along the
		///   `concat_dim` dimension.  This tensor's shape matches that of `values` except
		///   in `concat_dim` where it has the sum of the sizes.
		///   output_min: The float value that the minimum quantized output value represents.
		///   output_max: The float value that the maximum quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput output, TFOutput output_min, TFOutput output_max) QuantizedConcat (TFOutput concat_dim, TFOutput[] values, TFOutput[] input_mins, TFOutput[] input_maxes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedConcat", MakeName ("QuantizedConcat", operName));
			desc.AddInput (concat_dim);
			desc.AddInputs (values);
			desc.AddInputs (input_mins);
			desc.AddInputs (input_maxes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output, output_min, output_max);
		}

		/// <summary>
		///   Computes a 2D convolution given quantized 4D input and filter tensors.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="filter">
		///   filter's input_depth dimension must match input's depth dimensions.
		/// </param>
		/// <param name="min_input">
		///   The float value that the lowest quantized input value represents.
		/// </param>
		/// <param name="max_input">
		///   The float value that the highest quantized input value represents.
		/// </param>
		/// <param name="min_filter">
		///   The float value that the lowest quantized filter value represents.
		/// </param>
		/// <param name="max_filter">
		///   The float value that the highest quantized filter value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedConv2D'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   tensor.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   min_output: The float value that the lowest quantized output value represents.
		///   max_output: The float value that the highest quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The inputs are quantized tensors where the lowest value represents the real
		///   number of the associated minimum, and the highest represents the maximum.
		///   This means that you can only interpret the quantized output in the same way, by
		///   taking the returned minimum and maximum values into account.
		/// </remarks>
		public (TFOutput output, TFOutput min_output, TFOutput max_output) QuantizedConv2D (TFOutput input, TFOutput filter, TFOutput min_input, TFOutput max_input, TFOutput min_filter, TFOutput max_filter, long[] strides, string padding, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedConv2D", MakeName ("QuantizedConv2D", operName));
			desc.AddInput (input);
			desc.AddInput (filter);
			desc.AddInput (min_input);
			desc.AddInput (max_input);
			desc.AddInput (min_filter);
			desc.AddInput (max_filter);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var min_output = new TFOutput (op, _idx++);
			var max_output = new TFOutput (op, _idx++);
			return (output, min_output, max_output);
		}

		/// <summary>
		///   Quantized Instance normalization.
		/// </summary>
		/// <param name="x">
		///   A 4D input Tensor.
		/// </param>
		/// <param name="x_min">
		///   The value represented by the lowest quantized input.
		/// </param>
		/// <param name="x_max">
		///   The value represented by the highest quantized input.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedInstanceNorm'.
		/// </param>
		/// <param name="output_range_given">
		///   Optional argument
		///   If True, `given_y_min` and `given_y_min`
		///   and `given_y_max` are used as the output range. Otherwise,
		///   the implementation computes the output range.
		/// </param>
		/// <param name="given_y_min">
		///   Optional argument
		///   Output in `y_min` if `output_range_given` is True.
		/// </param>
		/// <param name="given_y_max">
		///   Optional argument
		///   Output in `y_max` if `output_range_given` is True.
		/// </param>
		/// <param name="variance_epsilon">
		///   Optional argument
		///   A small float number to avoid dividing by 0.
		/// </param>
		/// <param name="min_separation">
		///   Optional argument
		///   Minimum value of `y_max - y_min`
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   y: A 4D Tensor.
		///   y_min: The value represented by the lowest quantized output.
		///   y_max: The value represented by the highest quantized output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput y, TFOutput y_min, TFOutput y_max) QuantizedInstanceNorm (TFOutput x, TFOutput x_min, TFOutput x_max, bool? output_range_given = null, float? given_y_min = null, float? given_y_max = null, float? variance_epsilon = null, float? min_separation = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedInstanceNorm", MakeName ("QuantizedInstanceNorm", operName));
			desc.AddInput (x);
			desc.AddInput (x_min);
			desc.AddInput (x_max);
			if (output_range_given.HasValue)
				desc.SetAttr ("output_range_given", output_range_given.Value);
			
			if (given_y_min.HasValue)
				desc.SetAttr ("given_y_min", given_y_min.Value);
			
			if (given_y_max.HasValue)
				desc.SetAttr ("given_y_max", given_y_max.Value);
			
			if (variance_epsilon.HasValue)
				desc.SetAttr ("variance_epsilon", variance_epsilon.Value);
			
			if (min_separation.HasValue)
				desc.SetAttr ("min_separation", min_separation.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			var y_min = new TFOutput (op, _idx++);
			var y_max = new TFOutput (op, _idx++);
			return (y, y_min, y_max);
		}

		/// <summary>
		///   Perform a quantized matrix multiplication of  `a` by the matrix `b`.
		/// </summary>
		/// <param name="a">
		///   Must be a two-dimensional tensor.
		/// </param>
		/// <param name="b">
		///   Must be a two-dimensional tensor.
		/// </param>
		/// <param name="min_a">
		///   The float value that the lowest quantized `a` value represents.
		/// </param>
		/// <param name="max_a">
		///   The float value that the highest quantized `a` value represents.
		/// </param>
		/// <param name="min_b">
		///   The float value that the lowest quantized `b` value represents.
		/// </param>
		/// <param name="max_b">
		///   The float value that the highest quantized `b` value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedMatMul'.
		/// </param>
		/// <param name="Toutput">
		///   Optional argument
		/// </param>
		/// <param name="transpose_a">
		///   Optional argument
		///   If true, `a` is transposed before multiplication.
		/// </param>
		/// <param name="transpose_b">
		///   Optional argument
		///   If true, `b` is transposed before multiplication.
		/// </param>
		/// <param name="Tactivation">
		///   Optional argument
		///   The type of output produced by activation function
		///   following this operation.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   min_out: The float value that the lowest quantized output value represents.
		///   max_out: The float value that the highest quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The inputs must be two-dimensional matrices and the inner dimension of
		///   `a` (after being transposed if `transpose_a` is non-zero) must match the
		///   outer dimension of `b` (after being transposed if `transposed_b` is
		///   non-zero).
		/// </remarks>
		public (TFOutput output, TFOutput min_out, TFOutput max_out) QuantizedMatMul (TFOutput a, TFOutput b, TFOutput min_a, TFOutput max_a, TFOutput min_b, TFOutput max_b, TFDataType? Toutput = null, bool? transpose_a = null, bool? transpose_b = null, TFDataType? Tactivation = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedMatMul", MakeName ("QuantizedMatMul", operName));
			desc.AddInput (a);
			desc.AddInput (b);
			desc.AddInput (min_a);
			desc.AddInput (max_a);
			desc.AddInput (min_b);
			desc.AddInput (max_b);
			if (Toutput.HasValue)
				desc.SetAttrType ("Toutput", Toutput.Value);
			
			if (transpose_a.HasValue)
				desc.SetAttr ("transpose_a", transpose_a.Value);
			
			if (transpose_b.HasValue)
				desc.SetAttr ("transpose_b", transpose_b.Value);
			
			if (Tactivation.HasValue)
				desc.SetAttrType ("Tactivation", Tactivation.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var min_out = new TFOutput (op, _idx++);
			var max_out = new TFOutput (op, _idx++);
			return (output, min_out, max_out);
		}

		/// <summary>
		///   Produces the max pool of the input tensor for quantized types.
		/// </summary>
		/// <param name="input">
		///   The 4D (batch x rows x cols x depth) Tensor to MaxReduce over.
		/// </param>
		/// <param name="min_input">
		///   The float value that the lowest quantized input value represents.
		/// </param>
		/// <param name="max_input">
		///   The float value that the highest quantized input value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedMaxPool'.
		/// </param>
		/// <param name="ksize">
		///   The size of the window for each dimension of the input tensor.
		///   The length must be 4 to match the number of dimensions of the input.
		/// </param>
		/// <param name="strides">
		///   The stride of the sliding window for each dimension of the input
		///   tensor. The length must be 4 to match the number of dimensions of the input.
		/// </param>
		/// <param name="padding">
		///   The type of padding algorithm to use.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   min_output: The float value that the lowest quantized output value represents.
		///   max_output: The float value that the highest quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput output, TFOutput min_output, TFOutput max_output) QuantizedMaxPool (TFOutput input, TFOutput min_input, TFOutput max_input, long[] ksize, long[] strides, string padding, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedMaxPool", MakeName ("QuantizedMaxPool", operName));
			desc.AddInput (input);
			desc.AddInput (min_input);
			desc.AddInput (max_input);
			desc.SetAttr ("ksize", ksize);
			desc.SetAttr ("strides", strides);
			desc.SetAttr ("padding", padding);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var min_output = new TFOutput (op, _idx++);
			var max_output = new TFOutput (op, _idx++);
			return (output, min_output, max_output);
		}

		/// <summary>
		///   Returns x * y element-wise, working on quantized buffers.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="min_x">
		///   The float value that the lowest quantized `x` value represents.
		/// </param>
		/// <param name="max_x">
		///   The float value that the highest quantized `x` value represents.
		/// </param>
		/// <param name="min_y">
		///   The float value that the lowest quantized `y` value represents.
		/// </param>
		/// <param name="max_y">
		///   The float value that the highest quantized `y` value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedMul'.
		/// </param>
		/// <param name="Toutput">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   z: 
		///   min_z: The float value that the lowest quantized output value represents.
		///   max_z: The float value that the highest quantized output value represents.
		///   
		///   *NOTE*: `QuantizedMul` supports limited forms of broadcasting. More about
		///   broadcasting [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput z, TFOutput min_z, TFOutput max_z) QuantizedMul (TFOutput x, TFOutput y, TFOutput min_x, TFOutput max_x, TFOutput min_y, TFOutput max_y, TFDataType? Toutput = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedMul", MakeName ("QuantizedMul", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			desc.AddInput (min_x);
			desc.AddInput (max_x);
			desc.AddInput (min_y);
			desc.AddInput (max_y);
			if (Toutput.HasValue)
				desc.SetAttrType ("Toutput", Toutput.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			var min_z = new TFOutput (op, _idx++);
			var max_z = new TFOutput (op, _idx++);
			return (z, min_z, max_z);
		}

		/// <summary>
		///   Convert the quantized 'input' tensor into a lower-precision 'output', using the
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="input_min">
		///   The float value that the minimum quantized input value represents.
		/// </param>
		/// <param name="input_max">
		///   The float value that the maximum quantized input value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizeDownAndShrinkRange'.
		/// </param>
		/// <param name="out_type">
		///   The type of the output. Should be a lower bit depth than Tinput.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   output_min: The float value that the minimum quantized output value represents.
		///   output_max: The float value that the maximum quantized output value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   actual distribution of the values to maximize the usage of the lower bit depth
		///   and adjusting the output min and max ranges accordingly.
		///   
		///   [input_min, input_max] are scalar floats that specify the range for the float
		///   interpretation of the 'input' data. For example, if input_min is -1.0f and
		///   input_max is 1.0f, and we are dealing with quint16 quantized data, then a 0
		///   value in the 16-bit data should be interpreted as -1.0f, and a 65535 means 1.0f.
		///   
		///   This operator tries to squeeze as much precision as possible into an output with
		///   a lower bit depth by calculating the actual min and max values found in the
		///   data. For example, maybe that quint16 input has no values lower than 16,384 and
		///   none higher than 49,152. That means only half the range is actually needed, all
		///   the float interpretations are between -0.5f and 0.5f, so if we want to compress
		///   the data into a quint8 output, we can use that range rather than the theoretical
		///   -1.0f to 1.0f that is suggested by the input min and max.
		///   
		///   In practice, this is most useful for taking output from operations like
		///   QuantizedMatMul that can produce higher bit-depth outputs than their inputs and
		///   may have large potential output ranges, but in practice have a distribution of
		///   input values that only uses a small fraction of the possible range. By feeding
		///   that output into this operator, we can reduce it from 32 bits down to 8 with
		///   minimal loss of accuracy.
		/// </remarks>
		public (TFOutput output, TFOutput output_min, TFOutput output_max) QuantizeDownAndShrinkRange (TFOutput input, TFOutput input_min, TFOutput input_max, TFDataType out_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizeDownAndShrinkRange", MakeName ("QuantizeDownAndShrinkRange", operName));
			desc.AddInput (input);
			desc.AddInput (input_min);
			desc.AddInput (input_max);
			desc.SetAttrType ("out_type", out_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output, output_min, output_max);
		}

		/// <summary>
		///   Computes Quantized Rectified Linear: `max(features, 0)`
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="min_features">
		///   The float value that the lowest quantized value represents.
		/// </param>
		/// <param name="max_features">
		///   The float value that the highest quantized value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedRelu'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   activations: Has the same output shape as "features".
		///   min_activations: The float value that the lowest quantized value represents.
		///   max_activations: The float value that the highest quantized value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput activations, TFOutput min_activations, TFOutput max_activations) QuantizedRelu (TFOutput features, TFOutput min_features, TFOutput max_features, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedRelu", MakeName ("QuantizedRelu", operName));
			desc.AddInput (features);
			desc.AddInput (min_features);
			desc.AddInput (max_features);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			var min_activations = new TFOutput (op, _idx++);
			var max_activations = new TFOutput (op, _idx++);
			return (activations, min_activations, max_activations);
		}

		/// <summary>
		///   Computes Quantized Rectified Linear 6: `min(max(features, 0), 6)`
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="min_features">
		///   The float value that the lowest quantized value represents.
		/// </param>
		/// <param name="max_features">
		///   The float value that the highest quantized value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedRelu6'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   activations: Has the same output shape as "features".
		///   min_activations: The float value that the lowest quantized value represents.
		///   max_activations: The float value that the highest quantized value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput activations, TFOutput min_activations, TFOutput max_activations) QuantizedRelu6 (TFOutput features, TFOutput min_features, TFOutput max_features, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedRelu6", MakeName ("QuantizedRelu6", operName));
			desc.AddInput (features);
			desc.AddInput (min_features);
			desc.AddInput (max_features);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			var min_activations = new TFOutput (op, _idx++);
			var max_activations = new TFOutput (op, _idx++);
			return (activations, min_activations, max_activations);
		}

		/// <summary>
		///   Computes Quantized Rectified Linear X: `min(max(features, 0), max_value)`
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="max_value">
		/// </param>
		/// <param name="min_features">
		///   The float value that the lowest quantized value represents.
		/// </param>
		/// <param name="max_features">
		///   The float value that the highest quantized value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedReluX'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   activations: Has the same output shape as "features".
		///   min_activations: The float value that the lowest quantized value represents.
		///   max_activations: The float value that the highest quantized value represents.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput activations, TFOutput min_activations, TFOutput max_activations) QuantizedReluX (TFOutput features, TFOutput max_value, TFOutput min_features, TFOutput max_features, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedReluX", MakeName ("QuantizedReluX", operName));
			desc.AddInput (features);
			desc.AddInput (max_value);
			desc.AddInput (min_features);
			desc.AddInput (max_features);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			var min_activations = new TFOutput (op, _idx++);
			var max_activations = new TFOutput (op, _idx++);
			return (activations, min_activations, max_activations);
		}

		/// <summary>
		///   Reshapes a quantized tensor as per the Reshape op.
		/// </summary>
		/// <param name="tensor">
		/// </param>
		/// <param name="shape">
		///   Defines the shape of the output tensor.
		/// </param>
		/// <param name="input_min">
		///   The minimum value of the input.
		/// </param>
		/// <param name="input_max">
		///   The maximum value of the input.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizedReshape'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   output_min: This value is copied from input_min.
		///   output_max: This value is copied from input_max.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   ```
		/// </remarks>
		public (TFOutput output, TFOutput output_min, TFOutput output_max) QuantizedReshape (TFOutput tensor, TFOutput shape, TFOutput input_min, TFOutput input_max, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizedReshape", MakeName ("QuantizedReshape", operName));
			desc.AddInput (tensor);
			desc.AddInput (shape);
			desc.AddInput (input_min);
			desc.AddInput (input_max);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output, output_min, output_max);
		}

		/// <summary>
		///   Quantize the 'input' tensor of type float to 'output' tensor of type 'T'.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="min_range">
		///   The minimum scalar value possibly produced for the input.
		/// </param>
		/// <param name="max_range">
		///   The maximum scalar value possibly produced for the input.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QuantizeV2'.
		/// </param>
		/// <param name="mode">
		///   Optional argument
		/// </param>
		/// <param name="T">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: The quantized data produced from the float input.
		///   output_min: The actual minimum scalar value used for the output.
		///   output_max: The actual maximum scalar value used for the output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   [min_range, max_range] are scalar floats that specify the range for
		///   the 'input' data. The 'mode' attribute controls exactly which calculations are
		///   used to convert the float values to their quantized equivalents.
		///   
		///   In 'MIN_COMBINED' mode, each value of the tensor will undergo the following:
		///   
		///   ```
		///   out[i] = (in[i] - min_range) * range(T) / (max_range - min_range)
		///   if T == qint8, out[i] -= (range(T) + 1) / 2.0
		///   ```
		///   here `range(T) = numeric_limits&amp;lt;T&amp;gt;::max() - numeric_limits&amp;lt;T&amp;gt;::min()`
		///   
		///   *MIN_COMBINED Mode Example*
		///   
		///   Assume the input is type float and has a possible range of [0.0, 6.0] and the
		///   output type is quint8 ([0, 255]). The min_range and max_range values should be
		///   specified as 0.0 and 6.0. Quantizing from float to quint8 will multiply each
		///   value of the input by 255/6 and cast to quint8.
		///   
		///   If the output type was qint8 ([-128, 127]), the operation will additionally
		///   subtract each value by 128 prior to casting, so that the range of values aligns
		///   with the range of qint8.
		///   
		///   If the mode is 'MIN_FIRST', then this approach is used:
		///   
		///   ```
		///   number_of_steps = 1 &amp;lt;&amp;lt; (# of bits in T)
		///   range_adjust = number_of_steps / (number_of_steps - 1)
		///   range = (range_max - range_min) * range_adjust
		///   range_scale = number_of_steps / range
		///   quantized = round(input * range_scale) - round(range_min * range_scale) +
		///     numeric_limits&amp;lt;T&amp;gt;::min()
		///   quantized = max(quantized, numeric_limits&amp;lt;T&amp;gt;::min())
		///   quantized = min(quantized, numeric_limits&amp;lt;T&amp;gt;::max())
		///   ```
		///   
		///   The biggest difference between this and MIN_COMBINED is that the minimum range
		///   is rounded first, before it's subtracted from the rounded value. With
		///   MIN_COMBINED, a small bias is introduced where repeated iterations of quantizing
		///   and dequantizing will introduce a larger and larger error.
		///   
		///   One thing to watch out for is that the operator may choose to adjust the
		///   requested minimum and maximum values slightly during the quantization process,
		///   so you should always use the output ports as the range for further calculations.
		///   For example, if the requested minimum and maximum values are close to equal,
		///   they will be separated by a small epsilon value to prevent ill-formed quantized
		///   buffers from being created. Otherwise, you can end up with buffers where all the
		///   quantized values map to the same float value, which causes problems for
		///   operations that have to perform further calculations on them.
		/// </remarks>
		public (TFOutput output, TFOutput output_min, TFOutput output_max) QuantizeV2 (TFOutput input, TFOutput min_range, TFOutput max_range, TFDataType T, string mode = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QuantizeV2", MakeName ("QuantizeV2", operName));
			desc.AddInput (input);
			desc.AddInput (min_range);
			desc.AddInput (max_range);
			desc.SetAttrType ("T", T);
			if (mode != null)
				desc.SetAttr ("mode", mode);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output, output_min, output_max);
		}

		/// <summary>
		///   Closes the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueCloseV2'.
		/// </param>
		/// <param name="cancel_pending_enqueues">
		///   Optional argument
		///   If true, all pending enqueue requests that are
		///   blocked on the given queue will be cancelled.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This operation signals that no more elements will be enqueued in the
		///   given queue. Subsequent Enqueue(Many) operations will fail.
		///   Subsequent Dequeue(Many) operations will continue to succeed if
		///   sufficient elements remain in the queue. Subsequent Dequeue(Many)
		///   operations that would block will fail immediately.
		/// </remarks>
		public TFOperation QueueCloseV2 (TFOutput handle, bool? cancel_pending_enqueues = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueCloseV2", MakeName ("QueueCloseV2", operName));
			desc.AddInput (handle);
			if (cancel_pending_enqueues.HasValue)
				desc.SetAttr ("cancel_pending_enqueues", cancel_pending_enqueues.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Dequeues `n` tuples of one or more tensors from the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="n">
		///   The number of tuples to dequeue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueDequeueManyV2'.
		/// </param>
		/// <param name="timeout_ms">
		///   Optional argument
		///   If the queue has fewer than n elements, this operation
		///   will block for up to timeout_ms milliseconds.
		///   Note: This option is not supported yet.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a tuple.
		/// </param>
		/// <returns>
		///   One or more tensors that were dequeued as a tuple.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   If the queue is closed and there are fewer than `n` elements, then an
		///   OutOfRange error is returned.
		///   
		///   This operation concatenates queue-element component tensors along the
		///   0th dimension to make a single component tensor.  All of the components
		///   in the dequeued tuple will have size `n` in the 0th dimension.
		///   
		///   This operation has `k` outputs, where `k` is the number of components in
		///   the tuples stored in the given queue, and output `i` is the ith
		///   component of the dequeued tuple.
		///   
		///   N.B. If the queue is empty, this operation will block until `n` elements
		///   have been dequeued (or 'timeout_ms' elapses, if specified).
		/// </remarks>
		public TFOutput[] QueueDequeueManyV2 (TFOutput handle, TFOutput n, TFDataType[] component_types, long? timeout_ms = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueDequeueManyV2", MakeName ("QueueDequeueManyV2", operName));
			desc.AddInput (handle);
			desc.AddInput (n);
			desc.SetAttrType ("component_types", component_types);
			if (timeout_ms.HasValue)
				desc.SetAttr ("timeout_ms", timeout_ms.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("components");
			var components = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				components [i] = new TFOutput (op, _idx++);
			
			return components;
		}

		/// <summary>
		///   Dequeues `n` tuples of one or more tensors from the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="n">
		///   The number of tuples to dequeue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueDequeueUpToV2'.
		/// </param>
		/// <param name="timeout_ms">
		///   Optional argument
		///   If the queue has fewer than n elements, this operation
		///   will block for up to timeout_ms milliseconds.
		///   Note: This option is not supported yet.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a tuple.
		/// </param>
		/// <returns>
		///   One or more tensors that were dequeued as a tuple.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation is not supported by all queues.  If a queue does not support
		///   DequeueUpTo, then an Unimplemented error is returned.
		///   
		///   If the queue is closed and there are more than 0 but less than `n`
		///   elements remaining, then instead of returning an OutOfRange error like
		///   QueueDequeueMany, less than `n` elements are returned immediately.  If
		///   the queue is closed and there are 0 elements left in the queue, then
		///   an OutOfRange error is returned just like in QueueDequeueMany.
		///   Otherwise the behavior is identical to QueueDequeueMany:
		///   
		///   This operation concatenates queue-element component tensors along the
		///   0th dimension to make a single component tensor.  All of the components
		///   in the dequeued tuple will have size n in the 0th dimension.
		///   
		///   This operation has `k` outputs, where `k` is the number of components in
		///   the tuples stored in the given queue, and output `i` is the ith
		///   component of the dequeued tuple.
		/// </remarks>
		public TFOutput[] QueueDequeueUpToV2 (TFOutput handle, TFOutput n, TFDataType[] component_types, long? timeout_ms = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueDequeueUpToV2", MakeName ("QueueDequeueUpToV2", operName));
			desc.AddInput (handle);
			desc.AddInput (n);
			desc.SetAttrType ("component_types", component_types);
			if (timeout_ms.HasValue)
				desc.SetAttr ("timeout_ms", timeout_ms.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("components");
			var components = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				components [i] = new TFOutput (op, _idx++);
			
			return components;
		}

		/// <summary>
		///   Dequeues a tuple of one or more tensors from the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueDequeueV2'.
		/// </param>
		/// <param name="timeout_ms">
		///   Optional argument
		///   If the queue is empty, this operation will block for up to
		///   timeout_ms milliseconds.
		///   Note: This option is not supported yet.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a tuple.
		/// </param>
		/// <returns>
		///   One or more tensors that were dequeued as a tuple.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation has k outputs, where k is the number of components
		///   in the tuples stored in the given queue, and output i is the ith
		///   component of the dequeued tuple.
		///   
		///   N.B. If the queue is empty, this operation will block until an element
		///   has been dequeued (or 'timeout_ms' elapses, if specified).
		/// </remarks>
		public TFOutput[] QueueDequeueV2 (TFOutput handle, TFDataType[] component_types, long? timeout_ms = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueDequeueV2", MakeName ("QueueDequeueV2", operName));
			desc.AddInput (handle);
			desc.SetAttrType ("component_types", component_types);
			if (timeout_ms.HasValue)
				desc.SetAttr ("timeout_ms", timeout_ms.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("components");
			var components = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				components [i] = new TFOutput (op, _idx++);
			
			return components;
		}

		/// <summary>
		///   Enqueues zero or more tuples of one or more tensors in the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="components">
		///   One or more tensors from which the enqueued tensors should
		///   be taken.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueEnqueueManyV2'.
		/// </param>
		/// <param name="timeout_ms">
		///   Optional argument
		///   If the queue is too full, this operation will block for up
		///   to timeout_ms milliseconds.
		///   Note: This option is not supported yet.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This operation slices each component tensor along the 0th dimension to
		///   make multiple queue elements. All of the tuple components must have the
		///   same size in the 0th dimension.
		///   
		///   The components input has k elements, which correspond to the components of
		///   tuples stored in the given queue.
		///   
		///   N.B. If the queue is full, this operation will block until the given
		///   elements have been enqueued (or 'timeout_ms' elapses, if specified).
		/// </remarks>
		public TFOperation QueueEnqueueManyV2 (TFOutput handle, TFOutput[] components, long? timeout_ms = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueEnqueueManyV2", MakeName ("QueueEnqueueManyV2", operName));
			desc.AddInput (handle);
			desc.AddInputs (components);
			if (timeout_ms.HasValue)
				desc.SetAttr ("timeout_ms", timeout_ms.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Enqueues a tuple of one or more tensors in the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="components">
		///   One or more tensors from which the enqueued tensors should be taken.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueEnqueueV2'.
		/// </param>
		/// <param name="timeout_ms">
		///   Optional argument
		///   If the queue is full, this operation will block for up to
		///   timeout_ms milliseconds.
		///   Note: This option is not supported yet.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The components input has k elements, which correspond to the components of
		///   tuples stored in the given queue.
		///   
		///   N.B. If the queue is full, this operation will block until the given
		///   element has been enqueued (or 'timeout_ms' elapses, if specified).
		/// </remarks>
		public TFOperation QueueEnqueueV2 (TFOutput handle, TFOutput[] components, long? timeout_ms = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueEnqueueV2", MakeName ("QueueEnqueueV2", operName));
			desc.AddInput (handle);
			desc.AddInputs (components);
			if (timeout_ms.HasValue)
				desc.SetAttr ("timeout_ms", timeout_ms.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Computes the number of elements in the given queue.
		/// </summary>
		/// <param name="handle">
		///   The handle to a queue.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'QueueSizeV2'.
		/// </param>
		/// <returns>
		///   The number of elements in the given queue.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput QueueSizeV2 (TFOutput handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "QueueSizeV2", MakeName ("QueueSizeV2", operName));
			desc.AddInput (handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var size = new TFOutput (op, _idx++);
			return size;
		}

		/// <summary>
		///   Randomly crop `image`.
		/// </summary>
		/// <param name="image">
		///   3-D of shape `[height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   1-D of length 2 containing: `crop_height`, `crop_width`..
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomCrop'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   3-D of shape `[crop_height, crop_width, channels].`
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `size` is a 1-D int64 tensor with 2 elements representing the crop height and
		///   width.  The values must be non negative.
		///   
		///   This Op picks a random location in `image` and crops a `height` by `width`
		///   rectangle from that location.  The random location is picked so the cropped
		///   area will fit inside the original image.
		/// </remarks>
		public TFOutput RandomCrop (TFOutput image, TFOutput size, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomCrop", MakeName ("RandomCrop", operName));
			desc.AddInput (image);
			desc.AddInput (size);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs random values from the Gamma distribution(s) described by alpha.
		/// </summary>
		/// <param name="shape">
		///   1-D integer tensor. Shape of independent samples to draw from each
		///   distribution described by the shape parameters given in alpha.
		/// </param>
		/// <param name="alpha">
		///   A tensor in which each scalar is a "shape" parameter describing the
		///   associated gamma distribution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomGamma'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   A tensor with shape `shape + shape(alpha)`. Each slice
		///   `[:, ..., :, i0, i1, ...iN]` contains the samples drawn for
		///   `alpha[i0, i1, ...iN]`. The dtype of the output matches the dtype of alpha.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op uses the algorithm by Marsaglia et al. to acquire samples via
		///   transformation-rejection from pairs of uniform and normal random variables.
		///   See http://dl.acm.org/citation.cfm?id=358414
		/// </remarks>
		public TFOutput RandomGamma (TFOutput shape, TFOutput alpha, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomGamma", MakeName ("RandomGamma", operName));
			desc.AddInput (shape);
			desc.AddInput (alpha);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs random values from the Poisson distribution(s) described by rate.
		/// </summary>
		/// <param name="shape">
		///   1-D integer tensor. Shape of independent samples to draw from each
		///   distribution described by the shape parameters given in rate.
		/// </param>
		/// <param name="rate">
		///   A tensor in which each scalar is a "rate" parameter describing the
		///   associated poisson distribution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomPoisson'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   A tensor with shape `shape + shape(rate)`. Each slice
		///   `[:, ..., :, i0, i1, ...iN]` contains the samples drawn for
		///   `rate[i0, i1, ...iN]`. The dtype of the output matches the dtype of
		///   rate.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op uses two algorithms, depending on rate. If rate &amp;gt;= 10, then
		///   the algorithm by Hormann is used to acquire samples via
		///   transformation-rejection.
		///   See http://www.sciencedirect.com/science/article/pii/0167668793909974.
		///   
		///   Otherwise, Knuth's algorithm is used to acquire samples via multiplying uniform
		///   random variables.
		///   See Donald E. Knuth (1969). Seminumerical Algorithms. The Art of Computer
		///   Programming, Volume 2. Addison Wesley
		/// </remarks>
		public TFOutput RandomPoisson (TFOutput shape, TFOutput rate, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomPoisson", MakeName ("RandomPoisson", operName));
			desc.AddInput (shape);
			desc.AddInput (rate);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Randomly shuffles a tensor along its first dimension.
		/// </summary>
		/// <param name="value">
		///   The tensor to be shuffled.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomShuffle'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   A tensor of same shape and type as `value`, shuffled along its first
		///   dimension.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///     The tensor is shuffled along dimension 0, such that each `value[j]` is mapped
		///     to one and only one `output[i]`. For example, a mapping that might occur for a
		///     3x2 tensor is:
		///   
		///   ```prettyprint
		///   [[1, 2],       [[5, 6],
		///    [3, 4],  ==&amp;gt;   [1, 2],
		///    [5, 6]]        [3, 4]]
		///   ```
		/// </remarks>
		public TFOutput RandomShuffle (TFOutput value, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomShuffle", MakeName ("RandomShuffle", operName));
			desc.AddInput (value);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   A queue that randomizes the order of elements.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomShuffleQueueV2'.
		/// </param>
		/// <param name="shapes">
		///   Optional argument
		///   The shape of each component in a value. The length of this attr must
		///   be either 0 or the same as the length of component_types. If the length of
		///   this attr is 0, the shapes of queue elements are not constrained, and
		///   only one element may be dequeued at a time.
		/// </param>
		/// <param name="capacity">
		///   Optional argument
		///   The upper bound on the number of elements in this queue.
		///   Negative numbers mean no limit.
		/// </param>
		/// <param name="min_after_dequeue">
		///   Optional argument
		///   Dequeue will block unless there would be this
		///   many elements after the dequeue or the queue is closed. This
		///   ensures a minimum level of mixing of elements.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 is set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, a random seed is used.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this queue is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this queue will be shared under the given name
		///   across multiple sessions.
		/// </param>
		/// <param name="component_types">
		///   The type of each component in a value.
		/// </param>
		/// <returns>
		///   The handle to the queue.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput RandomShuffleQueueV2 (TFDataType[] component_types, TFShape[] shapes = null, long? capacity = null, long? min_after_dequeue = null, long? seed = null, long? seed2 = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomShuffleQueueV2", MakeName ("RandomShuffleQueueV2", operName));
			desc.SetAttrType ("component_types", component_types);
			if (shapes != null)
				desc.SetAttrShape ("shapes", shapes);
			
			if (capacity.HasValue)
				desc.SetAttr ("capacity", capacity.Value);
			
			if (min_after_dequeue.HasValue)
				desc.SetAttr ("min_after_dequeue", min_after_dequeue.Value);
			
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Outputs random values from a normal distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomStandardNormal'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <param name="dtype">
		///   The type of the output.
		/// </param>
		/// <returns>
		///   A tensor of the specified shape filled with random normal values.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values will have mean 0 and standard deviation 1.
		/// </remarks>
		public TFOutput RandomStandardNormal (TFOutput shape, TFDataType dtype, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomStandardNormal", MakeName ("RandomStandardNormal", operName));
			desc.AddInput (shape);
			desc.SetAttrType ("dtype", dtype);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs random values from a uniform distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomUniform'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <param name="dtype">
		///   The type of the output.
		/// </param>
		/// <returns>
		///   A tensor of the specified shape filled with uniform random values.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values follow a uniform distribution in the range `[0, 1)`. The
		///   lower bound 0 is included in the range, while the upper bound 1 is excluded.
		/// </remarks>
		public TFOutput RandomUniform (TFOutput shape, TFDataType dtype, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomUniform", MakeName ("RandomUniform", operName));
			desc.AddInput (shape);
			desc.SetAttrType ("dtype", dtype);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs random integers from a uniform distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="minval">
		///   0-D.  Inclusive lower bound on the generated integers.
		/// </param>
		/// <param name="maxval">
		///   0-D.  Exclusive upper bound on the generated integers.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RandomUniformInt'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <returns>
		///   A tensor of the specified shape filled with uniform random integers.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values are uniform integers in the range `[minval, maxval)`.
		///   The lower bound `minval` is included in the range, while the upper bound
		///   `maxval` is excluded.
		///   
		///   The random integers are slightly biased unless `maxval - minval` is an exact
		///   power of two.  The bias is small for values of `maxval - minval` significantly
		///   smaller than the range of the output (either `2^32` or `2^64`).
		/// </remarks>
		public TFOutput RandomUniformInt (TFOutput shape, TFOutput minval, TFOutput maxval, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RandomUniformInt", MakeName ("RandomUniformInt", operName));
			desc.AddInput (shape);
			desc.AddInput (minval);
			desc.AddInput (maxval);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a sequence of numbers.
		/// </summary>
		/// <param name="start">
		///   0-D (scalar). First entry in the sequence.
		/// </param>
		/// <param name="limit">
		///   0-D (scalar). Upper limit of sequence, exclusive.
		/// </param>
		/// <param name="delta">
		///   0-D (scalar). Optional. Default is 1. Number that increments `start`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Range'.
		/// </param>
		/// <returns>
		///   1-D.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation creates a sequence of numbers that begins at `start` and
		///   extends by increments of `delta` up to but not including `limit`.
		///   
		///   For example:
		///   
		///   ```
		///   # 'start' is 3
		///   # 'limit' is 18
		///   # 'delta' is 3
		///   tf.range(start, limit, delta) ==&amp;gt; [3, 6, 9, 12, 15]
		///   ```
		/// </remarks>
		public TFOutput Range (TFOutput start, TFOutput limit, TFOutput delta, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Range", MakeName ("Range", operName));
			desc.AddInput (start);
			desc.AddInput (limit);
			desc.AddInput (delta);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a dataset with a range of values. Corresponds to python's xrange.
		/// </summary>
		/// <param name="start">
		///   corresponds to start in python's xrange().
		/// </param>
		/// <param name="stop">
		///   corresponds to stop in python's xrange().
		/// </param>
		/// <param name="step">
		///   corresponds to step in python's xrange().
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RangeDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput RangeDataset (TFOutput start, TFOutput stop, TFOutput step, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RangeDataset", MakeName ("RangeDataset", operName));
			desc.AddInput (start);
			desc.AddInput (stop);
			desc.AddInput (step);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Returns the rank of a tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Rank'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns an integer representing the rank of `input`.
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[[1, 1, 1], [2, 2, 2]], [[3, 3, 3], [4, 4, 4]]]
		///   # shape of tensor 't' is [2, 2, 3]
		///   rank(t) ==&amp;gt; 3
		///   ```
		///   
		///   **Note**: The rank of a tensor is not the same as the rank of a matrix. The rank
		///   of a tensor is the number of indices required to uniquely select each element
		///   of the tensor. Rank is also known as "order", "degree", or "ndims."
		/// </remarks>
		public TFOutput Rank (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Rank", MakeName ("Rank", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the number of records this Reader has produced.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderNumRecordsProducedV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is the same as the number of ReaderRead executions that have
		///   succeeded.
		/// </remarks>
		public TFOutput ReaderNumRecordsProducedV2 (TFOutput reader_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderNumRecordsProducedV2", MakeName ("ReaderNumRecordsProducedV2", operName));
			desc.AddInput (reader_handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var records_produced = new TFOutput (op, _idx++);
			return records_produced;
		}

		/// <summary>
		///   Returns the number of work units this Reader has finished processing.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderNumWorkUnitsCompletedV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ReaderNumWorkUnitsCompletedV2 (TFOutput reader_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderNumWorkUnitsCompletedV2", MakeName ("ReaderNumWorkUnitsCompletedV2", operName));
			desc.AddInput (reader_handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var units_completed = new TFOutput (op, _idx++);
			return units_completed;
		}

		/// <summary>
		///   Returns up to `num_records` (key, value) pairs produced by a Reader.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a `Reader`.
		/// </param>
		/// <param name="queue_handle">
		///   Handle to a `Queue`, with string work items.
		/// </param>
		/// <param name="num_records">
		///   number of records to read from `Reader`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderReadUpToV2'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   keys: A 1-D tensor.
		///   values: A 1-D tensor.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Will dequeue from the input queue if necessary (e.g. when the
		///   Reader needs to start reading from a new file since it has finished
		///   with the previous file).
		///   It may return less than `num_records` even before the last batch.
		/// </remarks>
		public (TFOutput keys, TFOutput values) ReaderReadUpToV2 (TFOutput reader_handle, TFOutput queue_handle, TFOutput num_records, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderReadUpToV2", MakeName ("ReaderReadUpToV2", operName));
			desc.AddInput (reader_handle);
			desc.AddInput (queue_handle);
			desc.AddInput (num_records);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var keys = new TFOutput (op, _idx++);
			var values = new TFOutput (op, _idx++);
			return (keys, values);
		}

		/// <summary>
		///   Returns the next record (key, value pair) produced by a Reader.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="queue_handle">
		///   Handle to a Queue, with string work items.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderReadV2'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   key: A scalar.
		///   value: A scalar.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Will dequeue from the input queue if necessary (e.g. when the
		///   Reader needs to start reading from a new file since it has finished
		///   with the previous file).
		/// </remarks>
		public (TFOutput key, TFOutput value) ReaderReadV2 (TFOutput reader_handle, TFOutput queue_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderReadV2", MakeName ("ReaderReadV2", operName));
			desc.AddInput (reader_handle);
			desc.AddInput (queue_handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var key = new TFOutput (op, _idx++);
			var value = new TFOutput (op, _idx++);
			return (key, value);
		}

		/// <summary>
		///   Restore a Reader to its initial clean state.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderResetV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation ReaderResetV2 (TFOutput reader_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderResetV2", MakeName ("ReaderResetV2", operName));
			desc.AddInput (reader_handle);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Restore a reader to a previously saved state.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="state">
		///   Result of a ReaderSerializeState of a Reader with type
		///   matching reader_handle.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderRestoreStateV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Not all Readers support being restored, so this can produce an
		///   Unimplemented error.
		/// </remarks>
		public TFOperation ReaderRestoreStateV2 (TFOutput reader_handle, TFOutput state, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderRestoreStateV2", MakeName ("ReaderRestoreStateV2", operName));
			desc.AddInput (reader_handle);
			desc.AddInput (state);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Produce a string tensor that encodes the state of a Reader.
		/// </summary>
		/// <param name="reader_handle">
		///   Handle to a Reader.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReaderSerializeStateV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Not all Readers support being serialized, so this can produce an
		///   Unimplemented error.
		/// </remarks>
		public TFOutput ReaderSerializeStateV2 (TFOutput reader_handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReaderSerializeStateV2", MakeName ("ReaderSerializeStateV2", operName));
			desc.AddInput (reader_handle);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var state = new TFOutput (op, _idx++);
			return state;
		}

		/// <summary>
		///   Reads and outputs the entire contents of the input filename.
		/// </summary>
		/// <param name="filename">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReadFile'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ReadFile (TFOutput filename, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReadFile", MakeName ("ReadFile", operName));
			desc.AddInput (filename);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var contents = new TFOutput (op, _idx++);
			return contents;
		}

		/// <summary>
		///   Reads the value of a variable.
		/// </summary>
		/// <param name="resource">
		///   handle to the resource in which to store the variable.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReadVariableOp'.
		/// </param>
		/// <param name="dtype">
		///   the dtype of the value.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The tensor returned by this operation is immutable.
		///   
		///   The value returned by this operation is guaranteed to be influenced by all the
		///   writes on which this operation depends directly or indirectly, and to not be
		///   influenced by any of the writes which depend directly or indirectly on this
		///   operation.
		/// </remarks>
		public TFOutput ReadVariableOp (TFOutput resource, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReadVariableOp", MakeName ("ReadVariableOp", operName));
			desc.AddInput (resource);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Returns the real part of a complex number.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Real'.
		/// </param>
		/// <param name="Tout">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input` of complex numbers, this operation returns a tensor of
		///   type `float` that is the real part of each element in `input`. All elements in
		///   `input` must be complex numbers of the form \\(a + bj\\), where *a* is the real
		///    part returned by this operation and *b* is the imaginary part.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'input' is [-2.25 + 4.75j, 3.25 + 5.75j]
		///   tf.real(input) ==&amp;gt; [-2.25, 3.25]
		///   ```
		/// </remarks>
		public TFOutput Real (TFOutput input, TFDataType? Tout = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Real", MakeName ("Real", operName));
			desc.AddInput (input);
			if (Tout.HasValue)
				desc.SetAttrType ("Tout", Tout.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns x / y element-wise for real types.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RealDiv'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   If `x` and `y` are reals, this will return the floating-point division.
		///   
		///   *NOTE*: `Div` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput RealDiv (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RealDiv", MakeName ("RealDiv", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes the reciprocal of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Reciprocal'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = 1 / x\\).
		/// </remarks>
		public TFOutput Reciprocal (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Reciprocal", MakeName ("Reciprocal", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient for the inverse of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReciprocalGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = -dy * y*y`, where `y = 1/x`, and `dy`
		///   is the corresponding input gradient.
		/// </remarks>
		public TFOutput ReciprocalGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReciprocalGrad", MakeName ("ReciprocalGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Emits randomized records.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RecordInput'.
		/// </param>
		/// <param name="file_random_seed">
		///   Optional argument
		///   Random seeds used to produce randomized records.
		/// </param>
		/// <param name="file_shuffle_shift_ratio">
		///   Optional argument
		///   Shifts the list of files after the list is randomly
		///   shuffled.
		/// </param>
		/// <param name="file_buffer_size">
		///   Optional argument
		///   The randomization shuffling buffer.
		/// </param>
		/// <param name="file_parallelism">
		///   Optional argument
		///   How many sstables are opened and concurrently iterated over.
		/// </param>
		/// <param name="batch_size">
		///   Optional argument
		///   The batch size.
		/// </param>
		/// <param name="file_pattern">
		///   Glob pattern for the data files.
		/// </param>
		/// <returns>
		///   A tensor of shape [batch_size].
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput RecordInput (string file_pattern, long? file_random_seed = null, float? file_shuffle_shift_ratio = null, long? file_buffer_size = null, long? file_parallelism = null, long? batch_size = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RecordInput", MakeName ("RecordInput", operName));
			desc.SetAttr ("file_pattern", file_pattern);
			if (file_random_seed.HasValue)
				desc.SetAttr ("file_random_seed", file_random_seed.Value);
			
			if (file_shuffle_shift_ratio.HasValue)
				desc.SetAttr ("file_shuffle_shift_ratio", file_shuffle_shift_ratio.Value);
			
			if (file_buffer_size.HasValue)
				desc.SetAttr ("file_buffer_size", file_buffer_size.Value);
			
			if (file_parallelism.HasValue)
				desc.SetAttr ("file_parallelism", file_parallelism.Value);
			
			if (batch_size.HasValue)
				desc.SetAttr ("batch_size", batch_size.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var records = new TFOutput (op, _idx++);
			return records;
		}

		/// <summary>
		///   Joins a string Tensor across the given dimensions.
		/// </summary>
		/// <param name="inputs">
		///   The input to be joined.  All reduced indices must have non-zero size.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce over.  Dimensions are reduced in the
		///   order specified.  Omitting `reduction_indices` is equivalent to passing
		///   `[n-1, n-2, ..., 0]`.  Negative indices from `-n` to `-1` are supported.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReduceJoin'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If `True`, retain reduced dimensions with length `1`.
		/// </param>
		/// <param name="separator">
		///   Optional argument
		///   The separator to use when joining.
		/// </param>
		/// <returns>
		///   Has shape equal to that of the input with reduced dimensions removed or
		///   set to `1` depending on `keep_dims`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the string join across dimensions in the given string Tensor of shape
		///   `[d_0, d_1, ..., d_n-1]`.  Returns a new Tensor created by joining the input
		///   strings with the given separator (default: empty string).  Negative indices are
		///   counted backwards from the end, with `-1` being equivalent to `n - 1`.
		///   
		///   For example:
		///   
		///   ```python
		///   # tensor `a` is [["a", "b"], ["c", "d"]]
		///   tf.reduce_join(a, 0) ==&amp;gt; ["ac", "bd"]
		///   tf.reduce_join(a, 1) ==&amp;gt; ["ab", "cd"]
		///   tf.reduce_join(a, -2) = tf.reduce_join(a, 0) ==&amp;gt; ["ac", "bd"]
		///   tf.reduce_join(a, -1) = tf.reduce_join(a, 1) ==&amp;gt; ["ab", "cd"]
		///   tf.reduce_join(a, 0, keep_dims=True) ==&amp;gt; [["ac", "bd"]]
		///   tf.reduce_join(a, 1, keep_dims=True) ==&amp;gt; [["ab"], ["cd"]]
		///   tf.reduce_join(a, 0, separator=".") ==&amp;gt; ["a.c", "b.d"]
		///   tf.reduce_join(a, [0, 1]) ==&amp;gt; ["acbd"]
		///   tf.reduce_join(a, [1, 0]) ==&amp;gt; ["abcd"]
		///   tf.reduce_join(a, []) ==&amp;gt; ["abcd"]
		///   ```
		/// </remarks>
		public TFOutput ReduceJoin (TFOutput inputs, TFOutput reduction_indices, bool? keep_dims = null, string separator = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReduceJoin", MakeName ("ReduceJoin", operName));
			desc.AddInput (inputs);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			if (separator != null)
				desc.SetAttr ("separator", separator);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes rectified linear: `max(features, 0)`.
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Relu'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Relu (TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Relu", MakeName ("Relu", operName));
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			return activations;
		}

		/// <summary>
		///   Computes rectified linear 6: `min(max(features, 0), 6)`.
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Relu6'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Relu6 (TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Relu6", MakeName ("Relu6", operName));
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			return activations;
		}

		/// <summary>
		///   Computes rectified linear 6 gradients for a Relu6 operation.
		/// </summary>
		/// <param name="gradients">
		///   The backpropagated gradients to the corresponding Relu6 operation.
		/// </param>
		/// <param name="features">
		///   The features passed as input to the corresponding Relu6 operation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Relu6Grad'.
		/// </param>
		/// <returns>
		///   The gradients:
		///   `gradients * (features &amp;gt; 0) * (features &amp;lt; 6)`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Relu6Grad (TFOutput gradients, TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Relu6Grad", MakeName ("Relu6Grad", operName));
			desc.AddInput (gradients);
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   Computes rectified linear gradients for a Relu operation.
		/// </summary>
		/// <param name="gradients">
		///   The backpropagated gradients to the corresponding Relu operation.
		/// </param>
		/// <param name="features">
		///   The features passed as input to the corresponding Relu operation, OR
		///   the outputs of that operation (both work equivalently).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReluGrad'.
		/// </param>
		/// <returns>
		///   `gradients * (features &amp;gt; 0)`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ReluGrad (TFOutput gradients, TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReluGrad", MakeName ("ReluGrad", operName));
			desc.AddInput (gradients);
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   Execute a sub graph on a remote processor transferred by GraphTransferer.
		/// </summary>
		/// <param name="inputs">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RemoteFusedGraphExecute'.
		/// </param>
		/// <param name="Toutputs">
		/// </param>
		/// <param name="serialized_remote_fused_graph_execute_info">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The graph specifications are serialized by protobuf as graph_transfer_info.
		///   The implementation / limitations may differ for each platform
		///   and each available peripheral.
		/// </remarks>
		public TFOutput[] RemoteFusedGraphExecute (TFOutput[] inputs, TFDataType[] Toutputs, string serialized_remote_fused_graph_execute_info, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RemoteFusedGraphExecute", MakeName ("RemoteFusedGraphExecute", operName));
			desc.AddInputs (inputs);
			desc.SetAttrType ("Toutputs", Toutputs);
			desc.SetAttr ("serialized_remote_fused_graph_execute_info", serialized_remote_fused_graph_execute_info);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("outputs");
			var outputs = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				outputs [i] = new TFOutput (op, _idx++);
			
			return outputs;
		}

		/// <summary>
		///   Creates a dataset that emits the outputs of `input_dataset` `count` times.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="count">
		///   A scalar representing the number of times that `input_dataset` should
		///   be repeated. A value of `-1` indicates that it should be repeated infinitely.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RepeatDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput RepeatDataset (TFOutput input_dataset, TFOutput count, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RepeatDataset", MakeName ("RepeatDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (count);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Given a quantized tensor described by (input, input_min, input_max), outputs a
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="input_min">
		///   The float value that the minimum quantized input value represents.
		/// </param>
		/// <param name="input_max">
		///   The float value that the maximum quantized input value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RequantizationRange'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_min: The computed min output.
		///   output_max: the computed max output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   range that covers the actual values present in that tensor.  This op is
		///   typically used to produce the requested_output_min and requested_output_max for
		///   Requantize.
		/// </remarks>
		public (TFOutput output_min, TFOutput output_max) RequantizationRange (TFOutput input, TFOutput input_min, TFOutput input_max, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RequantizationRange", MakeName ("RequantizationRange", operName));
			desc.AddInput (input);
			desc.AddInput (input_min);
			desc.AddInput (input_max);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output_min, output_max);
		}

		/// <summary>
		///   Convert the quantized 'input' tensor into a lower-precision 'output', using the
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="input_min">
		///   The float value that the minimum quantized input value represents.
		/// </param>
		/// <param name="input_max">
		///   The float value that the maximum quantized input value represents.
		/// </param>
		/// <param name="requested_output_min">
		///   The float value that the minimum quantized output value represents.
		/// </param>
		/// <param name="requested_output_max">
		///   The float value that the maximum quantized output value represents.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Requantize'.
		/// </param>
		/// <param name="out_type">
		///   The type of the output. Should be a lower bit depth than Tinput.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output: 
		///   output_min: The requested_output_min value is copied into this output.
		///   output_max: The requested_output_max value is copied into this output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   output range specified with 'requested_output_min' and 'requested_output_max'.
		///   
		///   [input_min, input_max] are scalar floats that specify the range for the float
		///   interpretation of the 'input' data. For example, if input_min is -1.0f and
		///   input_max is 1.0f, and we are dealing with quint16 quantized data, then a 0
		///   value in the 16-bit data should be interpreted as -1.0f, and a 65535 means 1.0f.
		/// </remarks>
		public (TFOutput output, TFOutput output_min, TFOutput output_max) Requantize (TFOutput input, TFOutput input_min, TFOutput input_max, TFOutput requested_output_min, TFOutput requested_output_max, TFDataType out_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Requantize", MakeName ("Requantize", operName));
			desc.AddInput (input);
			desc.AddInput (input_min);
			desc.AddInput (input_max);
			desc.AddInput (requested_output_min);
			desc.AddInput (requested_output_max);
			desc.SetAttrType ("out_type", out_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			var output_min = new TFOutput (op, _idx++);
			var output_max = new TFOutput (op, _idx++);
			return (output, output_min, output_max);
		}

		/// <summary>
		///   Reshapes a tensor.
		/// </summary>
		/// <param name="tensor">
		/// </param>
		/// <param name="shape">
		///   Defines the shape of the output tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Reshape'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given `tensor`, this operation returns a tensor that has the same values
		///   as `tensor` with shape `shape`.
		///   
		///   If one component of `shape` is the special value -1, the size of that dimension
		///   is computed so that the total size remains constant.  In particular, a `shape`
		///   of `[-1]` flattens into 1-D.  At most one component of `shape` can be -1.
		///   
		///   If `shape` is 1-D or higher, then the operation returns a tensor with shape
		///   `shape` filled with the values of `tensor`. In this case, the number of elements
		///   implied by `shape` must be the same as the number of elements in `tensor`.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 't' is [1, 2, 3, 4, 5, 6, 7, 8, 9]
		///   # tensor 't' has shape [9]
		///   reshape(t, [3, 3]) ==&amp;gt; [[1, 2, 3],
		///                           [4, 5, 6],
		///                           [7, 8, 9]]
		///   
		///   # tensor 't' is [[[1, 1], [2, 2]],
		///   #                [[3, 3], [4, 4]]]
		///   # tensor 't' has shape [2, 2, 2]
		///   reshape(t, [2, 4]) ==&amp;gt; [[1, 1, 2, 2],
		///                           [3, 3, 4, 4]]
		///   
		///   # tensor 't' is [[[1, 1, 1],
		///   #                 [2, 2, 2]],
		///   #                [[3, 3, 3],
		///   #                 [4, 4, 4]],
		///   #                [[5, 5, 5],
		///   #                 [6, 6, 6]]]
		///   # tensor 't' has shape [3, 2, 3]
		///   # pass '[-1]' to flatten 't'
		///   reshape(t, [-1]) ==&amp;gt; [1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6]
		///   
		///   # -1 can also be used to infer the shape
		///   
		///   # -1 is inferred to be 9:
		///   reshape(t, [2, -1]) ==&amp;gt; [[1, 1, 1, 2, 2, 2, 3, 3, 3],
		///                            [4, 4, 4, 5, 5, 5, 6, 6, 6]]
		///   # -1 is inferred to be 2:
		///   reshape(t, [-1, 9]) ==&amp;gt; [[1, 1, 1, 2, 2, 2, 3, 3, 3],
		///                            [4, 4, 4, 5, 5, 5, 6, 6, 6]]
		///   # -1 is inferred to be 3:
		///   reshape(t, [ 2, -1, 3]) ==&amp;gt; [[[1, 1, 1],
		///                                 [2, 2, 2],
		///                                 [3, 3, 3]],
		///                                [[4, 4, 4],
		///                                 [5, 5, 5],
		///                                 [6, 6, 6]]]
		///   
		///   # tensor 't' is [7]
		///   # shape `[]` reshapes to a scalar
		///   reshape(t, []) ==&amp;gt; 7
		///   ```
		/// </remarks>
		public TFOutput Reshape (TFOutput tensor, TFOutput shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Reshape", MakeName ("Reshape", operName));
			desc.AddInput (tensor);
			desc.AddInput (shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Resize `images` to `size` using area interpolation.
		/// </summary>
		/// <param name="images">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   = A 1-D int32 Tensor of 2 elements: `new_height, new_width`.  The
		///   new size for the images.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeArea'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale input by (new_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of images and resized images. If false, rescale
		///   by new_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[batch, new_height, new_width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Input images can be of different types but output images are always float.
		/// </remarks>
		public TFOutput ResizeArea (TFOutput images, TFOutput size, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeArea", MakeName ("ResizeArea", operName));
			desc.AddInput (images);
			desc.AddInput (size);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var resized_images = new TFOutput (op, _idx++);
			return resized_images;
		}

		/// <summary>
		///   Resize `images` to `size` using bicubic interpolation.
		/// </summary>
		/// <param name="images">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   = A 1-D int32 Tensor of 2 elements: `new_height, new_width`.  The
		///   new size for the images.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeBicubic'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale input by (new_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of images and resized images. If false, rescale
		///   by new_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[batch, new_height, new_width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Input images can be of different types but output images are always float.
		/// </remarks>
		public TFOutput ResizeBicubic (TFOutput images, TFOutput size, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeBicubic", MakeName ("ResizeBicubic", operName));
			desc.AddInput (images);
			desc.AddInput (size);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var resized_images = new TFOutput (op, _idx++);
			return resized_images;
		}

		/// <summary>
		///   Resize `images` to `size` using bilinear interpolation.
		/// </summary>
		/// <param name="images">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   = A 1-D int32 Tensor of 2 elements: `new_height, new_width`.  The
		///   new size for the images.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeBilinear'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale input by (new_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of images and resized images. If false, rescale
		///   by new_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[batch, new_height, new_width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Input images can be of different types but output images are always float.
		/// </remarks>
		public TFOutput ResizeBilinear (TFOutput images, TFOutput size, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeBilinear", MakeName ("ResizeBilinear", operName));
			desc.AddInput (images);
			desc.AddInput (size);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var resized_images = new TFOutput (op, _idx++);
			return resized_images;
		}

		/// <summary>
		///   Computes the gradient of bilinear interpolation.
		/// </summary>
		/// <param name="grads">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="original_image">
		///   4-D with shape `[batch, orig_height, orig_width, channels]`,
		///   The image tensor that was resized.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeBilinearGrad'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale grads by (orig_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of grads and original_image. If false, rescale by
		///   orig_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, orig_height, orig_width, channels]`.
		///   Gradients with respect to the input image. Input image must have been
		///   float or double.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ResizeBilinearGrad (TFOutput grads, TFOutput original_image, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeBilinearGrad", MakeName ("ResizeBilinearGrad", operName));
			desc.AddInput (grads);
			desc.AddInput (original_image);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Resize `images` to `size` using nearest neighbor interpolation.
		/// </summary>
		/// <param name="images">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   = A 1-D int32 Tensor of 2 elements: `new_height, new_width`.  The
		///   new size for the images.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeNearestNeighbor'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale input by (new_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of images and resized images. If false, rescale
		///   by new_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape
		///   `[batch, new_height, new_width, channels]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ResizeNearestNeighbor (TFOutput images, TFOutput size, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeNearestNeighbor", MakeName ("ResizeNearestNeighbor", operName));
			desc.AddInput (images);
			desc.AddInput (size);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var resized_images = new TFOutput (op, _idx++);
			return resized_images;
		}

		/// <summary>
		///   Computes the gradient of nearest neighbor interpolation.
		/// </summary>
		/// <param name="grads">
		///   4-D with shape `[batch, height, width, channels]`.
		/// </param>
		/// <param name="size">
		///   = A 1-D int32 Tensor of 2 elements: `orig_height, orig_width`. The
		///   original input size.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResizeNearestNeighborGrad'.
		/// </param>
		/// <param name="align_corners">
		///   Optional argument
		///   If true, rescale grads by (orig_height - 1) / (height - 1), which
		///   exactly aligns the 4 corners of grads and original_image. If false, rescale by
		///   orig_height / height. Treat similarly the width dimension.
		/// </param>
		/// <returns>
		///   4-D with shape `[batch, orig_height, orig_width, channels]`. Gradients
		///   with respect to the input image.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ResizeNearestNeighborGrad (TFOutput grads, TFOutput size, bool? align_corners = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResizeNearestNeighborGrad", MakeName ("ResizeNearestNeighborGrad", operName));
			desc.AddInput (grads);
			desc.AddInput (size);
			if (align_corners.HasValue)
				desc.SetAttr ("align_corners", align_corners.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Update '*var' according to the adadelta scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum_update">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay factor. Must be a scalar.
		/// </param>
		/// <param name="epsilon">
		///   Constant factor. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyAdadelta'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var, accum and update_accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   accum = rho() * accum + (1 - rho()) * grad.square();
		///   update = (update_accum + epsilon).sqrt() * (accum + epsilon()).rsqrt() * grad;
		///   update_accum = rho() * update_accum + (1 - rho()) * update.square();
		///   var -= update;
		/// </remarks>
		public TFOperation ResourceApplyAdadelta (TFOutput var, TFOutput accum, TFOutput accum_update, TFOutput lr, TFOutput rho, TFOutput epsilon, TFOutput grad, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyAdadelta", MakeName ("ResourceApplyAdadelta", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (accum_update);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the adagrad scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyAdagrad'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   accum += grad * grad
		///   var -= lr * grad * (1 / sqrt(accum))
		/// </remarks>
		public TFOperation ResourceApplyAdagrad (TFOutput var, TFOutput accum, TFOutput lr, TFOutput grad, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyAdagrad", MakeName ("ResourceApplyAdagrad", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the proximal adagrad scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="gradient_accumulator">
		///   Should be from a Variable().
		/// </param>
		/// <param name="gradient_squared_accumulator">
		///   Should be from a Variable().
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="global_step">
		///   Training step number. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyAdagradDA'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var and accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation ResourceApplyAdagradDA (TFOutput var, TFOutput gradient_accumulator, TFOutput gradient_squared_accumulator, TFOutput grad, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput global_step, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyAdagradDA", MakeName ("ResourceApplyAdagradDA", operName));
			desc.AddInput (var);
			desc.AddInput (gradient_accumulator);
			desc.AddInput (gradient_squared_accumulator);
			desc.AddInput (grad);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (global_step);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the Adam algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="m">
		///   Should be from a Variable().
		/// </param>
		/// <param name="v">
		///   Should be from a Variable().
		/// </param>
		/// <param name="beta1_power">
		///   Must be a scalar.
		/// </param>
		/// <param name="beta2_power">
		///   Must be a scalar.
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="beta1">
		///   Momentum factor. Must be a scalar.
		/// </param>
		/// <param name="beta2">
		///   Momentum factor. Must be a scalar.
		/// </param>
		/// <param name="epsilon">
		///   Ridge term. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyAdam'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var, m, and v tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <param name="use_nesterov">
		///   Optional argument
		///   If `True`, uses the nesterov update.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   lr_t &amp;lt;- learning_rate * sqrt(1 - beta2^t) / (1 - beta1^t)
		///   m_t &amp;lt;- beta1 * m_{t-1} + (1 - beta1) * g_t
		///   v_t &amp;lt;- beta2 * v_{t-1} + (1 - beta2) * g_t * g_t
		///   variable &amp;lt;- variable - lr_t * m_t / (sqrt(v_t) + epsilon)
		/// </remarks>
		public TFOperation ResourceApplyAdam (TFOutput var, TFOutput m, TFOutput v, TFOutput beta1_power, TFOutput beta2_power, TFOutput lr, TFOutput beta1, TFOutput beta2, TFOutput epsilon, TFOutput grad, bool? use_locking = null, bool? use_nesterov = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyAdam", MakeName ("ResourceApplyAdam", operName));
			desc.AddInput (var);
			desc.AddInput (m);
			desc.AddInput (v);
			desc.AddInput (beta1_power);
			desc.AddInput (beta2_power);
			desc.AddInput (lr);
			desc.AddInput (beta1);
			desc.AddInput (beta2);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			if (use_nesterov.HasValue)
				desc.SetAttr ("use_nesterov", use_nesterov.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the centered RMSProp algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mg">
		///   Should be from a Variable().
		/// </param>
		/// <param name="ms">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mom">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay rate. Must be a scalar.
		/// </param>
		/// <param name="momentum">
		/// </param>
		/// <param name="epsilon">
		///   Ridge term. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyCenteredRMSProp'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var, mg, ms, and mom tensors is
		///   protected by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The centered RMSProp algorithm uses an estimate of the centered second moment
		///   (i.e., the variance) for normalization, as opposed to regular RMSProp, which
		///   uses the (uncentered) second moment. This often helps with training, but is
		///   slightly more expensive in terms of computation and memory.
		///   
		///   Note that in dense implementation of this algorithm, mg, ms, and mom will
		///   update even if the grad is zero, but in this sparse implementation, mg, ms,
		///   and mom will not update in iterations during which the grad is zero.
		///   
		///   mean_square = decay * mean_square + (1-decay) * gradient ** 2
		///   mean_grad = decay * mean_grad + (1-decay) * gradient
		///   
		///   Delta = learning_rate * gradient / sqrt(mean_square + epsilon - mean_grad ** 2)
		///   
		///   mg &amp;lt;- rho * mg_{t-1} + (1-rho) * grad
		///   ms &amp;lt;- rho * ms_{t-1} + (1-rho) * grad * grad
		///   mom &amp;lt;- momentum * mom_{t-1} + lr * grad / sqrt(ms - mg * mg + epsilon)
		///   var &amp;lt;- var - mom
		/// </remarks>
		public TFOperation ResourceApplyCenteredRMSProp (TFOutput var, TFOutput mg, TFOutput ms, TFOutput mom, TFOutput lr, TFOutput rho, TFOutput momentum, TFOutput epsilon, TFOutput grad, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyCenteredRMSProp", MakeName ("ResourceApplyCenteredRMSProp", operName));
			desc.AddInput (var);
			desc.AddInput (mg);
			desc.AddInput (ms);
			desc.AddInput (mom);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (momentum);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the Ftrl-proximal scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="linear">
		///   Should be from a Variable().
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regulariation. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regulariation. Must be a scalar.
		/// </param>
		/// <param name="lr_power">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyFtrl'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   accum_new = accum + grad * grad
		///   linear += grad + (accum_new^(-lr_power) - accum^(-lr_power)) / lr * var
		///   quadratic = 1.0 / (accum_new^(lr_power) * lr) + 2 * l2
		///   var = (sign(linear) * l1 - linear) / quadratic if |linear| &amp;gt; l1 else 0.0
		///   accum = accum_new
		/// </remarks>
		public TFOperation ResourceApplyFtrl (TFOutput var, TFOutput accum, TFOutput linear, TFOutput grad, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput lr_power, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyFtrl", MakeName ("ResourceApplyFtrl", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (linear);
			desc.AddInput (grad);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (lr_power);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' by subtracting 'alpha' * 'delta' from it.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="alpha">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="delta">
		///   The change.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyGradientDescent'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, the subtraction will be protected by a lock;
		///   otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation ResourceApplyGradientDescent (TFOutput var, TFOutput alpha, TFOutput delta, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyGradientDescent", MakeName ("ResourceApplyGradientDescent", operName));
			desc.AddInput (var);
			desc.AddInput (alpha);
			desc.AddInput (delta);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the momentum scheme. Set use_nesterov = True if you
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="momentum">
		///   Momentum. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyMomentum'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <param name="use_nesterov">
		///   Optional argument
		///   If `True`, the tensor passed to compute grad will be
		///   var - lr * momentum * accum, so in the end, the var you get is actually
		///   var - lr * momentum * accum.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   want to use Nesterov momentum.
		///   
		///   accum = accum * momentum + grad
		///   var -= lr * accum
		/// </remarks>
		public TFOperation ResourceApplyMomentum (TFOutput var, TFOutput accum, TFOutput lr, TFOutput grad, TFOutput momentum, bool? use_locking = null, bool? use_nesterov = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyMomentum", MakeName ("ResourceApplyMomentum", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (grad);
			desc.AddInput (momentum);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			if (use_nesterov.HasValue)
				desc.SetAttr ("use_nesterov", use_nesterov.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' and '*accum' according to FOBOS with Adagrad learning rate.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyProximalAdagrad'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var and accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   accum += grad * grad
		///   prox_v = var - lr * grad * (1 / sqrt(accum))
		///   var = sign(prox_v)/(1+lr*l2) * max{|prox_v|-lr*l1,0}
		/// </remarks>
		public TFOperation ResourceApplyProximalAdagrad (TFOutput var, TFOutput accum, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput grad, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyProximalAdagrad", MakeName ("ResourceApplyProximalAdagrad", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' as FOBOS algorithm with fixed learning rate.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="alpha">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="delta">
		///   The change.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyProximalGradientDescent'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, the subtraction will be protected by a lock;
		///   otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   prox_v = var - alpha * delta
		///   var = sign(prox_v)/(1+alpha*l2) * max{|prox_v|-alpha*l1,0}
		/// </remarks>
		public TFOperation ResourceApplyProximalGradientDescent (TFOutput var, TFOutput alpha, TFOutput l1, TFOutput l2, TFOutput delta, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyProximalGradientDescent", MakeName ("ResourceApplyProximalGradientDescent", operName));
			desc.AddInput (var);
			desc.AddInput (alpha);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (delta);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the RMSProp algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="ms">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mom">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay rate. Must be a scalar.
		/// </param>
		/// <param name="momentum">
		/// </param>
		/// <param name="epsilon">
		///   Ridge term. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceApplyRMSProp'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var, ms, and mom tensors is protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Note that in dense implementation of this algorithm, ms and mom will
		///   update even if the grad is zero, but in this sparse implementation, ms
		///   and mom will not update in iterations during which the grad is zero.
		///   
		///   mean_square = decay * mean_square + (1-decay) * gradient ** 2
		///   Delta = learning_rate * gradient / sqrt(mean_square + epsilon)
		///   
		///   ms &amp;lt;- rho * ms_{t-1} + (1-rho) * grad * grad
		///   mom &amp;lt;- momentum * mom_{t-1} + lr * grad / sqrt(ms + epsilon)
		///   var &amp;lt;- var - mom
		/// </remarks>
		public TFOperation ResourceApplyRMSProp (TFOutput var, TFOutput ms, TFOutput mom, TFOutput lr, TFOutput rho, TFOutput momentum, TFOutput epsilon, TFOutput grad, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceApplyRMSProp", MakeName ("ResourceApplyRMSProp", operName));
			desc.AddInput (var);
			desc.AddInput (ms);
			desc.AddInput (mom);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (momentum);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Gather slices from the variable pointed to by `resource` according to `indices`.
		/// </summary>
		/// <param name="resource">
		/// </param>
		/// <param name="indices">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceGather'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `indices` must be an integer tensor of any dimension (usually 0-D or 1-D).
		///   Produces an output tensor with shape `indices.shape + params.shape[1:]` where:
		///   
		///   ```python
		///       # Scalar indices
		///       output[:, ..., :] = params[indices, :, ... :]
		///   
		///       # Vector indices
		///       output[i, :, ..., :] = params[indices[i], :, ... :]
		///   
		///       # Higher rank indices
		///       output[i, ..., j, :, ... :] = params[indices[i, ..., j], :, ..., :]
		///   ```
		/// </remarks>
		public TFOutput ResourceGather (TFOutput resource, TFOutput indices, TFDataType dtype, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceGather", MakeName ("ResourceGather", operName));
			desc.AddInput (resource);
			desc.AddInput (indices);
			desc.SetAttrType ("dtype", dtype);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adds sparse updates to the variable referenced by `resource`.
		/// </summary>
		/// <param name="resource">
		///   Should be from a `Variable` node.
		/// </param>
		/// <param name="indices">
		///   A tensor of indices into the first dimension of `ref`.
		/// </param>
		/// <param name="updates">
		///   A tensor of updated values to add to `ref`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceScatterAdd'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This operation computes
		///   
		///       # Scalar indices
		///       ref[indices, ...] += updates[...]
		///   
		///       # Vector indices (for each i)
		///       ref[indices[i], ...] += updates[i, ...]
		///   
		///       # High rank indices (for each i, ..., j)
		///       ref[indices[i, ..., j], ...] += updates[i, ..., j, ...]
		///   
		///   Duplicate entries are handled correctly: if multiple `indices` reference
		///   the same location, their contributions add.
		///   
		///   Requires `updates.shape = indices.shape + ref.shape[1:]`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/ScatterAdd.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOperation ResourceScatterAdd (TFOutput resource, TFOutput indices, TFOutput updates, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceScatterAdd", MakeName ("ResourceScatterAdd", operName));
			desc.AddInput (resource);
			desc.AddInput (indices);
			desc.AddInput (updates);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   var: Should be from a Variable().
		/// </summary>
		/// <param name="var">
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum_update">
		///   : Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Learning rate. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay factor. Must be a scalar.
		/// </param>
		/// <param name="epsilon">
		///   Constant factor. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyAdadelta'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var and accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation ResourceSparseApplyAdadelta (TFOutput var, TFOutput accum, TFOutput accum_update, TFOutput lr, TFOutput rho, TFOutput epsilon, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyAdadelta", MakeName ("ResourceSparseApplyAdadelta", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (accum_update);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update relevant entries in '*var' and '*accum' according to the adagrad scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Learning rate. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyAdagrad'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   That is for rows we have grad for, we update var and accum as follows:
		///   accum += grad * grad
		///   var -= lr * grad * (1 / sqrt(accum))
		/// </remarks>
		public TFOperation ResourceSparseApplyAdagrad (TFOutput var, TFOutput accum, TFOutput lr, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyAdagrad", MakeName ("ResourceSparseApplyAdagrad", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update entries in '*var' and '*accum' according to the proximal adagrad scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="gradient_accumulator">
		///   Should be from a Variable().
		/// </param>
		/// <param name="gradient_squared_accumulator">
		///   Should be from a Variable().
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="lr">
		///   Learning rate. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="global_step">
		///   Training step number. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyAdagradDA'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var and accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation ResourceSparseApplyAdagradDA (TFOutput var, TFOutput gradient_accumulator, TFOutput gradient_squared_accumulator, TFOutput grad, TFOutput indices, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput global_step, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyAdagradDA", MakeName ("ResourceSparseApplyAdagradDA", operName));
			desc.AddInput (var);
			desc.AddInput (gradient_accumulator);
			desc.AddInput (gradient_squared_accumulator);
			desc.AddInput (grad);
			desc.AddInput (indices);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (global_step);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the centered RMSProp algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mg">
		///   Should be from a Variable().
		/// </param>
		/// <param name="ms">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mom">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay rate. Must be a scalar.
		/// </param>
		/// <param name="momentum">
		/// </param>
		/// <param name="epsilon">
		///   Ridge term. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var, ms and mom.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyCenteredRMSProp'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var, mg, ms, and mom tensors is
		///   protected by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The centered RMSProp algorithm uses an estimate of the centered second moment
		///   (i.e., the variance) for normalization, as opposed to regular RMSProp, which
		///   uses the (uncentered) second moment. This often helps with training, but is
		///   slightly more expensive in terms of computation and memory.
		///   
		///   Note that in dense implementation of this algorithm, mg, ms, and mom will
		///   update even if the grad is zero, but in this sparse implementation, mg, ms,
		///   and mom will not update in iterations during which the grad is zero.
		///   
		///   mean_square = decay * mean_square + (1-decay) * gradient ** 2
		///   mean_grad = decay * mean_grad + (1-decay) * gradient
		///   Delta = learning_rate * gradient / sqrt(mean_square + epsilon - mean_grad ** 2)
		///   
		///   ms &amp;lt;- rho * ms_{t-1} + (1-rho) * grad * grad
		///   mom &amp;lt;- momentum * mom_{t-1} + lr * grad / sqrt(ms + epsilon)
		///   var &amp;lt;- var - mom
		/// </remarks>
		public TFOperation ResourceSparseApplyCenteredRMSProp (TFOutput var, TFOutput mg, TFOutput ms, TFOutput mom, TFOutput lr, TFOutput rho, TFOutput momentum, TFOutput epsilon, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyCenteredRMSProp", MakeName ("ResourceSparseApplyCenteredRMSProp", operName));
			desc.AddInput (var);
			desc.AddInput (mg);
			desc.AddInput (ms);
			desc.AddInput (mom);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (momentum);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update relevant entries in '*var' according to the Ftrl-proximal scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="linear">
		///   Should be from a Variable().
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="lr_power">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyFtrl'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   That is for rows we have grad for, we update var, accum and linear as follows:
		///   accum_new = accum + grad * grad
		///   linear += grad + (accum_new^(-lr_power) - accum^(-lr_power)) / lr * var
		///   quadratic = 1.0 / (accum_new^(lr_power) * lr) + 2 * l2
		///   var = (sign(linear) * l1 - linear) / quadratic if |linear| &amp;gt; l1 else 0.0
		///   accum = accum_new
		/// </remarks>
		public TFOperation ResourceSparseApplyFtrl (TFOutput var, TFOutput accum, TFOutput linear, TFOutput grad, TFOutput indices, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput lr_power, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyFtrl", MakeName ("ResourceSparseApplyFtrl", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (linear);
			desc.AddInput (grad);
			desc.AddInput (indices);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (lr_power);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update relevant entries in '*var' and '*accum' according to the momentum scheme.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Learning rate. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="momentum">
		///   Momentum. Must be a scalar.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyMomentum'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var and accum tensors will be protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <param name="use_nesterov">
		///   Optional argument
		///   If `True`, the tensor passed to compute grad will be
		///   var - lr * momentum * accum, so in the end, the var you get is actually
		///   var - lr * momentum * accum.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Set use_nesterov = True if you want to use Nesterov momentum.
		///   
		///   That is for rows we have grad for, we update var and accum as follows:
		///   
		///   accum = accum * momentum + grad
		///   var -= lr * accum
		/// </remarks>
		public TFOperation ResourceSparseApplyMomentum (TFOutput var, TFOutput accum, TFOutput lr, TFOutput grad, TFOutput indices, TFOutput momentum, bool? use_locking = null, bool? use_nesterov = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyMomentum", MakeName ("ResourceSparseApplyMomentum", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (grad);
			desc.AddInput (indices);
			desc.AddInput (momentum);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			if (use_nesterov.HasValue)
				desc.SetAttr ("use_nesterov", use_nesterov.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Sparse update entries in '*var' and '*accum' according to FOBOS algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="accum">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Learning rate. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyProximalAdagrad'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, updating of the var and accum tensors will be protected by
		///   a lock; otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   That is for rows we have grad for, we update var and accum as follows:
		///   accum += grad * grad
		///   prox_v = var
		///   prox_v -= lr * grad * (1 / sqrt(accum))
		///   var = sign(prox_v)/(1+lr*l2) * max{|prox_v|-lr*l1,0}
		/// </remarks>
		public TFOperation ResourceSparseApplyProximalAdagrad (TFOutput var, TFOutput accum, TFOutput lr, TFOutput l1, TFOutput l2, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyProximalAdagrad", MakeName ("ResourceSparseApplyProximalAdagrad", operName));
			desc.AddInput (var);
			desc.AddInput (accum);
			desc.AddInput (lr);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Sparse update '*var' as FOBOS algorithm with fixed learning rate.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="alpha">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="l1">
		///   L1 regularization. Must be a scalar.
		/// </param>
		/// <param name="l2">
		///   L2 regularization. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var and accum.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyProximalGradientDescent'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If True, the subtraction will be protected by a lock;
		///   otherwise the behavior is undefined, but may exhibit less contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   That is for rows we have grad for, we update var as follows:
		///   prox_v = var - alpha * grad
		///   var = sign(prox_v)/(1+alpha*l2) * max{|prox_v|-alpha*l1,0}
		/// </remarks>
		public TFOperation ResourceSparseApplyProximalGradientDescent (TFOutput var, TFOutput alpha, TFOutput l1, TFOutput l2, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyProximalGradientDescent", MakeName ("ResourceSparseApplyProximalGradientDescent", operName));
			desc.AddInput (var);
			desc.AddInput (alpha);
			desc.AddInput (l1);
			desc.AddInput (l2);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Update '*var' according to the RMSProp algorithm.
		/// </summary>
		/// <param name="var">
		///   Should be from a Variable().
		/// </param>
		/// <param name="ms">
		///   Should be from a Variable().
		/// </param>
		/// <param name="mom">
		///   Should be from a Variable().
		/// </param>
		/// <param name="lr">
		///   Scaling factor. Must be a scalar.
		/// </param>
		/// <param name="rho">
		///   Decay rate. Must be a scalar.
		/// </param>
		/// <param name="momentum">
		/// </param>
		/// <param name="epsilon">
		///   Ridge term. Must be a scalar.
		/// </param>
		/// <param name="grad">
		///   The gradient.
		/// </param>
		/// <param name="indices">
		///   A vector of indices into the first dimension of var, ms and mom.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceSparseApplyRMSProp'.
		/// </param>
		/// <param name="use_locking">
		///   Optional argument
		///   If `True`, updating of the var, ms, and mom tensors is protected
		///   by a lock; otherwise the behavior is undefined, but may exhibit less
		///   contention.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   Note that in dense implementation of this algorithm, ms and mom will
		///   update even if the grad is zero, but in this sparse implementation, ms
		///   and mom will not update in iterations during which the grad is zero.
		///   
		///   mean_square = decay * mean_square + (1-decay) * gradient ** 2
		///   Delta = learning_rate * gradient / sqrt(mean_square + epsilon)
		///   
		///   ms &amp;lt;- rho * ms_{t-1} + (1-rho) * grad * grad
		///   mom &amp;lt;- momentum * mom_{t-1} + lr * grad / sqrt(ms + epsilon)
		///   var &amp;lt;- var - mom
		/// </remarks>
		public TFOperation ResourceSparseApplyRMSProp (TFOutput var, TFOutput ms, TFOutput mom, TFOutput lr, TFOutput rho, TFOutput momentum, TFOutput epsilon, TFOutput grad, TFOutput indices, bool? use_locking = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceSparseApplyRMSProp", MakeName ("ResourceSparseApplyRMSProp", operName));
			desc.AddInput (var);
			desc.AddInput (ms);
			desc.AddInput (mom);
			desc.AddInput (lr);
			desc.AddInput (rho);
			desc.AddInput (momentum);
			desc.AddInput (epsilon);
			desc.AddInput (grad);
			desc.AddInput (indices);
			if (use_locking.HasValue)
				desc.SetAttr ("use_locking", use_locking.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Assign `value` to the sliced l-value reference of `ref`.
		/// </summary>
		/// <param name="reference">
		/// </param>
		/// <param name="begin">
		/// </param>
		/// <param name="end">
		/// </param>
		/// <param name="strides">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ResourceStridedSliceAssign'.
		/// </param>
		/// <param name="begin_mask">
		///   Optional argument
		/// </param>
		/// <param name="end_mask">
		///   Optional argument
		/// </param>
		/// <param name="ellipsis_mask">
		///   Optional argument
		/// </param>
		/// <param name="new_axis_mask">
		///   Optional argument
		/// </param>
		/// <param name="shrink_axis_mask">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The values of `value` are assigned to the positions in the variable
		///   `ref` that are selected by the slice parameters. The slice parameters
		///   `begin, `end`, `strides`, etc. work exactly as in `StridedSlice`.
		///   
		///   NOTE this op currently does not support broadcasting and so `value`'s
		///   shape must be exactly the shape produced by the slice of `ref`.
		/// </remarks>
		public TFOperation ResourceStridedSliceAssign (TFOutput reference, TFOutput begin, TFOutput end, TFOutput strides, TFOutput value, long? begin_mask = null, long? end_mask = null, long? ellipsis_mask = null, long? new_axis_mask = null, long? shrink_axis_mask = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ResourceStridedSliceAssign", MakeName ("ResourceStridedSliceAssign", operName));
			desc.AddInput (reference);
			desc.AddInput (begin);
			desc.AddInput (end);
			desc.AddInput (strides);
			desc.AddInput (value);
			if (begin_mask.HasValue)
				desc.SetAttr ("begin_mask", begin_mask.Value);
			
			if (end_mask.HasValue)
				desc.SetAttr ("end_mask", end_mask.Value);
			
			if (ellipsis_mask.HasValue)
				desc.SetAttr ("ellipsis_mask", ellipsis_mask.Value);
			
			if (new_axis_mask.HasValue)
				desc.SetAttr ("new_axis_mask", new_axis_mask.Value);
			
			if (shrink_axis_mask.HasValue)
				desc.SetAttr ("shrink_axis_mask", shrink_axis_mask.Value);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Restores a tensor from checkpoint files.
		/// </summary>
		/// <param name="file_pattern">
		///   Must have a single element. The pattern of the files from
		///   which we read the tensor.
		/// </param>
		/// <param name="tensor_name">
		///   Must have a single element. The name of the tensor to be
		///   restored.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Restore'.
		/// </param>
		/// <param name="preferred_shard">
		///   Optional argument
		///   Index of file to open first if multiple files match
		///   `file_pattern`.
		/// </param>
		/// <param name="dt">
		///   The type of the tensor to be restored.
		/// </param>
		/// <returns>
		///   The restored tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reads a tensor stored in one or several files. If there are several files (for
		///   instance because a tensor was saved as slices), `file_pattern` may contain
		///   wildcard symbols (`*` and `?`) in the filename portion only, not in the
		///   directory portion.
		///   
		///   If a `file_pattern` matches several files, `preferred_shard` can be used to hint
		///   in which file the requested tensor is likely to be found. This op will first
		///   open the file at index `preferred_shard` in the list of matching files and try
		///   to restore tensors from that file.  Only if some tensors or tensor slices are
		///   not found in that first file, then the Op opens all the files. Setting
		///   `preferred_shard` to match the value passed as the `shard` input
		///   of a matching `Save` Op may speed up Restore.  This attribute only affects
		///   performance, not correctness.  The default value -1 means files are processed in
		///   order.
		///   
		///   See also `RestoreSlice`.
		/// </remarks>
		public TFOutput Restore (TFOutput file_pattern, TFOutput tensor_name, TFDataType dt, long? preferred_shard = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Restore", MakeName ("Restore", operName));
			desc.AddInput (file_pattern);
			desc.AddInput (tensor_name);
			desc.SetAttrType ("dt", dt);
			if (preferred_shard.HasValue)
				desc.SetAttr ("preferred_shard", preferred_shard.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var tensor = new TFOutput (op, _idx++);
			return tensor;
		}

		/// <summary>
		///   Restores a tensor from checkpoint files.
		/// </summary>
		/// <param name="file_pattern">
		///   Must have a single element. The pattern of the files from
		///   which we read the tensor.
		/// </param>
		/// <param name="tensor_name">
		///   Must have a single element. The name of the tensor to be
		///   restored.
		/// </param>
		/// <param name="shape_and_slice">
		///   Scalar. The shapes and slice specifications to use when
		///   restoring a tensors.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RestoreSlice'.
		/// </param>
		/// <param name="preferred_shard">
		///   Optional argument
		///   Index of file to open first if multiple files match
		///   `file_pattern`. See the documentation for `Restore`.
		/// </param>
		/// <param name="dt">
		///   The type of the tensor to be restored.
		/// </param>
		/// <returns>
		///   The restored tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is like `Restore` except that restored tensor can be listed as filling
		///   only a slice of a larger tensor.  `shape_and_slice` specifies the shape of the
		///   larger tensor and the slice that the restored tensor covers.
		///   
		///   The `shape_and_slice` input has the same format as the
		///   elements of the `shapes_and_slices` input of the `SaveSlices` op.
		/// </remarks>
		public TFOutput RestoreSlice (TFOutput file_pattern, TFOutput tensor_name, TFOutput shape_and_slice, TFDataType dt, long? preferred_shard = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RestoreSlice", MakeName ("RestoreSlice", operName));
			desc.AddInput (file_pattern);
			desc.AddInput (tensor_name);
			desc.AddInput (shape_and_slice);
			desc.SetAttrType ("dt", dt);
			if (preferred_shard.HasValue)
				desc.SetAttr ("preferred_shard", preferred_shard.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var tensor = new TFOutput (op, _idx++);
			return tensor;
		}

		/// <summary>
		///   Restores tensors from a V2 checkpoint.
		/// </summary>
		/// <param name="prefix">
		///   Must have a single element.  The prefix of a V2 checkpoint.
		/// </param>
		/// <param name="tensor_names">
		///   shape {N}.  The names of the tensors to be restored.
		/// </param>
		/// <param name="shape_and_slices">
		///   shape {N}.  The slice specs of the tensors to be restored.
		///   Empty strings indicate that they are non-partitioned tensors.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RestoreV2'.
		/// </param>
		/// <param name="dtypes">
		///   shape {N}.  The list of expected dtype for the tensors.  Must match
		///   those stored in the checkpoint.
		/// </param>
		/// <returns>
		///   shape {N}.  The restored tensors, whose shapes are read from the
		///   checkpoint directly.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For backward compatibility with the V1 format, this Op currently allows
		///   restoring from a V1 checkpoint as well:
		///     - This Op first attempts to find the V2 index file pointed to by "prefix", and
		///       if found proceed to read it as a V2 checkpoint;
		///     - Otherwise the V1 read path is invoked.
		///   Relying on this behavior is not recommended, as the ability to fall back to read
		///   V1 might be deprecated and eventually removed.
		///   
		///   By default, restores the named tensors in full.  If the caller wishes to restore
		///   specific slices of stored tensors, "shape_and_slices" should be non-empty
		///   strings and correspondingly well-formed.
		///   
		///   Callers must ensure all the named tensors are indeed stored in the checkpoint.
		/// </remarks>
		public TFOutput[] RestoreV2 (TFOutput prefix, TFOutput tensor_names, TFOutput shape_and_slices, TFDataType[] dtypes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RestoreV2", MakeName ("RestoreV2", operName));
			desc.AddInput (prefix);
			desc.AddInput (tensor_names);
			desc.AddInput (shape_and_slices);
			desc.SetAttrType ("dtypes", dtypes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("tensors");
			var tensors = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				tensors [i] = new TFOutput (op, _idx++);
			
			return tensors;
		}

		/// <summary>
		///   Reverses specific dimensions of a tensor.
		/// </summary>
		/// <param name="tensor">
		///   Up to 8-D.
		/// </param>
		/// <param name="dims">
		///   1-D. The dimensions to reverse.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Reverse'.
		/// </param>
		/// <returns>
		///   The same shape as `tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a `tensor`, and a `bool` tensor `dims` representing the dimensions
		///   of `tensor`, this operation reverses each dimension i of `tensor` where
		///   `dims[i]` is `True`.
		///   
		///   `tensor` can have up to 8 dimensions. The number of dimensions
		///   of `tensor` must equal the number of elements in `dims`. In other words:
		///   
		///   `rank(tensor) = size(dims)`
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 't' is [[[[ 0,  1,  2,  3],
		///   #                  [ 4,  5,  6,  7],
		///   #                  [ 8,  9, 10, 11]],
		///   #                 [[12, 13, 14, 15],
		///   #                  [16, 17, 18, 19],
		///   #                  [20, 21, 22, 23]]]]
		///   # tensor 't' shape is [1, 2, 3, 4]
		///   
		///   # 'dims' is [False, False, False, True]
		///   reverse(t, dims) ==&amp;gt; [[[[ 3,  2,  1,  0],
		///                           [ 7,  6,  5,  4],
		///                           [ 11, 10, 9, 8]],
		///                          [[15, 14, 13, 12],
		///                           [19, 18, 17, 16],
		///                           [23, 22, 21, 20]]]]
		///   
		///   # 'dims' is [False, True, False, False]
		///   reverse(t, dims) ==&amp;gt; [[[[12, 13, 14, 15],
		///                           [16, 17, 18, 19],
		///                           [20, 21, 22, 23]
		///                          [[ 0,  1,  2,  3],
		///                           [ 4,  5,  6,  7],
		///                           [ 8,  9, 10, 11]]]]
		///   
		///   # 'dims' is [False, False, True, False]
		///   reverse(t, dims) ==&amp;gt; [[[[8, 9, 10, 11],
		///                           [4, 5, 6, 7],
		///                           [0, 1, 2, 3]]
		///                          [[20, 21, 22, 23],
		///                           [16, 17, 18, 19],
		///                           [12, 13, 14, 15]]]]
		///   ```
		/// </remarks>
		public TFOutput Reverse (TFOutput tensor, TFOutput dims, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Reverse", MakeName ("Reverse", operName));
			desc.AddInput (tensor);
			desc.AddInput (dims);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Reverses variable length slices.
		/// </summary>
		/// <param name="input">
		///   The input to reverse.
		/// </param>
		/// <param name="seq_lengths">
		///   1-D with length `input.dims(batch_dim)` and
		///   `max(seq_lengths) &amp;lt;= input.dims(seq_dim)`
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReverseSequence'.
		/// </param>
		/// <param name="batch_dim">
		///   Optional argument
		///   The dimension along which reversal is performed.
		/// </param>
		/// <param name="seq_dim">
		///   The dimension which is partially reversed.
		/// </param>
		/// <returns>
		///   The partially reversed input. It has the same shape as `input`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This op first slices `input` along the dimension `batch_dim`, and for each
		///   slice `i`, reverses the first `seq_lengths[i]` elements along
		///   the dimension `seq_dim`.
		///   
		///   The elements of `seq_lengths` must obey `seq_lengths[i] &amp;lt;= input.dims[seq_dim]`,
		///   and `seq_lengths` must be a vector of length `input.dims[batch_dim]`.
		///   
		///   The output slice `i` along dimension `batch_dim` is then given by input
		///   slice `i`, with the first `seq_lengths[i]` slices along dimension
		///   `seq_dim` reversed.
		///   
		///   For example:
		///   
		///   ```
		///   # Given this:
		///   batch_dim = 0
		///   seq_dim = 1
		///   input.dims = (4, 8, ...)
		///   seq_lengths = [7, 2, 3, 5]
		///   
		///   # then slices of input are reversed on seq_dim, but only up to seq_lengths:
		///   output[0, 0:7, :, ...] = input[0, 7:0:-1, :, ...]
		///   output[1, 0:2, :, ...] = input[1, 2:0:-1, :, ...]
		///   output[2, 0:3, :, ...] = input[2, 3:0:-1, :, ...]
		///   output[3, 0:5, :, ...] = input[3, 5:0:-1, :, ...]
		///   
		///   # while entries past seq_lens are copied through:
		///   output[0, 7:, :, ...] = input[0, 7:, :, ...]
		///   output[1, 2:, :, ...] = input[1, 2:, :, ...]
		///   output[2, 3:, :, ...] = input[2, 3:, :, ...]
		///   output[3, 2:, :, ...] = input[3, 2:, :, ...]
		///   ```
		///   
		///   In contrast, if:
		///   
		///   ```
		///   # Given this:
		///   batch_dim = 2
		///   seq_dim = 0
		///   input.dims = (8, ?, 4, ...)
		///   seq_lengths = [7, 2, 3, 5]
		///   
		///   # then slices of input are reversed on seq_dim, but only up to seq_lengths:
		///   output[0:7, :, 0, :, ...] = input[7:0:-1, :, 0, :, ...]
		///   output[0:2, :, 1, :, ...] = input[2:0:-1, :, 1, :, ...]
		///   output[0:3, :, 2, :, ...] = input[3:0:-1, :, 2, :, ...]
		///   output[0:5, :, 3, :, ...] = input[5:0:-1, :, 3, :, ...]
		///   
		///   # while entries past seq_lens are copied through:
		///   output[7:, :, 0, :, ...] = input[7:, :, 0, :, ...]
		///   output[2:, :, 1, :, ...] = input[2:, :, 1, :, ...]
		///   output[3:, :, 2, :, ...] = input[3:, :, 2, :, ...]
		///   output[2:, :, 3, :, ...] = input[2:, :, 3, :, ...]
		///   ```
		/// </remarks>
		public TFOutput ReverseSequence (TFOutput input, TFOutput seq_lengths, long seq_dim, long? batch_dim = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReverseSequence", MakeName ("ReverseSequence", operName));
			desc.AddInput (input);
			desc.AddInput (seq_lengths);
			desc.SetAttr ("seq_dim", seq_dim);
			if (batch_dim.HasValue)
				desc.SetAttr ("batch_dim", batch_dim.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Reverses specific dimensions of a tensor.
		/// </summary>
		/// <param name="tensor">
		///   Up to 8-D.
		/// </param>
		/// <param name="axis">
		///   1-D. The indices of the dimensions to reverse.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ReverseV2'.
		/// </param>
		/// <returns>
		///   The same shape as `tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   NOTE `tf.reverse` has now changed behavior in preparation for 1.0.
		///   `tf.reverse_v2` is currently an alias that will be deprecated before TF 1.0.
		///   
		///   Given a `tensor`, and a `int32` tensor `axis` representing the set of
		///   dimensions of `tensor` to reverse. This operation reverses each dimension
		///   `i` for which there exists `j` s.t. `axis[j] == i`.
		///   
		///   `tensor` can have up to 8 dimensions. The number of dimensions specified
		///   in `axis` may be 0 or more entries. If an index is specified more than
		///   once, a InvalidArgument error is raised.
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 't' is [[[[ 0,  1,  2,  3],
		///   #                  [ 4,  5,  6,  7],
		///   #                  [ 8,  9, 10, 11]],
		///   #                 [[12, 13, 14, 15],
		///   #                  [16, 17, 18, 19],
		///   #                  [20, 21, 22, 23]]]]
		///   # tensor 't' shape is [1, 2, 3, 4]
		///   
		///   # 'dims' is [3] or 'dims' is -1
		///   reverse(t, dims) ==&amp;gt; [[[[ 3,  2,  1,  0],
		///                           [ 7,  6,  5,  4],
		///                           [ 11, 10, 9, 8]],
		///                          [[15, 14, 13, 12],
		///                           [19, 18, 17, 16],
		///                           [23, 22, 21, 20]]]]
		///   
		///   # 'dims' is '[1]' (or 'dims' is '[-3]')
		///   reverse(t, dims) ==&amp;gt; [[[[12, 13, 14, 15],
		///                           [16, 17, 18, 19],
		///                           [20, 21, 22, 23]
		///                          [[ 0,  1,  2,  3],
		///                           [ 4,  5,  6,  7],
		///                           [ 8,  9, 10, 11]]]]
		///   
		///   # 'dims' is '[2]' (or 'dims' is '[-2]')
		///   reverse(t, dims) ==&amp;gt; [[[[8, 9, 10, 11],
		///                           [4, 5, 6, 7],
		///                           [0, 1, 2, 3]]
		///                          [[20, 21, 22, 23],
		///                           [16, 17, 18, 19],
		///                           [12, 13, 14, 15]]]]
		///   ```
		/// </remarks>
		public TFOutput ReverseV2 (TFOutput tensor, TFOutput axis, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ReverseV2", MakeName ("ReverseV2", operName));
			desc.AddInput (tensor);
			desc.AddInput (axis);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A float32 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [1]. The FFT length.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RFFT'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same rank as `input`. The inner-most
		///     dimension of `input` is replaced with the `fft_length / 2 + 1` unique
		///     frequency components of its 1D Fourier transform.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.rfft
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 1-dimensional discrete Fourier transform of a real-valued signal
		///   over the inner-most dimension of `input`.
		///   
		///   Since the DFT of a real signal is Hermitian-symmetric, `RFFT` only returns the
		///   `fft_length / 2 + 1` unique components of the FFT: the zero-frequency term,
		///   followed by the `fft_length / 2` positive-frequency terms.
		/// </remarks>
		public TFOutput RFFT (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RFFT", MakeName ("RFFT", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   2D real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A float32 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [2]. The FFT length for each dimension.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RFFT2D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same rank as `input`. The inner-most 2
		///     dimensions of `input` are replaced with their 2D Fourier transform. The
		///     inner-most dimension contains `fft_length / 2 + 1` unique frequency
		///     components.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.rfft2
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 2-dimensional discrete Fourier transform of a real-valued signal
		///   over the inner-most 2 dimensions of `input`.
		///   
		///   Since the DFT of a real signal is Hermitian-symmetric, `RFFT2D` only returns the
		///   `fft_length / 2 + 1` unique components of the FFT for the inner-most dimension
		///   of `output`: the zero-frequency term, followed by the `fft_length / 2`
		///   positive-frequency terms.
		/// </remarks>
		public TFOutput RFFT2D (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RFFT2D", MakeName ("RFFT2D", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   3D real-valued fast Fourier transform.
		/// </summary>
		/// <param name="input">
		///   A float32 tensor.
		/// </param>
		/// <param name="fft_length">
		///   An int32 tensor of shape [3]. The FFT length for each dimension.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RFFT3D'.
		/// </param>
		/// <returns>
		///   A complex64 tensor of the same rank as `input`. The inner-most 3
		///     dimensions of `input` are replaced with the their 3D Fourier transform. The
		///     inner-most dimension contains `fft_length / 2 + 1` unique frequency
		///     components.
		///   
		///   @compatibility(numpy)
		///   Equivalent to np.fft.rfftn with 3 dimensions.
		///   @end_compatibility
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Computes the 3-dimensional discrete Fourier transform of a real-valued signal
		///   over the inner-most 3 dimensions of `input`.
		///   
		///   Since the DFT of a real signal is Hermitian-symmetric, `RFFT3D` only returns the
		///   `fft_length / 2 + 1` unique components of the FFT for the inner-most dimension
		///   of `output`: the zero-frequency term, followed by the `fft_length / 2`
		///   positive-frequency terms.
		/// </remarks>
		public TFOutput RFFT3D (TFOutput input, TFOutput fft_length, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RFFT3D", MakeName ("RFFT3D", operName));
			desc.AddInput (input);
			desc.AddInput (fft_length);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Converts one or more images from RGB to HSV.
		/// </summary>
		/// <param name="images">
		///   1-D or higher rank. RGB data to convert. Last dimension must be size 3.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RGBToHSV'.
		/// </param>
		/// <returns>
		///   `images` converted to HSV.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Outputs a tensor of the same shape as the `images` tensor, containing the HSV
		///   value of the pixels. The output is only well defined if the value in `images`
		///   are in `[0,1]`.
		///   
		///   `output[..., 0]` contains hue, `output[..., 1]` contains saturation, and
		///   `output[..., 2]` contains value. All HSV values are in `[0,1]`. A hue of 0
		///   corresponds to pure red, hue 1/3 is pure green, and 2/3 is pure blue.
		/// </remarks>
		public TFOutput RGBToHSV (TFOutput images, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RGBToHSV", MakeName ("RGBToHSV", operName));
			desc.AddInput (images);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns element-wise integer closest to x.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Rint'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   If the result is midway between two representable values,
		///   the even representable is chosen.
		///   For example:
		///   
		///   ```
		///   rint(-1.5) ==&amp;gt; -2.0
		///   rint(0.5000001) ==&amp;gt; 1.0
		///   rint([-1.7, -1.5, -0.2, 0.2, 1.5, 1.7, 2.0]) ==&amp;gt; [-2., -2., -0., 0., 2., 2., 2.]
		///   ```
		/// </remarks>
		public TFOutput Rint (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Rint", MakeName ("Rint", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Rounds the values of a tensor to the nearest integer, element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Round'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Rounds half to even.  Also known as bankers rounding. If you want to round
		///   according to the current system rounding mode use std::cint.
		/// </remarks>
		public TFOutput Round (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Round", MakeName ("Round", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes reciprocal of square root of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Rsqrt'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = 1 / \sqrt{x}\\).
		/// </remarks>
		public TFOutput Rsqrt (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Rsqrt", MakeName ("Rsqrt", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient for the rsqrt of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'RsqrtGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = dy * -0.5 * y^3`, where `y = rsqrt(x)`, and `dy`
		///   is the corresponding input gradient.
		/// </remarks>
		public TFOutput RsqrtGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "RsqrtGrad", MakeName ("RsqrtGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Generate a single randomly distorted bounding box for an image.
		/// </summary>
		/// <param name="image_size">
		///   1-D, containing `[height, width, channels]`.
		/// </param>
		/// <param name="bounding_boxes">
		///   3-D with shape `[batch, N, 4]` describing the N bounding boxes
		///   associated with the image.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SampleDistortedBoundingBox'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to non-zero, the random number
		///   generator is seeded by the given `seed`.  Otherwise, it is seeded by a random
		///   seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <param name="min_object_covered">
		///   Optional argument
		///   The cropped area of the image must contain at least this
		///   fraction of any bounding box supplied. The value of this parameter should be
		///   non-negative. In the case of 0, the cropped area does not need to overlap
		///   any of the bounding boxes supplied.
		/// </param>
		/// <param name="aspect_ratio_range">
		///   Optional argument
		///   The cropped area of the image must have an aspect ratio =
		///   width / height within this range.
		/// </param>
		/// <param name="area_range">
		///   Optional argument
		///   The cropped area of the image must contain a fraction of the
		///   supplied image within in this range.
		/// </param>
		/// <param name="max_attempts">
		///   Optional argument
		///   Number of attempts at generating a cropped region of the image
		///   of the specified constraints. After `max_attempts` failures, return the entire
		///   image.
		/// </param>
		/// <param name="use_image_if_no_bounding_boxes">
		///   Optional argument
		///   Controls behavior if no bounding boxes supplied.
		///   If true, assume an implicit bounding box covering the whole input. If false,
		///   raise an error.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   begin: 1-D, containing `[offset_height, offset_width, 0]`. Provide as input to
		///   `tf.slice`.
		///   size: 1-D, containing `[target_height, target_width, -1]`. Provide as input to
		///   `tf.slice`.
		///   bboxes: 3-D with shape `[1, 1, 4]` containing the distorted bounding box.
		///   Provide as input to `tf.image.draw_bounding_boxes`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Bounding box annotations are often supplied in addition to ground-truth labels
		///   in image recognition or object localization tasks. A common technique for
		///   training such a system is to randomly distort an image while preserving
		///   its content, i.e. *data augmentation*. This Op outputs a randomly distorted
		///   localization of an object, i.e. bounding box, given an `image_size`,
		///   `bounding_boxes` and a series of constraints.
		///   
		///   The output of this Op is a single bounding box that may be used to crop the
		///   original image. The output is returned as 3 tensors: `begin`, `size` and
		///   `bboxes`. The first 2 tensors can be fed directly into `tf.slice` to crop the
		///   image. The latter may be supplied to `tf.image.draw_bounding_boxes` to visualize
		///   what the bounding box looks like.
		///   
		///   Bounding boxes are supplied and returned as `[y_min, x_min, y_max, x_max]`. The
		///   bounding box coordinates are floats in `[0.0, 1.0]` relative to the width and
		///   height of the underlying image.
		///   
		///   For example,
		///   
		///   ```python
		///       # Generate a single distorted bounding box.
		///       begin, size, bbox_for_draw = tf.image.sample_distorted_bounding_box(
		///           tf.shape(image),
		///           bounding_boxes=bounding_boxes)
		///   
		///       # Draw the bounding box in an image summary.
		///       image_with_box = tf.image.draw_bounding_boxes(tf.expand_dims(image, 0),
		///                                                     bbox_for_draw)
		///       tf.image_summary('images_with_box', image_with_box)
		///   
		///       # Employ the bounding box to distort the image.
		///       distorted_image = tf.slice(image, begin, size)
		///   ```
		///   
		///   Note that if no bounding box information is available, setting
		///   `use_image_if_no_bounding_boxes = true` will assume there is a single implicit
		///   bounding box covering the whole image. If `use_image_if_no_bounding_boxes` is
		///   false and no bounding boxes are supplied, an error is raised.
		/// </remarks>
		public (TFOutput begin, TFOutput size, TFOutput bboxes) SampleDistortedBoundingBox (TFOutput image_size, TFOutput bounding_boxes, long? seed = null, long? seed2 = null, float? min_object_covered = null, float[] aspect_ratio_range = null, float[] area_range = null, long? max_attempts = null, bool? use_image_if_no_bounding_boxes = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SampleDistortedBoundingBox", MakeName ("SampleDistortedBoundingBox", operName));
			desc.AddInput (image_size);
			desc.AddInput (bounding_boxes);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			if (min_object_covered.HasValue)
				desc.SetAttr ("min_object_covered", min_object_covered.Value);
			
			if (aspect_ratio_range != null)
				desc.SetAttr ("aspect_ratio_range", aspect_ratio_range);
			
			if (area_range != null)
				desc.SetAttr ("area_range", area_range);
			
			if (max_attempts.HasValue)
				desc.SetAttr ("max_attempts", max_attempts.Value);
			
			if (use_image_if_no_bounding_boxes.HasValue)
				desc.SetAttr ("use_image_if_no_bounding_boxes", use_image_if_no_bounding_boxes.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var begin = new TFOutput (op, _idx++);
			var size = new TFOutput (op, _idx++);
			var bboxes = new TFOutput (op, _idx++);
			return (begin, size, bboxes);
		}

		/// <summary>
		///   Saves the input tensors to disk.
		/// </summary>
		/// <param name="filename">
		///   Must have a single element. The name of the file to which we write
		///   the tensor.
		/// </param>
		/// <param name="tensor_names">
		///   Shape `[N]`. The names of the tensors to be saved.
		/// </param>
		/// <param name="data">
		///   `N` tensors to save.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Save'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The size of `tensor_names` must match the number of tensors in `data`. `data[i]`
		///   is written to `filename` with name `tensor_names[i]`.
		///   
		///   See also `SaveSlices`.
		/// </remarks>
		public TFOperation Save (TFOutput filename, TFOutput tensor_names, TFOutput[] data, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Save", MakeName ("Save", operName));
			desc.AddInput (filename);
			desc.AddInput (tensor_names);
			desc.AddInputs (data);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Saves input tensors slices to disk.
		/// </summary>
		/// <param name="filename">
		///   Must have a single element. The name of the file to which we write the
		///   tensor.
		/// </param>
		/// <param name="tensor_names">
		///   Shape `[N]`. The names of the tensors to be saved.
		/// </param>
		/// <param name="shapes_and_slices">
		///   Shape `[N]`.  The shapes and slice specifications to use when
		///   saving the tensors.
		/// </param>
		/// <param name="data">
		///   `N` tensors to save.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SaveSlices'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This is like `Save` except that tensors can be listed in the saved file as being
		///   a slice of a larger tensor.  `shapes_and_slices` specifies the shape of the
		///   larger tensor and the slice that this tensor covers. `shapes_and_slices` must
		///   have as many elements as `tensor_names`.
		///   
		///   Elements of the `shapes_and_slices` input must either be:
		///   
		///   *  The empty string, in which case the corresponding tensor is
		///      saved normally.
		///   *  A string of the form `dim0 dim1 ... dimN-1 slice-spec` where the
		///      `dimI` are the dimensions of the larger tensor and `slice-spec`
		///      specifies what part is covered by the tensor to save.
		///   
		///   `slice-spec` itself is a `:`-separated list: `slice0:slice1:...:sliceN-1`
		///   where each `sliceI` is either:
		///   
		///   *  The string `-` meaning that the slice covers all indices of this dimension
		///   *  `start,length` where `start` and `length` are integers.  In that
		///      case the slice covers `length` indices starting at `start`.
		///   
		///   See also `Save`.
		/// </remarks>
		public TFOperation SaveSlices (TFOutput filename, TFOutput tensor_names, TFOutput shapes_and_slices, TFOutput[] data, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SaveSlices", MakeName ("SaveSlices", operName));
			desc.AddInput (filename);
			desc.AddInput (tensor_names);
			desc.AddInput (shapes_and_slices);
			desc.AddInputs (data);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Saves tensors in V2 checkpoint format.
		/// </summary>
		/// <param name="prefix">
		///   Must have a single element. The prefix of the V2 checkpoint to which we
		///   write the tensors.
		/// </param>
		/// <param name="tensor_names">
		///   shape {N}. The names of the tensors to be saved.
		/// </param>
		/// <param name="shape_and_slices">
		///   shape {N}.  The slice specs of the tensors to be saved.
		///   Empty strings indicate that they are non-partitioned tensors.
		/// </param>
		/// <param name="tensors">
		///   `N` tensors to save.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SaveV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   By default, saves the named tensors in full.  If the caller wishes to save
		///   specific slices of full tensors, "shape_and_slices" should be non-empty strings
		///   and correspondingly well-formed.
		/// </remarks>
		public TFOperation SaveV2 (TFOutput prefix, TFOutput tensor_names, TFOutput shape_and_slices, TFOutput[] tensors, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SaveV2", MakeName ("SaveV2", operName));
			desc.AddInput (prefix);
			desc.AddInput (tensor_names);
			desc.AddInput (shape_and_slices);
			desc.AddInputs (tensors);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with scalar values.
		/// </summary>
		/// <param name="tags">
		///   Tags for the summary.
		/// </param>
		/// <param name="values">
		///   Same shape as `tags.  Values for the summary.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ScalarSummary'.
		/// </param>
		/// <returns>
		///   Scalar.  Serialized `Summary` protocol buffer.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The input `tags` and `values` must have the same shape.  The generated summary
		///   has a summary value for each tag-value pair in `tags` and `values`.
		/// </remarks>
		public TFOutput ScalarSummary (TFOutput tags, TFOutput values, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ScalarSummary", MakeName ("ScalarSummary", operName));
			desc.AddInput (tags);
			desc.AddInput (values);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Scatter `updates` into a new (initially zero) tensor according to `indices`.
		/// </summary>
		/// <param name="indices">
		///   Index tensor.
		/// </param>
		/// <param name="updates">
		///   Updates to scatter into output.
		/// </param>
		/// <param name="shape">
		///   1-D. The shape of the resulting tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ScatterNd'.
		/// </param>
		/// <returns>
		///   A new tensor with the given shape and updates applied according
		///   to the indices.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Creates a new tensor by applying sparse `updates` to individual
		///   values or slices within a zero tensor of the given `shape` according to
		///   indices.  This operator is the inverse of the [tf.gather_nd](#gather_nd)
		///   operator which extracts values or slices from a given tensor.
		///   
		///   **WARNING**: The order in which updates are applied is nondeterministic, so the
		///   output will be nondeterministic if `indices` contains duplicates.
		///   
		///   `indices` is an integer tensor containing indices into a new tensor of shape
		///   `shape`.  The last dimension of `indices` can be at most the rank of `shape`:
		///   
		///       indices.shape[-1] &amp;lt;= shape.rank
		///   
		///   The last dimension of `indices` corresponds to indices into elements
		///   (if `indices.shape[-1] = shape.rank`) or slices
		///   (if `indices.shape[-1] &amp;lt; shape.rank`) along dimension `indices.shape[-1]` of
		///   `shape`.  `updates` is a tensor with shape
		///   
		///       indices.shape[:-1] + shape[indices.shape[-1]:]
		///   
		///   The simplest form of scatter is to insert individual elements in a tensor by
		///   index. For example, say we want to insert 4 scattered elements in a rank-1
		///   tensor with 8 elements.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/ScatterNd1.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		///   
		///   In Python, this scatter operation would look like this:
		///   
		///   ```python
		///       indices = tf.constant([[4], [3], [1], [7]])
		///       updates = tf.constant([9, 10, 11, 12])
		///       shape = tf.constant([8])
		///       scatter = tf.scatter_nd(indices, updates, shape)
		///       with tf.Session() as sess:
		///         print(sess.run(scatter))
		///   ```
		///   
		///   The resulting tensor would look like this:
		///   
		///       [0, 11, 0, 10, 9, 0, 0, 12]
		///   
		///   We can also, insert entire slices of a higher rank tensor all at once. For
		///   example, if we wanted to insert two slices in the first dimension of a
		///   rank-3 tensor with two matrices of new values.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/ScatterNd2.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		///   
		///   In Python, this scatter operation would look like this:
		///   
		///   ```python
		///       indices = tf.constant([[0], [2]])
		///       updates = tf.constant([[[5, 5, 5, 5], [6, 6, 6, 6],
		///                               [7, 7, 7, 7], [8, 8, 8, 8]],
		///                              [[5, 5, 5, 5], [6, 6, 6, 6],
		///                               [7, 7, 7, 7], [8, 8, 8, 8]]])
		///       shape = tf.constant([4, 4, 4])
		///       scatter = tf.scatter_nd(indices, updates, shape)
		///       with tf.Session() as sess:
		///         print(sess.run(scatter))
		///   ```
		///   
		///   The resulting tensor would look like this:
		///   
		///       [[[5, 5, 5, 5], [6, 6, 6, 6], [7, 7, 7, 7], [8, 8, 8, 8]],
		///        [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]],
		///        [[5, 5, 5, 5], [6, 6, 6, 6], [7, 7, 7, 7], [8, 8, 8, 8]],
		///        [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]]]
		/// </remarks>
		public TFOutput ScatterNd (TFOutput indices, TFOutput updates, TFOutput shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ScatterNd", MakeName ("ScatterNd", operName));
			desc.AddInput (indices);
			desc.AddInput (updates);
			desc.AddInput (shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes fingerprints of the input strings.
		/// </summary>
		/// <param name="input">
		///   vector of strings to compute fingerprints on.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SdcaFprint'.
		/// </param>
		/// <returns>
		///   a (N,2) shaped matrix where N is the number of elements in the input
		///   vector. Each row contains the low and high parts of the fingerprint.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SdcaFprint (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SdcaFprint", MakeName ("SdcaFprint", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Distributed version of Stochastic Dual Coordinate Ascent (SDCA) optimizer for
		/// </summary>
		/// <param name="sparse_example_indices">
		///   a list of vectors which contain example indices.
		/// </param>
		/// <param name="sparse_feature_indices">
		///   a list of vectors which contain feature indices.
		/// </param>
		/// <param name="sparse_feature_values">
		///   a list of vectors which contains feature value
		///   associated with each feature group.
		/// </param>
		/// <param name="dense_features">
		///   a list of matrices which contains the dense feature values.
		/// </param>
		/// <param name="example_weights">
		///   a vector which contains the weight associated with each
		///   example.
		/// </param>
		/// <param name="example_labels">
		///   a vector which contains the label/target associated with each
		///   example.
		/// </param>
		/// <param name="sparse_indices">
		///   a list of vectors where each value is the indices which has
		///   corresponding weights in sparse_weights. This field maybe omitted for the
		///   dense approach.
		/// </param>
		/// <param name="sparse_weights">
		///   a list of vectors where each value is the weight associated with
		///   a sparse feature group.
		/// </param>
		/// <param name="dense_weights">
		///   a list of vectors where the values are the weights associated
		///   with a dense feature group.
		/// </param>
		/// <param name="example_state_data">
		///   a list of vectors containing the example state data.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SdcaOptimizer'.
		/// </param>
		/// <param name="adaptative">
		///   Optional argument
		///   Whether to use Adapative SDCA for the inner loop.
		/// </param>
		/// <param name="loss_type">
		///   Type of the primal loss. Currently SdcaSolver supports logistic,
		///   squared and hinge losses.
		/// </param>
		/// <param name="l1">
		///   Symmetric l1 regularization strength.
		/// </param>
		/// <param name="l2">
		///   Symmetric l2 regularization strength.
		/// </param>
		/// <param name="num_loss_partitions">
		///   Number of partitions of the global loss function.
		/// </param>
		/// <param name="num_inner_iterations">
		///   Number of iterations per mini-batch.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   out_example_state_data: a list of vectors containing the updated example state
		///   data.
		///   out_delta_sparse_weights: a list of vectors where each value is the delta
		///   weights associated with a sparse feature group.
		///   out_delta_dense_weights: a list of vectors where the values are the delta
		///   weights associated with a dense feature group.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   linear models with L1 + L2 regularization. As global optimization objective is
		///   strongly-convex, the optimizer optimizes the dual objective at each step. The
		///   optimizer applies each update one example at a time. Examples are sampled
		///   uniformly, and the optimizer is learning rate free and enjoys linear convergence
		///   rate.
		///   
		///   [Proximal Stochastic Dual Coordinate Ascent](http://arxiv.org/pdf/1211.2717v1.pdf).&amp;lt;br&amp;gt;
		///   Shai Shalev-Shwartz, Tong Zhang. 2012
		///   
		///   $$Loss Objective = \sum f_{i} (wx_{i}) + (l2 / 2) * |w|^2 + l1 * |w|$$
		///   
		///   [Adding vs. Averaging in Distributed Primal-Dual Optimization](http://arxiv.org/abs/1502.03508).&amp;lt;br&amp;gt;
		///   Chenxin Ma, Virginia Smith, Martin Jaggi, Michael I. Jordan,
		///   Peter Richtarik, Martin Takac. 2015
		///   
		///   [Stochastic Dual Coordinate Ascent with Adaptive Probabilities](https://arxiv.org/abs/1502.08053).&amp;lt;br&amp;gt;
		///   Dominik Csiba, Zheng Qu, Peter Richtarik. 2015
		/// </remarks>
		public (TFOutput out_example_state_data, TFOutput[] out_delta_sparse_weights, TFOutput[] out_delta_dense_weights) SdcaOptimizer (TFOutput[] sparse_example_indices, TFOutput[] sparse_feature_indices, TFOutput[] sparse_feature_values, TFOutput[] dense_features, TFOutput example_weights, TFOutput example_labels, TFOutput[] sparse_indices, TFOutput[] sparse_weights, TFOutput[] dense_weights, TFOutput example_state_data, string loss_type, float l1, float l2, long num_loss_partitions, long num_inner_iterations, bool? adaptative = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SdcaOptimizer", MakeName ("SdcaOptimizer", operName));
			desc.AddInputs (sparse_example_indices);
			desc.AddInputs (sparse_feature_indices);
			desc.AddInputs (sparse_feature_values);
			desc.AddInputs (dense_features);
			desc.AddInput (example_weights);
			desc.AddInput (example_labels);
			desc.AddInputs (sparse_indices);
			desc.AddInputs (sparse_weights);
			desc.AddInputs (dense_weights);
			desc.AddInput (example_state_data);
			desc.SetAttr ("loss_type", loss_type);
			desc.SetAttr ("l1", l1);
			desc.SetAttr ("l2", l2);
			desc.SetAttr ("num_loss_partitions", num_loss_partitions);
			desc.SetAttr ("num_inner_iterations", num_inner_iterations);
			if (adaptative.HasValue)
				desc.SetAttr ("adaptative", adaptative.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			var out_example_state_data = new TFOutput (op, _idx++);
			_n = op.OutputListLength ("out_delta_sparse_weights");
			var out_delta_sparse_weights = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				out_delta_sparse_weights [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("out_delta_dense_weights");
			var out_delta_dense_weights = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				out_delta_dense_weights [i] = new TFOutput (op, _idx++);
			
			return (out_example_state_data, out_delta_sparse_weights, out_delta_dense_weights);
		}

		/// <summary>
		///   Computes the maximum along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.  Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SegmentMax'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   \\(output_i = \max_j(data_j)\\) where `max` is over `j` such
		///   that `segment_ids[j] == i`.
		///   
		///   If the max is empty for a given segment ID `i`, `output[i] = 0`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/SegmentMax.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput SegmentMax (TFOutput data, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SegmentMax", MakeName ("SegmentMax", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the mean along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.  Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SegmentMean'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   \\(output_i = \frac{\sum_j data_j}{N}\\) where `mean` is
		///   over `j` such that `segment_ids[j] == i` and `N` is the total number of
		///   values summed.
		///   
		///   If the mean is empty for a given segment ID `i`, `output[i] = 0`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/SegmentMean.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput SegmentMean (TFOutput data, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SegmentMean", MakeName ("SegmentMean", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the minimum along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.  Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SegmentMin'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   \\(output_i = \min_j(data_j)\\) where `min` is over `j` such
		///   that `segment_ids[j] == i`.
		///   
		///   If the min is empty for a given segment ID `i`, `output[i] = 0`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/SegmentMin.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput SegmentMin (TFOutput data, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SegmentMin", MakeName ("SegmentMin", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the product along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.  Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SegmentProd'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   \\(output_i = \prod_j data_j\\) where the product is over `j` such
		///   that `segment_ids[j] == i`.
		///   
		///   If the product is empty for a given segment ID `i`, `output[i] = 1`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/SegmentProd.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput SegmentProd (TFOutput data, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SegmentProd", MakeName ("SegmentProd", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.  Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SegmentSum'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   \\(output_i = \sum_j data_j\\) where sum is over `j` such
		///   that `segment_ids[j] == i`.
		///   
		///   If the sum is empty for a given segment ID `i`, `output[i] = 0`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/SegmentSum.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput SegmentSum (TFOutput data, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SegmentSum", MakeName ("SegmentSum", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Selects elements from `t` or `e`, depending on `condition`.
		/// </summary>
		/// <param name="condition">
		/// </param>
		/// <param name="t">
		///   = A `Tensor` which may have the same shape as `condition`.
		///   If `condition` is rank 1, `t` may have higher rank,
		///   but its first dimension must match the size of `condition`.
		/// </param>
		/// <param name="e">
		///   = A `Tensor` with the same type and shape as `t`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Select'.
		/// </param>
		/// <returns>
		///   = A `Tensor` with the same type and shape as `t` and `e`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The `t`, and `e` tensors must all have the same shape, and the
		///   output will also have that shape.
		///   
		///   The `condition` tensor must be a scalar if `t` and `e` are scalars.
		///   If `t` and `e` are vectors or higher rank, then `condition` must be either a
		///   scalar, a vector with size matching the first dimension of `t`, or must have
		///   the same shape as `t`.
		///   
		///   The `condition` tensor acts as a mask that chooses, based on the value at each
		///   element, whether the corresponding element / row in the output should be
		///   taken from `t` (if true) or `e` (if false).
		///   
		///   If `condition` is a vector and `t` and `e` are higher rank matrices, then
		///   it chooses which row (outer dimension) to copy from `t` and `e`.
		///   If `condition` has the same shape as `t` and `e`, then it chooses which
		///   element to copy from `t` and `e`.
		///   
		///   For example:
		///   
		///   ```prettyprint
		///   # 'condition' tensor is [[True,  False]
		///   #                        [False, True]]
		///   # 't' is [[1, 2],
		///   #         [3, 4]]
		///   # 'e' is [[5, 6],
		///   #         [7, 8]]
		///   select(condition, t, e) ==&amp;gt; [[1, 6],
		///                                [7, 4]]
		///   
		///   
		///   # 'condition' tensor is [True, False]
		///   # 't' is [[1, 2],
		///   #         [3, 4]]
		///   # 'e' is [[5, 6],
		///   #         [7, 8]]
		///   select(condition, t, e) ==&amp;gt; [[1, 2],
		///                                [7, 8]]
		///   
		///   ```
		/// </remarks>
		public TFOutput Select (TFOutput condition, TFOutput t, TFOutput e, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Select", MakeName ("Select", operName));
			desc.AddInput (condition);
			desc.AddInput (t);
			desc.AddInput (e);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the Eigen Decomposition of a batch of square self-adjoint matrices.
		/// </summary>
		/// <param name="input">
		///   Shape is `[..., M, M]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SelfAdjointEig'.
		/// </param>
		/// <returns>
		///   Shape is `[..., M+1, M]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The input is a tensor of shape `[..., M, M]` whose inner-most 2 dimensions
		///   form square matrices, with the same constraints as the single matrix
		///   SelfAdjointEig.
		///   
		///   The result is a [..., M+1, M] matrix with [..., 0,:] containing the
		///   eigenvalues, and subsequent [...,1:, :] containing the eigenvectors.
		/// </remarks>
		public TFOutput SelfAdjointEig (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SelfAdjointEig", MakeName ("SelfAdjointEig", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the eigen decomposition of one or more square self-adjoint matrices.
		/// </summary>
		/// <param name="input">
		///   `Tensor` input of shape `[N, N]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SelfAdjointEigV2'.
		/// </param>
		/// <param name="compute_v">
		///   Optional argument
		///   If `True` then eigenvectors will be computed and returned in `v`.
		///   Otherwise, only the eigenvalues will be computed.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   e: Eigenvalues. Shape is `[N]`.
		///   v: Eigenvectors. Shape is `[N, N]`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Computes the eigenvalues and (optionally) eigenvectors of each inner matrix in
		///   `input` such that `input[..., :, :] = v[..., :, :] * diag(e[..., :])`.
		///   
		///   ```prettyprint
		///   # a is a tensor.
		///   # e is a tensor of eigenvalues.
		///   # v is a tensor of eigenvectors.
		///   e, v = self_adjoint_eig(a)
		///   e = self_adjoint_eig(a, compute_v=False)
		///   ```
		/// </remarks>
		public (TFOutput e, TFOutput v) SelfAdjointEigV2 (TFOutput input, bool? compute_v = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SelfAdjointEigV2", MakeName ("SelfAdjointEigV2", operName));
			desc.AddInput (input);
			if (compute_v.HasValue)
				desc.SetAttr ("compute_v", compute_v.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var e = new TFOutput (op, _idx++);
			var v = new TFOutput (op, _idx++);
			return (e, v);
		}

		/// <summary>
		///   Serialize an `N`-minibatch `SparseTensor` into an `[N, 3]` string `Tensor`.
		/// </summary>
		/// <param name="sparse_indices">
		///   2-D.  The `indices` of the minibatch `SparseTensor`.
		/// </param>
		/// <param name="sparse_values">
		///   1-D.  The `values` of the minibatch `SparseTensor`.
		/// </param>
		/// <param name="sparse_shape">
		///   1-D.  The `shape` of the minibatch `SparseTensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SerializeManySparse'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The `SparseTensor` must have rank `R` greater than 1, and the first dimension
		///   is treated as the minibatch dimension.  Elements of the `SparseTensor`
		///   must be sorted in increasing order of this first dimension.  The serialized
		///   `SparseTensor` objects going into each row of `serialized_sparse` will have
		///   rank `R-1`.
		///   
		///   The minibatch size `N` is extracted from `sparse_shape[0]`.
		/// </remarks>
		public TFOutput SerializeManySparse (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SerializeManySparse", MakeName ("SerializeManySparse", operName));
			desc.AddInput (sparse_indices);
			desc.AddInput (sparse_values);
			desc.AddInput (sparse_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var serialized_sparse = new TFOutput (op, _idx++);
			return serialized_sparse;
		}

		/// <summary>
		///   Serialize a `SparseTensor` into a string 3-vector (1-D `Tensor`) object.
		/// </summary>
		/// <param name="sparse_indices">
		///   2-D.  The `indices` of the `SparseTensor`.
		/// </param>
		/// <param name="sparse_values">
		///   1-D.  The `values` of the `SparseTensor`.
		/// </param>
		/// <param name="sparse_shape">
		///   1-D.  The `shape` of the `SparseTensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SerializeSparse'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SerializeSparse (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SerializeSparse", MakeName ("SerializeSparse", operName));
			desc.AddInput (sparse_indices);
			desc.AddInput (sparse_values);
			desc.AddInput (sparse_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var serialized_sparse = new TFOutput (op, _idx++);
			return serialized_sparse;
		}

		/// <summary>
		///   Number of unique elements along last dimension of input `set`.
		/// </summary>
		/// <param name="set_indices">
		///   2D `Tensor`, indices of a `SparseTensor`.
		/// </param>
		/// <param name="set_values">
		///   1D `Tensor`, values of a `SparseTensor`.
		/// </param>
		/// <param name="set_shape">
		///   1D `Tensor`, shape of a `SparseTensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SetSize'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <returns>
		///   For `set` ranked `n`, this is a `Tensor` with rank `n-1`, and the same 1st
		///   `n-1` dimensions as `set`. Each value is the number of unique elements in
		///   the corresponding `[0...n-1]` dimension of `set`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Input `set` is a `SparseTensor` represented by `set_indices`, `set_values`,
		///   and `set_shape`. The last dimension contains values in a set, duplicates are
		///   allowed but ignored.
		///   
		///   If `validate_indices` is `True`, this op validates the order and range of `set`
		///   indices.
		/// </remarks>
		public TFOutput SetSize (TFOutput set_indices, TFOutput set_values, TFOutput set_shape, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SetSize", MakeName ("SetSize", operName));
			desc.AddInput (set_indices);
			desc.AddInput (set_values);
			desc.AddInput (set_shape);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var size = new TFOutput (op, _idx++);
			return size;
		}

		/// <summary>
		///   Returns the shape of a tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Shape'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns a 1-D integer tensor representing the shape of `input`.
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[[1, 1, 1], [2, 2, 2]], [[3, 3, 3], [4, 4, 4]]]
		///   shape(t) ==&amp;gt; [2, 2, 3]
		///   ```
		/// </remarks>
		public TFOutput Shape (TFOutput input, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Shape", MakeName ("Shape", operName));
			desc.AddInput (input);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns shape of tensors.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ShapeN'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns N 1-D integer tensors representing shape of `input[i]s`.
		/// </remarks>
		public TFOutput[] ShapeN (TFOutput[] input, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ShapeN", MakeName ("ShapeN", operName));
			desc.AddInputs (input);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output");
			var output = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output [i] = new TFOutput (op, _idx++);
			
			return output;
		}

		/// <summary>
		///   Generate a sharded filename. The filename is printf formatted as
		/// </summary>
		/// <param name="basename">
		/// </param>
		/// <param name="shard">
		/// </param>
		/// <param name="num_shards">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ShardedFilename'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///      %s-%05d-of-%05d, basename, shard, num_shards.
		/// </remarks>
		public TFOutput ShardedFilename (TFOutput basename, TFOutput shard, TFOutput num_shards, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ShardedFilename", MakeName ("ShardedFilename", operName));
			desc.AddInput (basename);
			desc.AddInput (shard);
			desc.AddInput (num_shards);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var filename = new TFOutput (op, _idx++);
			return filename;
		}

		/// <summary>
		///   Generate a glob pattern matching all sharded file names.
		/// </summary>
		/// <param name="basename">
		/// </param>
		/// <param name="num_shards">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ShardedFilespec'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ShardedFilespec (TFOutput basename, TFOutput num_shards, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ShardedFilespec", MakeName ("ShardedFilespec", operName));
			desc.AddInput (basename);
			desc.AddInput (num_shards);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var filename = new TFOutput (op, _idx++);
			return filename;
		}

		/// <summary>
		///   Creates a dataset that shuffles elements from `input_dataset` pseudorandomly.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="buffer_size">
		///   The number of output elements to buffer in an iterator over
		///   this dataset. Compare with the `min_after_dequeue` attr when creating a
		///   `RandomShuffleQueue`.
		/// </param>
		/// <param name="seed">
		///   A scalar seed for the random number generator. If either seed or
		///   seed2 is set to be non-zero, the random number generator is seeded
		///   by the given seed.  Otherwise, a random seed is used.
		/// </param>
		/// <param name="seed2">
		///   A second scalar seed to avoid seed collision.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ShuffleDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ShuffleDataset (TFOutput input_dataset, TFOutput buffer_size, TFOutput seed, TFOutput seed2, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ShuffleDataset", MakeName ("ShuffleDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (buffer_size);
			desc.AddInput (seed);
			desc.AddInput (seed2);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Computes sigmoid of `x` element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sigmoid'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `y = 1 / (1 + exp(-x))`.
		/// </remarks>
		public TFOutput Sigmoid (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sigmoid", MakeName ("Sigmoid", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient of the sigmoid of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SigmoidGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = dy * y * (1 - y)`, where `y = sigmoid(x)`, and
		///   `dy` is the corresponding input gradient.
		/// </remarks>
		public TFOutput SigmoidGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SigmoidGrad", MakeName ("SigmoidGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Returns an element-wise indication of the sign of a number.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sign'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `y = sign(x) = -1` if `x &amp;lt; 0`; 0 if `x == 0`; 1 if `x &amp;gt; 0`.
		///   
		///   For complex numbers, `y = sign(x) = x / |x|` if `x != 0`, otherwise `y = 0`.
		/// </remarks>
		public TFOutput Sign (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sign", MakeName ("Sign", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes sin of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sin'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Sin (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sin", MakeName ("Sin", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns the size of a tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Size'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns an integer representing the number of elements in
		///   `input`.
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is [[[1, 1,, 1], [2, 2, 2]], [[3, 3, 3], [4, 4, 4]]]]
		///   size(t) ==&amp;gt; 12
		///   ```
		/// </remarks>
		public TFOutput Size (TFOutput input, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Size", MakeName ("Size", operName));
			desc.AddInput (input);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Creates a dataset that skips `count` elements from the `input_dataset`.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="count">
		///   A scalar representing the number of elements from the `input_dataset`
		///   that should be skipped.  If count is -1, skips everything.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SkipDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SkipDataset (TFOutput input_dataset, TFOutput count, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SkipDataset", MakeName ("SkipDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (count);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Parses a text file and creates a batch of examples.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Skipgram'.
		/// </param>
		/// <param name="window_size">
		///   Optional argument
		///   The number of words to predict to the left and right of the target.
		/// </param>
		/// <param name="min_count">
		///   Optional argument
		///   The minimum number of word occurrences for it to be included in the
		///   vocabulary.
		/// </param>
		/// <param name="subsample">
		///   Optional argument
		///   Threshold for word occurrence. Words that appear with higher
		///   frequency will be randomly down-sampled. Set to 0 to disable.
		/// </param>
		/// <param name="filename">
		///   The corpus's text file name.
		/// </param>
		/// <param name="batch_size">
		///   The size of produced batch.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   vocab_word: A vector of words in the corpus.
		///   vocab_freq: Frequencies of words. Sorted in the non-ascending order.
		///   words_per_epoch: Number of words per epoch in the data file.
		///   current_epoch: The current epoch number.
		///   total_words_processed: The total number of words processed so far.
		///   examples: A vector of word ids.
		///   labels: A vector of word ids.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput vocab_word, TFOutput vocab_freq, TFOutput words_per_epoch, TFOutput current_epoch, TFOutput total_words_processed, TFOutput examples, TFOutput labels) Skipgram (string filename, long batch_size, long? window_size = null, long? min_count = null, float? subsample = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Skipgram", MakeName ("Skipgram", operName));
			desc.SetAttr ("filename", filename);
			desc.SetAttr ("batch_size", batch_size);
			if (window_size.HasValue)
				desc.SetAttr ("window_size", window_size.Value);
			
			if (min_count.HasValue)
				desc.SetAttr ("min_count", min_count.Value);
			
			if (subsample.HasValue)
				desc.SetAttr ("subsample", subsample.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var vocab_word = new TFOutput (op, _idx++);
			var vocab_freq = new TFOutput (op, _idx++);
			var words_per_epoch = new TFOutput (op, _idx++);
			var current_epoch = new TFOutput (op, _idx++);
			var total_words_processed = new TFOutput (op, _idx++);
			var examples = new TFOutput (op, _idx++);
			var labels = new TFOutput (op, _idx++);
			return (vocab_word, vocab_freq, words_per_epoch, current_epoch, total_words_processed, examples, labels);
		}

		/// <summary>
		///   Return a slice from 'input'.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="begin">
		///   begin[i] specifies the offset into the 'i'th dimension of
		///   'input' to slice from.
		/// </param>
		/// <param name="size">
		///   size[i] specifies the number of elements of the 'i'th dimension
		///   of 'input' to slice. If size[i] is -1, all remaining elements in dimension
		///   i are included in the slice (i.e. this is equivalent to setting
		///   size[i] = input.dim_size(i) - begin[i]).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Slice'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The output tensor is a tensor with dimensions described by 'size'
		///   whose values are extracted from 'input' starting at the offsets in
		///   'begin'.
		///   
		///   *Requirements*:
		///     0 &amp;lt;= begin[i] &amp;lt;= begin[i] + size[i] &amp;lt;= Di  for i in [0, n)
		/// </remarks>
		public TFOutput Slice (TFOutput input, TFOutput begin, TFOutput size, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Slice", MakeName ("Slice", operName));
			desc.AddInput (input);
			desc.AddInput (begin);
			desc.AddInput (size);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes softmax activations.
		/// </summary>
		/// <param name="logits">
		///   2-D with shape `[batch_size, num_classes]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Softmax'.
		/// </param>
		/// <returns>
		///   Same shape as `logits`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For each batch `i` and class `j` we have
		///   
		///       softmax[i, j] = exp(logits[i, j]) / sum_j(exp(logits[i, j]))
		/// </remarks>
		public TFOutput Softmax (TFOutput logits, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Softmax", MakeName ("Softmax", operName));
			desc.AddInput (logits);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var softmax = new TFOutput (op, _idx++);
			return softmax;
		}

		/// <summary>
		///   Computes softmax cross entropy cost and gradients to backpropagate.
		/// </summary>
		/// <param name="features">
		///   batch_size x num_classes matrix
		/// </param>
		/// <param name="labels">
		///   batch_size x num_classes matrix
		///   The caller must ensure that each batch of labels represents a valid
		///   probability distribution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SoftmaxCrossEntropyWithLogits'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   loss: Per example loss (batch_size vector).
		///   backprop: backpropagated gradients (batch_size x num_classes matrix).
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Inputs are the logits, not probabilities.
		/// </remarks>
		public (TFOutput loss, TFOutput backprop) SoftmaxCrossEntropyWithLogits (TFOutput features, TFOutput labels, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SoftmaxCrossEntropyWithLogits", MakeName ("SoftmaxCrossEntropyWithLogits", operName));
			desc.AddInput (features);
			desc.AddInput (labels);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var loss = new TFOutput (op, _idx++);
			var backprop = new TFOutput (op, _idx++);
			return (loss, backprop);
		}

		/// <summary>
		///   Computes softplus: `log(exp(features) + 1)`.
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Softplus'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Softplus (TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Softplus", MakeName ("Softplus", operName));
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			return activations;
		}

		/// <summary>
		///   Computes softplus gradients for a softplus operation.
		/// </summary>
		/// <param name="gradients">
		///   The backpropagated gradients to the corresponding softplus operation.
		/// </param>
		/// <param name="features">
		///   The features passed as input to the corresponding softplus operation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SoftplusGrad'.
		/// </param>
		/// <returns>
		///   The gradients: `gradients / (1 + exp(-features))`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SoftplusGrad (TFOutput gradients, TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SoftplusGrad", MakeName ("SoftplusGrad", operName));
			desc.AddInput (gradients);
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   Computes softsign: `features / (abs(features) + 1)`.
		/// </summary>
		/// <param name="features">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Softsign'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Softsign (TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Softsign", MakeName ("Softsign", operName));
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var activations = new TFOutput (op, _idx++);
			return activations;
		}

		/// <summary>
		///   Computes softsign gradients for a softsign operation.
		/// </summary>
		/// <param name="gradients">
		///   The backpropagated gradients to the corresponding softsign operation.
		/// </param>
		/// <param name="features">
		///   The features passed as input to the corresponding softsign operation.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SoftsignGrad'.
		/// </param>
		/// <returns>
		///   The gradients: `gradients / (1 + abs(-features)) ** 2`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SoftsignGrad (TFOutput gradients, TFOutput features, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SoftsignGrad", MakeName ("SoftsignGrad", operName));
			desc.AddInput (gradients);
			desc.AddInput (features);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var backprops = new TFOutput (op, _idx++);
			return backprops;
		}

		/// <summary>
		///   SpaceToBatch for 4-D tensors of type T.
		/// </summary>
		/// <param name="input">
		///   4-D with shape `[batch, height, width, depth]`.
		/// </param>
		/// <param name="paddings">
		///   2-D tensor of non-negative integers with shape `[2, 2]`. It specifies
		///     the padding of the input with zeros across the spatial dimensions as follows:
		///   
		///         paddings = [[pad_top, pad_bottom], [pad_left, pad_right]]
		///   
		///     The effective spatial dimensions of the zero-padded input tensor will be:
		///   
		///         height_pad = pad_top + height + pad_bottom
		///         width_pad = pad_left + width + pad_right
		///   
		///   The attr `block_size` must be greater than one. It indicates the block size.
		///   
		///     * Non-overlapping blocks of size `block_size x block size` in the height and
		///       width dimensions are rearranged into the batch dimension at each location.
		///     * The batch of the output tensor is `batch * block_size * block_size`.
		///     * Both height_pad and width_pad must be divisible by block_size.
		///   
		///   The shape of the output will be:
		///   
		///       [batch*block_size*block_size, height_pad/block_size, width_pad/block_size,
		///        depth]
		///   
		///   Some examples:
		///   
		///   (1) For the following input of shape `[1, 2, 2, 1]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1], [2]], [[3], [4]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 1, 1, 1]` and value:
		///   
		///   ```
		///   [[[[1]]], [[[2]]], [[[3]]], [[[4]]]]
		///   ```
		///   
		///   (2) For the following input of shape `[1, 2, 2, 3]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1, 2, 3], [4, 5, 6]],
		///         [[7, 8, 9], [10, 11, 12]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 1, 1, 3]` and value:
		///   
		///   ```
		///   [[[1, 2, 3]], [[4, 5, 6]], [[7, 8, 9]], [[10, 11, 12]]]
		///   ```
		///   
		///   (3) For the following input of shape `[1, 4, 4, 1]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1],   [2],  [3],  [4]],
		///         [[5],   [6],  [7],  [8]],
		///         [[9],  [10], [11],  [12]],
		///         [[13], [14], [15],  [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 2, 2, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [3]], [[9], [11]]],
		///        [[[2], [4]], [[10], [12]]],
		///        [[[5], [7]], [[13], [15]]],
		///        [[[6], [8]], [[14], [16]]]]
		///   ```
		///   
		///   (4) For the following input of shape `[2, 2, 4, 1]` and block_size of 2:
		///   
		///   ```
		///   x = [[[[1],   [2],  [3],  [4]],
		///         [[5],   [6],  [7],  [8]]],
		///        [[[9],  [10], [11],  [12]],
		///         [[13], [14], [15],  [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[8, 1, 2, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [3]]], [[[9], [11]]], [[[2], [4]]], [[[10], [12]]],
		///        [[[5], [7]]], [[[13], [15]]], [[[6], [8]]], [[[14], [16]]]]
		///   ```
		///   
		///   Among others, this operation is useful for reducing atrous convolution into
		///   regular convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SpaceToBatch'.
		/// </param>
		/// <param name="block_size">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This is a legacy version of the more general SpaceToBatchND.
		///   
		///   Zero-pads and then rearranges (permutes) blocks of spatial data into batch.
		///   More specifically, this op outputs a copy of the input tensor where values from
		///   the `height` and `width` dimensions are moved to the `batch` dimension. After
		///   the zero-padding, both `height` and `width` of the input must be divisible by the
		///   block size.
		/// </remarks>
		public TFOutput SpaceToBatch (TFOutput input, TFOutput paddings, long block_size, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SpaceToBatch", MakeName ("SpaceToBatch", operName));
			desc.AddInput (input);
			desc.AddInput (paddings);
			desc.SetAttr ("block_size", block_size);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   SpaceToBatch for N-D tensors of type T.
		/// </summary>
		/// <param name="input">
		///   N-D with shape `input_shape = [batch] + spatial_shape + remaining_shape`,
		///   where spatial_shape has `M` dimensions.
		/// </param>
		/// <param name="block_shape">
		///   1-D with shape `[M]`, all values must be &amp;gt;= 1.
		/// </param>
		/// <param name="paddings">
		///   2-D with shape `[M, 2]`, all values must be &amp;gt;= 0.
		///     `paddings[i] = [pad_start, pad_end]` specifies the padding for input dimension
		///     `i + 1`, which corresponds to spatial dimension `i`.  It is required that
		///     `block_shape[i]` divides `input_shape[i + 1] + pad_start + pad_end`.
		///   
		///   This operation is equivalent to the following steps:
		///   
		///   1. Zero-pad the start and end of dimensions `[1, ..., M]` of the
		///      input according to `paddings` to produce `padded` of shape `padded_shape`.
		///   
		///   2. Reshape `padded` to `reshaped_padded` of shape:
		///   
		///        [batch] +
		///        [padded_shape[1] / block_shape[0],
		///          block_shape[0],
		///         ...,
		///         padded_shape[M] / block_shape[M-1],
		///         block_shape[M-1]] +
		///        remaining_shape
		///   
		///   3. Permute dimensions of `reshaped_padded` to produce
		///      `permuted_reshaped_padded` of shape:
		///   
		///        block_shape +
		///        [batch] +
		///        [padded_shape[1] / block_shape[0],
		///         ...,
		///         padded_shape[M] / block_shape[M-1]] +
		///        remaining_shape
		///   
		///   4. Reshape `permuted_reshaped_padded` to flatten `block_shape` into the batch
		///      dimension, producing an output tensor of shape:
		///   
		///        [batch * prod(block_shape)] +
		///        [padded_shape[1] / block_shape[0],
		///         ...,
		///         padded_shape[M] / block_shape[M-1]] +
		///        remaining_shape
		///   
		///   Some examples:
		///   
		///   (1) For the following input of shape `[1, 2, 2, 1]`, `block_shape = [2, 2]`, and
		///       `paddings = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   x = [[[[1], [2]], [[3], [4]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 1, 1, 1]` and value:
		///   
		///   ```
		///   [[[[1]]], [[[2]]], [[[3]]], [[[4]]]]
		///   ```
		///   
		///   (2) For the following input of shape `[1, 2, 2, 3]`, `block_shape = [2, 2]`, and
		///       `paddings = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   x = [[[[1, 2, 3], [4, 5, 6]],
		///         [[7, 8, 9], [10, 11, 12]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 1, 1, 3]` and value:
		///   
		///   ```
		///   [[[1, 2, 3]], [[4, 5, 6]], [[7, 8, 9]], [[10, 11, 12]]]
		///   ```
		///   
		///   (3) For the following input of shape `[1, 4, 4, 1]`, `block_shape = [2, 2]`, and
		///       `paddings = [[0, 0], [0, 0]]`:
		///   
		///   ```
		///   x = [[[[1],   [2],  [3],  [4]],
		///         [[5],   [6],  [7],  [8]],
		///         [[9],  [10], [11],  [12]],
		///         [[13], [14], [15],  [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[4, 2, 2, 1]` and value:
		///   
		///   ```
		///   x = [[[[1], [3]], [[9], [11]]],
		///        [[[2], [4]], [[10], [12]]],
		///        [[[5], [7]], [[13], [15]]],
		///        [[[6], [8]], [[14], [16]]]]
		///   ```
		///   
		///   (4) For the following input of shape `[2, 2, 4, 1]`, block_shape = `[2, 2]`, and
		///       paddings = `[[0, 0], [2, 0]]`:
		///   
		///   ```
		///   x = [[[[1],   [2],  [3],  [4]],
		///         [[5],   [6],  [7],  [8]]],
		///        [[[9],  [10], [11],  [12]],
		///         [[13], [14], [15],  [16]]]]
		///   ```
		///   
		///   The output tensor has shape `[8, 1, 3, 1]` and value:
		///   
		///   ```
		///   x = [[[[0], [1], [3]]], [[[0], [9], [11]]],
		///        [[[0], [2], [4]]], [[[0], [10], [12]]],
		///        [[[0], [5], [7]]], [[[0], [13], [15]]],
		///        [[[0], [6], [8]]], [[[0], [14], [16]]]]
		///   ```
		///   
		///   Among others, this operation is useful for reducing atrous convolution into
		///   regular convolution.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SpaceToBatchND'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation divides "spatial" dimensions `[1, ..., M]` of the input into a
		///   grid of blocks of shape `block_shape`, and interleaves these blocks with the
		///   "batch" dimension (0) such that in the output, the spatial dimensions
		///   `[1, ..., M]` correspond to the position within the grid, and the batch
		///   dimension combines both the position within a spatial block and the original
		///   batch position.  Prior to division into blocks, the spatial dimensions of the
		///   input are optionally zero padded according to `paddings`.  See below for a
		///   precise description.
		/// </remarks>
		public TFOutput SpaceToBatchND (TFOutput input, TFOutput block_shape, TFOutput paddings, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SpaceToBatchND", MakeName ("SpaceToBatchND", operName));
			desc.AddInput (input);
			desc.AddInput (block_shape);
			desc.AddInput (paddings);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   SpaceToDepth for tensors of type T.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SpaceToDepth'.
		/// </param>
		/// <param name="block_size">
		///   The size of the spatial block.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Rearranges blocks of spatial data, into depth. More specifically,
		///   this op outputs a copy of the input tensor where values from the `height`
		///   and `width` dimensions are moved to the `depth` dimension.
		///   The attr `block_size` indicates the input block size and how the data is moved.
		///   
		///     * Non-overlapping blocks of size `block_size x block size` are rearranged
		///       into depth at each location.
		///     * The depth of the output tensor is `input_depth * block_size * block_size`.
		///     * The input tensor's height and width must be divisible by block_size.
		///   
		///   That is, assuming the input is in the shape:
		///   `[batch, height, width, depth]`,
		///   the shape of the output will be:
		///   `[batch, height/block_size, width/block_size, depth*block_size*block_size]`
		///   
		///   This operation requires that the input tensor be of rank 4, and that
		///   `block_size` be &amp;gt;=1 and a divisor of both the input `height` and `width`.
		///   
		///   This operation is useful for resizing the activations between convolutions
		///   (but keeping all data), e.g. instead of pooling. It is also useful for training
		///   purely convolutional models.
		///   
		///   For example, given this input of shape `[1, 2, 2, 1]`, and block_size of 2:
		///   
		///   ```
		///   x = [[[[1], [2]],
		///         [[3], [4]]]]
		///   ```
		///   
		///   This operation will output a tensor of shape `[1, 1, 1, 4]`:
		///   
		///   ```
		///   [[[[1, 2, 3, 4]]]]
		///   ```
		///   
		///   Here, the input has a batch of 1 and each batch element has shape `[2, 2, 1]`,
		///   the corresponding output will have a single element (i.e. width and height are
		///   both 1) and will have a depth of 4 channels (1 * block_size * block_size).
		///   The output element shape is `[1, 1, 4]`.
		///   
		///   For an input tensor with larger depth, here of shape `[1, 2, 2, 3]`, e.g.
		///   
		///   ```
		///   x = [[[[1, 2, 3], [4, 5, 6]],
		///         [[7, 8, 9], [10, 11, 12]]]]
		///   ```
		///   
		///   This operation, for block_size of 2, will return the following tensor of shape
		///   `[1, 1, 1, 12]`
		///   
		///   ```
		///   [[[[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]]]]
		///   ```
		///   
		///   Similarly, for the following input of shape `[1 4 4 1]`, and a block size of 2:
		///   
		///   ```
		///   x = [[[[1],   [2],  [5],  [6]],
		///         [[3],   [4],  [7],  [8]],
		///         [[9],  [10], [13],  [14]],
		///         [[11], [12], [15],  [16]]]]
		///   ```
		///   
		///   the operator will return the following tensor of shape `[1 2 2 4]`:
		///   
		///   ```
		///   x = [[[[1, 2, 3, 4],
		///          [5, 6, 7, 8]],
		///         [[9, 10, 11, 12],
		///          [13, 14, 15, 16]]]]
		///   ```
		/// </remarks>
		public TFOutput SpaceToDepth (TFOutput input, long block_size, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SpaceToDepth", MakeName ("SpaceToDepth", operName));
			desc.AddInput (input);
			desc.SetAttr ("block_size", block_size);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Adds two `SparseTensor` objects to produce another `SparseTensor`.
		/// </summary>
		/// <param name="a_indices">
		///   2-D.  The `indices` of the first `SparseTensor`, size `[nnz, ndims]` Matrix.
		/// </param>
		/// <param name="a_values">
		///   1-D.  The `values` of the first `SparseTensor`, size `[nnz]` Vector.
		/// </param>
		/// <param name="a_shape">
		///   1-D.  The `shape` of the first `SparseTensor`, size `[ndims]` Vector.
		/// </param>
		/// <param name="b_indices">
		///   2-D.  The `indices` of the second `SparseTensor`, size `[nnz, ndims]` Matrix.
		/// </param>
		/// <param name="b_values">
		///   1-D.  The `values` of the second `SparseTensor`, size `[nnz]` Vector.
		/// </param>
		/// <param name="b_shape">
		///   1-D.  The `shape` of the second `SparseTensor`, size `[ndims]` Vector.
		/// </param>
		/// <param name="thresh">
		///   0-D.  The magnitude threshold that determines if an output value/index
		///   pair takes space.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseAdd'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sum_indices: 
		///   sum_values: 
		///   sum_shape: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The input `SparseTensor` objects' indices are assumed ordered in standard
		///   lexicographic order.  If this is not the case, before this step run
		///   `SparseReorder` to restore index ordering.
		///   
		///   By default, if two values sum to zero at some index, the output `SparseTensor`
		///   would still include that particular location in its index, storing a zero in the
		///   corresponding value slot.  To override this, callers can specify `thresh`,
		///   indicating that if the sum has a magnitude strictly smaller than `thresh`, its
		///   corresponding value and index would then not be included.  In particular,
		///   `thresh == 0` (default) means everything is kept and actual thresholding happens
		///   only for a positive value.
		///   
		///   In the following shapes, `nnz` is the count after taking `thresh` into account.
		/// </remarks>
		public (TFOutput sum_indices, TFOutput sum_values, TFOutput sum_shape) SparseAdd (TFOutput a_indices, TFOutput a_values, TFOutput a_shape, TFOutput b_indices, TFOutput b_values, TFOutput b_shape, TFOutput thresh, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseAdd", MakeName ("SparseAdd", operName));
			desc.AddInput (a_indices);
			desc.AddInput (a_values);
			desc.AddInput (a_shape);
			desc.AddInput (b_indices);
			desc.AddInput (b_values);
			desc.AddInput (b_shape);
			desc.AddInput (thresh);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sum_indices = new TFOutput (op, _idx++);
			var sum_values = new TFOutput (op, _idx++);
			var sum_shape = new TFOutput (op, _idx++);
			return (sum_indices, sum_values, sum_shape);
		}

		/// <summary>
		///   The gradient operator for the SparseAdd op.
		/// </summary>
		/// <param name="backprop_val_grad">
		///   1-D with shape `[nnz(sum)]`.  The gradient with respect to
		///   the non-empty values of the sum.
		/// </param>
		/// <param name="a_indices">
		///   2-D.  The `indices` of the `SparseTensor` A, size `[nnz(A), ndims]`.
		/// </param>
		/// <param name="b_indices">
		///   2-D.  The `indices` of the `SparseTensor` B, size `[nnz(B), ndims]`.
		/// </param>
		/// <param name="sum_indices">
		///   2-D.  The `indices` of the sum `SparseTensor`, size
		///   `[nnz(sum), ndims]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseAddGrad'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   a_val_grad: 1-D with shape `[nnz(A)]`. The gradient with respect to the
		///   non-empty values of A.
		///   b_val_grad: 1-D with shape `[nnz(B)]`. The gradient with respect to the
		///   non-empty values of B.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The SparseAdd op calculates A + B, where A, B, and the sum are all represented
		///   as `SparseTensor` objects.  This op takes in the upstream gradient w.r.t.
		///   non-empty values of the sum, and outputs the gradients w.r.t. the non-empty
		///   values of A and B.
		/// </remarks>
		public (TFOutput a_val_grad, TFOutput b_val_grad) SparseAddGrad (TFOutput backprop_val_grad, TFOutput a_indices, TFOutput b_indices, TFOutput sum_indices, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseAddGrad", MakeName ("SparseAddGrad", operName));
			desc.AddInput (backprop_val_grad);
			desc.AddInput (a_indices);
			desc.AddInput (b_indices);
			desc.AddInput (sum_indices);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var a_val_grad = new TFOutput (op, _idx++);
			var b_val_grad = new TFOutput (op, _idx++);
			return (a_val_grad, b_val_grad);
		}

		/// <summary>
		///   Concatenates a list of `SparseTensor` along the specified dimension.
		/// </summary>
		/// <param name="indices">
		///   2-D.  Indices of each input `SparseTensor`.
		/// </param>
		/// <param name="values">
		///   1-D.  Non-empty values of each `SparseTensor`.
		/// </param>
		/// <param name="shapes">
		///   1-D.  Shapes of each `SparseTensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseConcat'.
		/// </param>
		/// <param name="concat_dim">
		///   Dimension to concatenate along. Must be in range [-rank, rank),
		///   where rank is the number of dimensions in each input `SparseTensor`.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  Indices of the concatenated `SparseTensor`.
		///   output_values: 1-D.  Non-empty values of the concatenated `SparseTensor`.
		///   output_shape: 1-D.  Shape of the concatenated `SparseTensor`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Concatenation is with respect to the dense versions of these sparse tensors.
		///   It is assumed that each input is a `SparseTensor` whose elements are ordered
		///   along increasing dimension number.
		///   
		///   All inputs' shapes must match, except for the concat dimension.  The
		///   `indices`, `values`, and `shapes` lists must have the same length.
		///   
		///   The output shape is identical to the inputs', except along the concat
		///   dimension, where it is the sum of the inputs' sizes along that dimension.
		///   
		///   The output elements will be resorted to preserve the sort order along
		///   increasing dimension number.
		///   
		///   This op runs in `O(M log M)` time, where `M` is the total number of non-empty
		///   values across all inputs. This is due to the need for an internal sort in
		///   order to concatenate efficiently across an arbitrary dimension.
		///   
		///   For example, if `concat_dim = 1` and the inputs are
		///   
		///       sp_inputs[0]: shape = [2, 3]
		///       [0, 2]: "a"
		///       [1, 0]: "b"
		///       [1, 1]: "c"
		///   
		///       sp_inputs[1]: shape = [2, 4]
		///       [0, 1]: "d"
		///       [0, 2]: "e"
		///   
		///   then the output will be
		///   
		///       shape = [2, 7]
		///       [0, 2]: "a"
		///       [0, 4]: "d"
		///       [0, 5]: "e"
		///       [1, 0]: "b"
		///       [1, 1]: "c"
		///   
		///   Graphically this is equivalent to doing
		///   
		///       [    a] concat [  d e  ] = [    a   d e  ]
		///       [b c  ]        [       ]   [b c          ]
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values, TFOutput output_shape) SparseConcat (TFOutput[] indices, TFOutput[] values, TFOutput[] shapes, long concat_dim, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseConcat", MakeName ("SparseConcat", operName));
			desc.AddInputs (indices);
			desc.AddInputs (values);
			desc.AddInputs (shapes);
			desc.SetAttr ("concat_dim", concat_dim);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			var output_shape = new TFOutput (op, _idx++);
			return (output_indices, output_values, output_shape);
		}

		/// <summary>
		///   Generates sparse cross from a list of sparse and dense tensors.
		/// </summary>
		/// <param name="indices">
		///   2-D.  Indices of each input `SparseTensor`.
		/// </param>
		/// <param name="values">
		///   1-D.   values of each `SparseTensor`.
		/// </param>
		/// <param name="shapes">
		///   1-D.   Shapes of each `SparseTensor`.
		/// </param>
		/// <param name="dense_inputs">
		///   2-D.    Columns represented by dense `Tensor`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseCross'.
		/// </param>
		/// <param name="hashed_output">
		///   If true, returns the hash of the cross instead of the string.
		///   This will allow us avoiding string manipulations.
		/// </param>
		/// <param name="num_buckets">
		///   It is used if hashed_output is true.
		///   output = hashed_value%num_buckets if num_buckets &amp;gt; 0 else hashed_value.
		/// </param>
		/// <param name="hash_key">
		///   Specify the hash_key that will be used by the `FingerprintCat64`
		///   function to combine the crosses fingerprints.
		/// </param>
		/// <param name="out_type">
		/// </param>
		/// <param name="internal_type">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  Indices of the concatenated `SparseTensor`.
		///   output_values: 1-D.  Non-empty values of the concatenated or hashed
		///   `SparseTensor`.
		///   output_shape: 1-D.  Shape of the concatenated `SparseTensor`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The op takes two lists, one of 2D `SparseTensor` and one of 2D `Tensor`, each
		///   representing features of one feature column. It outputs a 2D `SparseTensor` with
		///   the batchwise crosses of these features.
		///   
		///   For example, if the inputs are
		///   
		///       inputs[0]: SparseTensor with shape = [2, 2]
		///       [0, 0]: "a"
		///       [1, 0]: "b"
		///       [1, 1]: "c"
		///   
		///       inputs[1]: SparseTensor with shape = [2, 1]
		///       [0, 0]: "d"
		///       [1, 0]: "e"
		///   
		///       inputs[2]: Tensor [["f"], ["g"]]
		///   
		///   then the output will be
		///   
		///       shape = [2, 2]
		///       [0, 0]: "a_X_d_X_f"
		///       [1, 0]: "b_X_e_X_g"
		///       [1, 1]: "c_X_e_X_g"
		///   
		///   if hashed_output=true then the output will be
		///   
		///       shape = [2, 2]
		///       [0, 0]: FingerprintCat64(
		///                   Fingerprint64("f"), FingerprintCat64(
		///                       Fingerprint64("d"), Fingerprint64("a")))
		///       [1, 0]: FingerprintCat64(
		///                   Fingerprint64("g"), FingerprintCat64(
		///                       Fingerprint64("e"), Fingerprint64("b")))
		///       [1, 1]: FingerprintCat64(
		///                   Fingerprint64("g"), FingerprintCat64(
		///                       Fingerprint64("e"), Fingerprint64("c")))
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values, TFOutput output_shape) SparseCross (TFOutput[] indices, TFOutput[] values, TFOutput[] shapes, TFOutput[] dense_inputs, bool hashed_output, long num_buckets, long hash_key, TFDataType out_type, TFDataType internal_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseCross", MakeName ("SparseCross", operName));
			desc.AddInputs (indices);
			desc.AddInputs (values);
			desc.AddInputs (shapes);
			desc.AddInputs (dense_inputs);
			desc.SetAttr ("hashed_output", hashed_output);
			desc.SetAttr ("num_buckets", num_buckets);
			desc.SetAttr ("hash_key", hash_key);
			desc.SetAttrType ("out_type", out_type);
			desc.SetAttrType ("internal_type", internal_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			var output_shape = new TFOutput (op, _idx++);
			return (output_indices, output_values, output_shape);
		}

		/// <summary>
		///   Adds up a SparseTensor and a dense Tensor, using these special rules:
		/// </summary>
		/// <param name="sp_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="sp_values">
		///   1-D.  `N` non-empty values corresponding to `sp_indices`.
		/// </param>
		/// <param name="sp_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="dense">
		///   `R`-D.  The dense Tensor operand.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseDenseCwiseAdd'.
		/// </param>
		/// <returns>
		///   1-D.  The `N` values that are operated on.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   (1) Broadcasts the dense side to have the same shape as the sparse side, if
		///       eligible;
		///   (2) Then, only the dense values pointed to by the indices of the SparseTensor
		///       participate in the cwise addition.
		///   
		///   By these rules, the result is a logical SparseTensor with exactly the same
		///   indices and shape, but possibly with different non-zero values.  The output of
		///   this Op is the resultant non-zero values.
		/// </remarks>
		public TFOutput SparseDenseCwiseAdd (TFOutput sp_indices, TFOutput sp_values, TFOutput sp_shape, TFOutput dense, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseDenseCwiseAdd", MakeName ("SparseDenseCwiseAdd", operName));
			desc.AddInput (sp_indices);
			desc.AddInput (sp_values);
			desc.AddInput (sp_shape);
			desc.AddInput (dense);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Component-wise divides a SparseTensor by a dense Tensor.
		/// </summary>
		/// <param name="sp_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="sp_values">
		///   1-D.  `N` non-empty values corresponding to `sp_indices`.
		/// </param>
		/// <param name="sp_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="dense">
		///   `R`-D.  The dense Tensor operand.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseDenseCwiseDiv'.
		/// </param>
		/// <returns>
		///   1-D.  The `N` values that are operated on.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *Limitation*: this Op only broadcasts the dense side to the sparse side, but not
		///   the other direction.
		/// </remarks>
		public TFOutput SparseDenseCwiseDiv (TFOutput sp_indices, TFOutput sp_values, TFOutput sp_shape, TFOutput dense, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseDenseCwiseDiv", MakeName ("SparseDenseCwiseDiv", operName));
			desc.AddInput (sp_indices);
			desc.AddInput (sp_values);
			desc.AddInput (sp_shape);
			desc.AddInput (dense);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Component-wise multiplies a SparseTensor by a dense Tensor.
		/// </summary>
		/// <param name="sp_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="sp_values">
		///   1-D.  `N` non-empty values corresponding to `sp_indices`.
		/// </param>
		/// <param name="sp_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="dense">
		///   `R`-D.  The dense Tensor operand.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseDenseCwiseMul'.
		/// </param>
		/// <returns>
		///   1-D.  The `N` values that are operated on.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The output locations corresponding to the implicitly zero elements in the sparse
		///   tensor will be zero (i.e., will not take up storage space), regardless of the
		///   contents of the dense tensor (even if it's +/-INF and that INF*0 == NaN).
		///   
		///   *Limitation*: this Op only broadcasts the dense side to the sparse side, but not
		///   the other direction.
		/// </remarks>
		public TFOutput SparseDenseCwiseMul (TFOutput sp_indices, TFOutput sp_values, TFOutput sp_shape, TFOutput dense, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseDenseCwiseMul", MakeName ("SparseDenseCwiseMul", operName));
			desc.AddInput (sp_indices);
			desc.AddInput (sp_values);
			desc.AddInput (sp_shape);
			desc.AddInput (dense);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Multiply matrix "a" by matrix "b".
		/// </summary>
		/// <param name="a">
		/// </param>
		/// <param name="b">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseMatMul'.
		/// </param>
		/// <param name="transpose_a">
		///   Optional argument
		/// </param>
		/// <param name="transpose_b">
		///   Optional argument
		/// </param>
		/// <param name="a_is_sparse">
		///   Optional argument
		/// </param>
		/// <param name="b_is_sparse">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The inputs must be two-dimensional matrices and the inner dimension of "a" must
		///   match the outer dimension of "b". This op is optimized for the case where at
		///   least one of "a" or "b" is sparse. The breakeven for using this versus a dense
		///   matrix multiply on one platform was 30% zero values in the sparse matrix.
		/// </remarks>
		public TFOutput SparseMatMul (TFOutput a, TFOutput b, bool? transpose_a = null, bool? transpose_b = null, bool? a_is_sparse = null, bool? b_is_sparse = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseMatMul", MakeName ("SparseMatMul", operName));
			desc.AddInput (a);
			desc.AddInput (b);
			if (transpose_a.HasValue)
				desc.SetAttr ("transpose_a", transpose_a.Value);
			
			if (transpose_b.HasValue)
				desc.SetAttr ("transpose_b", transpose_b.Value);
			
			if (a_is_sparse.HasValue)
				desc.SetAttr ("a_is_sparse", a_is_sparse.Value);
			
			if (b_is_sparse.HasValue)
				desc.SetAttr ("b_is_sparse", b_is_sparse.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var product = new TFOutput (op, _idx++);
			return product;
		}

		/// <summary>
		///   Computes the sum of elements across dimensions of a SparseTensor.
		/// </summary>
		/// <param name="input_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="input_values">
		///   1-D.  `N` non-empty values corresponding to `input_indices`.
		/// </param>
		/// <param name="input_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="reduction_axes">
		///   1-D.  Length-`K` vector containing the reduction axes.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseReduceSum'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   `R-K`-D.  The reduced Tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This Op takes a SparseTensor and is the sparse counterpart to
		///   `tf.reduce_sum()`.  In particular, this Op also returns a dense `Tensor`
		///   instead of a sparse one.
		///   
		///   Reduces `sp_input` along the dimensions given in `reduction_axes`.  Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_axes`. If `keep_dims` is true, the reduced dimensions are retained
		///   with length 1.
		///   
		///   If `reduction_axes` has no entries, all dimensions are reduced, and a tensor
		///   with a single element is returned.  Additionally, the axes can be negative,
		///   which are interpreted according to the indexing rules in Python.
		/// </remarks>
		public TFOutput SparseReduceSum (TFOutput input_indices, TFOutput input_values, TFOutput input_shape, TFOutput reduction_axes, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseReduceSum", MakeName ("SparseReduceSum", operName));
			desc.AddInput (input_indices);
			desc.AddInput (input_values);
			desc.AddInput (input_shape);
			desc.AddInput (reduction_axes);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum of elements across dimensions of a SparseTensor.
		/// </summary>
		/// <param name="input_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="input_values">
		///   1-D.  `N` non-empty values corresponding to `input_indices`.
		/// </param>
		/// <param name="input_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="reduction_axes">
		///   1-D.  Length-`K` vector containing the reduction axes.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseReduceSumSparse'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 
		///   output_values: 
		///   output_shape: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This Op takes a SparseTensor and is the sparse counterpart to
		///   `tf.reduce_sum()`.  In contrast to SparseReduceSum, this Op returns a
		///   SparseTensor.
		///   
		///   Reduces `sp_input` along the dimensions given in `reduction_axes`.  Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_axes`. If `keep_dims` is true, the reduced dimensions are retained
		///   with length 1.
		///   
		///   If `reduction_axes` has no entries, all dimensions are reduced, and a tensor
		///   with a single element is returned.  Additionally, the axes can be negative,
		///   which are interpreted according to the indexing rules in Python.
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values, TFOutput output_shape) SparseReduceSumSparse (TFOutput input_indices, TFOutput input_values, TFOutput input_shape, TFOutput reduction_axes, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseReduceSumSparse", MakeName ("SparseReduceSumSparse", operName));
			desc.AddInput (input_indices);
			desc.AddInput (input_values);
			desc.AddInput (input_shape);
			desc.AddInput (reduction_axes);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			var output_shape = new TFOutput (op, _idx++);
			return (output_indices, output_values, output_shape);
		}

		/// <summary>
		///   Reorders a SparseTensor into the canonical, row-major ordering.
		/// </summary>
		/// <param name="input_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, possibly not in canonical ordering.
		/// </param>
		/// <param name="input_values">
		///   1-D.  `N` non-empty values corresponding to `input_indices`.
		/// </param>
		/// <param name="input_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseReorder'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  `N x R` matrix with the same indices as input_indices, but
		///   in canonical row-major ordering.
		///   output_values: 1-D.  `N` non-empty values corresponding to `output_indices`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Note that by convention, all sparse ops preserve the canonical ordering along
		///   increasing dimension number. The only time ordering can be violated is during
		///   manual manipulation of the indices and values vectors to add entries.
		///   
		///   Reordering does not affect the shape of the SparseTensor.
		///   
		///   If the tensor has rank `R` and `N` non-empty values, `input_indices` has
		///   shape `[N, R]`, input_values has length `N`, and input_shape has length `R`.
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values) SparseReorder (TFOutput input_indices, TFOutput input_values, TFOutput input_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseReorder", MakeName ("SparseReorder", operName));
			desc.AddInput (input_indices);
			desc.AddInput (input_values);
			desc.AddInput (input_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			return (output_indices, output_values);
		}

		/// <summary>
		///   Reshapes a SparseTensor to represent values in a new dense shape.
		/// </summary>
		/// <param name="input_indices">
		///   2-D.  `N x R_in` matrix with the indices of non-empty values in a
		///   SparseTensor.
		/// </param>
		/// <param name="input_shape">
		///   1-D.  `R_in` vector with the input SparseTensor's dense shape.
		/// </param>
		/// <param name="new_shape">
		///   1-D.  `R_out` vector with the requested new dense shape.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseReshape'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  `N x R_out` matrix with the updated indices of non-empty
		///   values in the output SparseTensor.
		///   output_shape: 1-D.  `R_out` vector with the full dense shape of the output
		///   SparseTensor.  This is the same as `new_shape` but with any -1 dimensions
		///   filled in.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This operation has the same semantics as reshape on the represented dense
		///   tensor.  The `input_indices` are recomputed based on the requested `new_shape`.
		///   
		///   If one component of `new_shape` is the special value -1, the size of that
		///   dimension is computed so that the total dense size remains constant.  At
		///   most one component of `new_shape` can be -1.  The number of dense elements
		///   implied by `new_shape` must be the same as the number of dense elements
		///   originally implied by `input_shape`.
		///   
		///   Reshaping does not affect the order of values in the SparseTensor.
		///   
		///   If the input tensor has rank `R_in` and `N` non-empty values, and `new_shape`
		///   has length `R_out`, then `input_indices` has shape `[N, R_in]`,
		///   `input_shape` has length `R_in`, `output_indices` has shape `[N, R_out]`, and
		///   `output_shape` has length `R_out`.
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_shape) SparseReshape (TFOutput input_indices, TFOutput input_shape, TFOutput new_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseReshape", MakeName ("SparseReshape", operName));
			desc.AddInput (input_indices);
			desc.AddInput (input_shape);
			desc.AddInput (new_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_shape = new TFOutput (op, _idx++);
			return (output_indices, output_shape);
		}

		/// <summary>
		///   Computes the mean along sparse segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="indices">
		///   A 1-D tensor. Has same rank as `segment_ids`.
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor. Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSegmentMean'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Like `SegmentMean`, but `segment_ids` can have rank less than `data`'s first
		///   dimension, selecting a subset of dimension 0, specified by `indices`.
		/// </remarks>
		public TFOutput SparseSegmentMean (TFOutput data, TFOutput indices, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSegmentMean", MakeName ("SparseSegmentMean", operName));
			desc.AddInput (data);
			desc.AddInput (indices);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients for SparseSegmentMean.
		/// </summary>
		/// <param name="grad">
		///   gradient propagated to the SparseSegmentMean op.
		/// </param>
		/// <param name="indices">
		///   indices passed to the corresponding SparseSegmentMean op.
		/// </param>
		/// <param name="segment_ids">
		///   segment_ids passed to the corresponding SparseSegmentMean op.
		/// </param>
		/// <param name="output_dim0">
		///   dimension 0 of "data" passed to SparseSegmentMean op.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSegmentMeanGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Returns tensor "output" with same shape as grad, except for dimension 0 whose
		///   value is output_dim0.
		/// </remarks>
		public TFOutput SparseSegmentMeanGrad (TFOutput grad, TFOutput indices, TFOutput segment_ids, TFOutput output_dim0, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSegmentMeanGrad", MakeName ("SparseSegmentMeanGrad", operName));
			desc.AddInput (grad);
			desc.AddInput (indices);
			desc.AddInput (segment_ids);
			desc.AddInput (output_dim0);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum along sparse segments of a tensor divided by the sqrt of N.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="indices">
		///   A 1-D tensor. Has same rank as `segment_ids`.
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor. Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSegmentSqrtN'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   N is the size of the segment being reduced.
		///   
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		/// </remarks>
		public TFOutput SparseSegmentSqrtN (TFOutput data, TFOutput indices, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSegmentSqrtN", MakeName ("SparseSegmentSqrtN", operName));
			desc.AddInput (data);
			desc.AddInput (indices);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes gradients for SparseSegmentSqrtN.
		/// </summary>
		/// <param name="grad">
		///   gradient propagated to the SparseSegmentSqrtN op.
		/// </param>
		/// <param name="indices">
		///   indices passed to the corresponding SparseSegmentSqrtN op.
		/// </param>
		/// <param name="segment_ids">
		///   segment_ids passed to the corresponding SparseSegmentSqrtN op.
		/// </param>
		/// <param name="output_dim0">
		///   dimension 0 of "data" passed to SparseSegmentSqrtN op.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSegmentSqrtNGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Returns tensor "output" with same shape as grad, except for dimension 0 whose
		///   value is output_dim0.
		/// </remarks>
		public TFOutput SparseSegmentSqrtNGrad (TFOutput grad, TFOutput indices, TFOutput segment_ids, TFOutput output_dim0, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSegmentSqrtNGrad", MakeName ("SparseSegmentSqrtNGrad", operName));
			desc.AddInput (grad);
			desc.AddInput (indices);
			desc.AddInput (segment_ids);
			desc.AddInput (output_dim0);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum along sparse segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="indices">
		///   A 1-D tensor. Has same rank as `segment_ids`.
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor. Values should be sorted and can be repeated.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSegmentSum'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `k`, the number of segments.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Like `SegmentSum`, but `segment_ids` can have rank less than `data`'s first
		///   dimension, selecting a subset of dimension 0, specified by `indices`.
		///   
		///   For example:
		///   
		///   ```prettyprint
		///   c = tf.constant([[1,2,3,4], [-1,-2,-3,-4], [5,6,7,8]])
		///   
		///   # Select two rows, one segment.
		///   tf.sparse_segment_sum(c, tf.constant([0, 1]), tf.constant([0, 0]))
		///     ==&amp;gt; [[0 0 0 0]]
		///   
		///   # Select two rows, two segment.
		///   tf.sparse_segment_sum(c, tf.constant([0, 1]), tf.constant([0, 1]))
		///     ==&amp;gt; [[ 1  2  3  4]
		///          [-1 -2 -3 -4]]
		///   
		///   # Select all rows, two segments.
		///   tf.sparse_segment_sum(c, tf.constant([0, 1, 2]), tf.constant([0, 0, 1]))
		///     ==&amp;gt; [[0 0 0 0]
		///          [5 6 7 8]]
		///   
		///   # Which is equivalent to:
		///   tf.segment_sum(c, tf.constant([0, 0, 1]))
		///   ```
		/// </remarks>
		public TFOutput SparseSegmentSum (TFOutput data, TFOutput indices, TFOutput segment_ids, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSegmentSum", MakeName ("SparseSegmentSum", operName));
			desc.AddInput (data);
			desc.AddInput (indices);
			desc.AddInput (segment_ids);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Applies softmax to a batched N-D `SparseTensor`.
		/// </summary>
		/// <param name="sp_indices">
		///   2-D.  `NNZ x R` matrix with the indices of non-empty values in a
		///   SparseTensor, in canonical ordering.
		/// </param>
		/// <param name="sp_values">
		///   1-D.  `NNZ` non-empty values corresponding to `sp_indices`.
		/// </param>
		/// <param name="sp_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSoftmax'.
		/// </param>
		/// <returns>
		///   1-D.  The `NNZ` values for the result `SparseTensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The inputs represent an N-D SparseTensor  with logical shape `[..., B, C]`
		///   (where `N &amp;gt;= 2`), and with indices sorted in the canonical lexicographic order.
		///   
		///   This op is equivalent to applying the normal `tf.nn.softmax()` to each innermost
		///   logical submatrix with shape `[B, C]`, but with the catch that *the implicitly
		///   zero elements do not participate*.  Specifically, the algorithm is equivalent
		///   to the following:
		///   
		///     (1) Applies `tf.nn.softmax()` to a densified view of each innermost submatrix
		///         with shape `[B, C]`, along the size-C dimension;
		///     (2) Masks out the original implicitly-zero locations;
		///     (3) Renormalizes the remaining elements.
		///   
		///   Hence, the `SparseTensor` result has exactly the same non-zero indices and
		///   shape.
		/// </remarks>
		public TFOutput SparseSoftmax (TFOutput sp_indices, TFOutput sp_values, TFOutput sp_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSoftmax", MakeName ("SparseSoftmax", operName));
			desc.AddInput (sp_indices);
			desc.AddInput (sp_values);
			desc.AddInput (sp_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes softmax cross entropy cost and gradients to backpropagate.
		/// </summary>
		/// <param name="features">
		///   batch_size x num_classes matrix
		/// </param>
		/// <param name="labels">
		///   batch_size vector with values in [0, num_classes).
		///   This is the label for the given minibatch entry.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSoftmaxCrossEntropyWithLogits'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   loss: Per example loss (batch_size vector).
		///   backprop: backpropagated gradients (batch_size x num_classes matrix).
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Unlike `SoftmaxCrossEntropyWithLogits`, this operation does not accept
		///   a matrix of label probabilities, but rather a single label per row
		///   of features.  This label is considered to have probability 1.0 for the
		///   given row.
		///   
		///   Inputs are the logits, not probabilities.
		/// </remarks>
		public (TFOutput loss, TFOutput backprop) SparseSoftmaxCrossEntropyWithLogits (TFOutput features, TFOutput labels, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSoftmaxCrossEntropyWithLogits", MakeName ("SparseSoftmaxCrossEntropyWithLogits", operName));
			desc.AddInput (features);
			desc.AddInput (labels);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var loss = new TFOutput (op, _idx++);
			var backprop = new TFOutput (op, _idx++);
			return (loss, backprop);
		}

		/// <summary>
		///   Returns the element-wise max of two SparseTensors.
		/// </summary>
		/// <param name="a_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, in the canonical lexicographic ordering.
		/// </param>
		/// <param name="a_values">
		///   1-D.  `N` non-empty values corresponding to `a_indices`.
		/// </param>
		/// <param name="a_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="b_indices">
		///   counterpart to `a_indices` for the other operand.
		/// </param>
		/// <param name="b_values">
		///   counterpart to `a_values` for the other operand; must be of the same dtype.
		/// </param>
		/// <param name="b_shape">
		///   counterpart to `a_shape` for the other operand; the two shapes must be equal.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSparseMaximum'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  The indices of the output SparseTensor.
		///   output_values: 1-D.  The values of the output SparseTensor.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Assumes the two SparseTensors have the same shape, i.e., no broadcasting.
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values) SparseSparseMaximum (TFOutput a_indices, TFOutput a_values, TFOutput a_shape, TFOutput b_indices, TFOutput b_values, TFOutput b_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSparseMaximum", MakeName ("SparseSparseMaximum", operName));
			desc.AddInput (a_indices);
			desc.AddInput (a_values);
			desc.AddInput (a_shape);
			desc.AddInput (b_indices);
			desc.AddInput (b_values);
			desc.AddInput (b_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			return (output_indices, output_values);
		}

		/// <summary>
		///   Returns the element-wise min of two SparseTensors.
		/// </summary>
		/// <param name="a_indices">
		///   2-D.  `N x R` matrix with the indices of non-empty values in a
		///   SparseTensor, in the canonical lexicographic ordering.
		/// </param>
		/// <param name="a_values">
		///   1-D.  `N` non-empty values corresponding to `a_indices`.
		/// </param>
		/// <param name="a_shape">
		///   1-D.  Shape of the input SparseTensor.
		/// </param>
		/// <param name="b_indices">
		///   counterpart to `a_indices` for the other operand.
		/// </param>
		/// <param name="b_values">
		///   counterpart to `a_values` for the other operand; must be of the same dtype.
		/// </param>
		/// <param name="b_shape">
		///   counterpart to `a_shape` for the other operand; the two shapes must be equal.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSparseMinimum'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 2-D.  The indices of the output SparseTensor.
		///   output_values: 1-D.  The values of the output SparseTensor.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Assumes the two SparseTensors have the same shape, i.e., no broadcasting.
		/// </remarks>
		public (TFOutput output_indices, TFOutput output_values) SparseSparseMinimum (TFOutput a_indices, TFOutput a_values, TFOutput a_shape, TFOutput b_indices, TFOutput b_values, TFOutput b_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSparseMinimum", MakeName ("SparseSparseMinimum", operName));
			desc.AddInput (a_indices);
			desc.AddInput (a_values);
			desc.AddInput (a_shape);
			desc.AddInput (b_indices);
			desc.AddInput (b_values);
			desc.AddInput (b_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_indices = new TFOutput (op, _idx++);
			var output_values = new TFOutput (op, _idx++);
			return (output_indices, output_values);
		}

		/// <summary>
		///   Split a `SparseTensor` into `num_split` tensors along one dimension.
		/// </summary>
		/// <param name="split_dim">
		///   0-D.  The dimension along which to split.  Must be in the range
		///   `[0, rank(shape))`.
		/// </param>
		/// <param name="indices">
		///   2-D tensor represents the indices of the sparse tensor.
		/// </param>
		/// <param name="values">
		///   1-D tensor represents the values of the sparse tensor.
		/// </param>
		/// <param name="shape">
		///   1-D. tensor represents the shape of the sparse tensor.
		///   output indices: A list of 1-D tensors represents the indices of the output
		///   sparse tensors.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseSplit'.
		/// </param>
		/// <param name="num_split">
		///   The number of ways to split.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_indices: 
		///   output_values: A list of 1-D tensors represents the values of the output sparse
		///   tensors.
		///   output_shape: A list of 1-D tensors represents the shape of the output sparse
		///   tensors.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   If the `shape[split_dim]` is not an integer multiple of `num_split`. Slices
		///   `[0 : shape[split_dim] % num_split]` gets one extra dimension.
		///   For example, if `split_dim = 1` and `num_split = 2` and the input is
		///   
		///       input_tensor = shape = [2, 7]
		///       [    a   d e  ]
		///       [b c          ]
		///   
		///   Graphically the output tensors are:
		///   
		///       output_tensor[0] = shape = [2, 4]
		///       [    a  ]
		///       [b c    ]
		///   
		///       output_tensor[1] = shape = [2, 3]
		///       [ d e  ]
		///       [      ]
		/// </remarks>
		public (TFOutput[] output_indices, TFOutput[] output_values, TFOutput[] output_shape) SparseSplit (TFOutput split_dim, TFOutput indices, TFOutput values, TFOutput shape, long num_split, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseSplit", MakeName ("SparseSplit", operName));
			desc.AddInput (split_dim);
			desc.AddInput (indices);
			desc.AddInput (values);
			desc.AddInput (shape);
			desc.SetAttr ("num_split", num_split);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output_indices");
			var output_indices = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output_indices [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("output_values");
			var output_values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output_values [i] = new TFOutput (op, _idx++);
			
			_n = op.OutputListLength ("output_shape");
			var output_shape = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output_shape [i] = new TFOutput (op, _idx++);
			
			return (output_indices, output_values, output_shape);
		}

		/// <summary>
		///   Adds up a `SparseTensor` and a dense `Tensor`, producing a dense `Tensor`.
		/// </summary>
		/// <param name="a_indices">
		///   2-D.  The `indices` of the `SparseTensor`, with shape `[nnz, ndims]`.
		/// </param>
		/// <param name="a_values">
		///   1-D.  The `values` of the `SparseTensor`, with shape `[nnz]`.
		/// </param>
		/// <param name="a_shape">
		///   1-D.  The `shape` of the `SparseTensor`, with shape `[ndims]`.
		/// </param>
		/// <param name="b">
		///   `ndims`-D Tensor.  With shape `a_shape`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseTensorDenseAdd'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This Op does not require `a_indices` be sorted in standard lexicographic order.
		/// </remarks>
		public TFOutput SparseTensorDenseAdd (TFOutput a_indices, TFOutput a_values, TFOutput a_shape, TFOutput b, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseTensorDenseAdd", MakeName ("SparseTensorDenseAdd", operName));
			desc.AddInput (a_indices);
			desc.AddInput (a_values);
			desc.AddInput (a_shape);
			desc.AddInput (b);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Multiply SparseTensor (of rank 2) "A" by dense matrix "B".
		/// </summary>
		/// <param name="a_indices">
		///   2-D.  The `indices` of the `SparseTensor`, size `[nnz, 2]` Matrix.
		/// </param>
		/// <param name="a_values">
		///   1-D.  The `values` of the `SparseTensor`, size `[nnz]` Vector.
		/// </param>
		/// <param name="a_shape">
		///   1-D.  The `shape` of the `SparseTensor`, size `[2]` Vector.
		/// </param>
		/// <param name="b">
		///   2-D.  A dense Matrix.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseTensorDenseMatMul'.
		/// </param>
		/// <param name="adjoint_a">
		///   Optional argument
		///   Use the adjoint of A in the matrix multiply.  If A is complex, this
		///   is transpose(conj(A)).  Otherwise it's transpose(A).
		/// </param>
		/// <param name="adjoint_b">
		///   Optional argument
		///   Use the adjoint of B in the matrix multiply.  If B is complex, this
		///   is transpose(conj(B)).  Otherwise it's transpose(B).
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   No validity checking is performed on the indices of A.  However, the following
		///   input format is recommended for optimal behavior:
		///   
		///   if adjoint_a == false:
		///     A should be sorted in lexicographically increasing order.  Use SparseReorder
		///     if you're not sure.
		///   if adjoint_a == true:
		///     A should be sorted in order of increasing dimension 1 (i.e., "column major"
		///     order instead of "row major" order).
		/// </remarks>
		public TFOutput SparseTensorDenseMatMul (TFOutput a_indices, TFOutput a_values, TFOutput a_shape, TFOutput b, bool? adjoint_a = null, bool? adjoint_b = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseTensorDenseMatMul", MakeName ("SparseTensorDenseMatMul", operName));
			desc.AddInput (a_indices);
			desc.AddInput (a_values);
			desc.AddInput (a_shape);
			desc.AddInput (b);
			if (adjoint_a.HasValue)
				desc.SetAttr ("adjoint_a", adjoint_a.Value);
			
			if (adjoint_b.HasValue)
				desc.SetAttr ("adjoint_b", adjoint_b.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var product = new TFOutput (op, _idx++);
			return product;
		}

		/// <summary>
		///   Creates a dataset that splits a SparseTensor into elements row-wise.
		/// </summary>
		/// <param name="indices">
		/// </param>
		/// <param name="values">
		/// </param>
		/// <param name="dense_shape">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseTensorSliceDataset'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput SparseTensorSliceDataset (TFOutput indices, TFOutput values, TFOutput dense_shape, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseTensorSliceDataset", MakeName ("SparseTensorSliceDataset", operName));
			desc.AddInput (indices);
			desc.AddInput (values);
			desc.AddInput (dense_shape);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Converts a sparse representation into a dense tensor.
		/// </summary>
		/// <param name="sparse_indices">
		///   0-D, 1-D, or 2-D.  `sparse_indices[i]` contains the complete
		///   index where `sparse_values[i]` will be placed.
		/// </param>
		/// <param name="output_shape">
		///   1-D.  Shape of the dense output tensor.
		/// </param>
		/// <param name="sparse_values">
		///   1-D.  Values corresponding to each row of `sparse_indices`,
		///   or a scalar value to be used for all sparse indices.
		/// </param>
		/// <param name="default_value">
		///   Scalar value to set for indices not specified in
		///   `sparse_indices`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseToDense'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		///   If true, indices are checked to make sure they are sorted in
		///   lexicographic order and that there are no repeats.
		/// </param>
		/// <returns>
		///   Dense output tensor of shape `output_shape`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Builds an array `dense` with shape `output_shape` such that
		///   
		///   ```prettyprint
		///   # If sparse_indices is scalar
		///   dense[i] = (i == sparse_indices ? sparse_values : default_value)
		///   
		///   # If sparse_indices is a vector, then for each i
		///   dense[sparse_indices[i]] = sparse_values[i]
		///   
		///   # If sparse_indices is an n by d matrix, then for each i in [0, n)
		///   dense[sparse_indices[i][0], ..., sparse_indices[i][d-1]] = sparse_values[i]
		///   ```
		///   
		///   All other values in `dense` are set to `default_value`.  If `sparse_values` is a
		///   scalar, all sparse indices are set to this single value.
		///   
		///   Indices should be sorted in lexicographic order, and indices must not
		///   contain any repeats. If `validate_indices` is true, these properties
		///   are checked during execution.
		/// </remarks>
		public TFOutput SparseToDense (TFOutput sparse_indices, TFOutput output_shape, TFOutput sparse_values, TFOutput default_value, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseToDense", MakeName ("SparseToDense", operName));
			desc.AddInput (sparse_indices);
			desc.AddInput (output_shape);
			desc.AddInput (sparse_values);
			desc.AddInput (default_value);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var dense = new TFOutput (op, _idx++);
			return dense;
		}

		/// <summary>
		///   Applies set operation along last dimension of 2 `SparseTensor` inputs.
		/// </summary>
		/// <param name="set1_indices">
		///   2D `Tensor`, indices of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set1_values">
		///   1D `Tensor`, values of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set1_shape">
		///   1D `Tensor`, shape of a `SparseTensor`. `set1_shape[0...n-1]` must
		///   be the same as `set2_shape[0...n-1]`, `set1_shape[n]` is the
		///   max set size across `0...n-1` dimensions.
		/// </param>
		/// <param name="set2_indices">
		///   2D `Tensor`, indices of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set2_values">
		///   1D `Tensor`, values of a `SparseTensor`. Must be in row-major
		///   order.
		/// </param>
		/// <param name="set2_shape">
		///   1D `Tensor`, shape of a `SparseTensor`. `set2_shape[0...n-1]` must
		///   be the same as `set1_shape[0...n-1]`, `set2_shape[n]` is the
		///   max set size across `0...n-1` dimensions.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SparseToSparseSetOperation'.
		/// </param>
		/// <param name="validate_indices">
		///   Optional argument
		/// </param>
		/// <param name="set_operation">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   result_indices: 2D indices of a `SparseTensor`.
		///   result_values: 1D values of a `SparseTensor`.
		///   result_shape: 1D `Tensor` shape of a `SparseTensor`. `result_shape[0...n-1]` is
		///   the same as the 1st `n-1` dimensions of `set1` and `set2`, `result_shape[n]`
		///   is the max result set size across all `0...n-1` dimensions.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See SetOperationOp::SetOperationFromContext for values of `set_operation`.
		///   
		///   If `validate_indices` is `True`, `SparseToSparseSetOperation` validates the
		///   order and range of `set1` and `set2` indices.
		///   
		///   Input `set1` is a `SparseTensor` represented by `set1_indices`, `set1_values`,
		///   and `set1_shape`. For `set1` ranked `n`, 1st `n-1` dimensions must be the same
		///   as `set2`. Dimension `n` contains values in a set, duplicates are allowed but
		///   ignored.
		///   
		///   Input `set2` is a `SparseTensor` represented by `set2_indices`, `set2_values`,
		///   and `set2_shape`. For `set2` ranked `n`, 1st `n-1` dimensions must be the same
		///   as `set1`. Dimension `n` contains values in a set, duplicates are allowed but
		///   ignored.
		///   
		///   If `validate_indices` is `True`, this op validates the order and range of `set1`
		///   and `set2` indices.
		///   
		///   Output `result` is a `SparseTensor` represented by `result_indices`,
		///   `result_values`, and `result_shape`. For `set1` and `set2` ranked `n`, this
		///   has rank `n` and the same 1st `n-1` dimensions as `set1` and `set2`. The `nth`
		///   dimension contains the result of `set_operation` applied to the corresponding
		///   `[0...n-1]` dimension of `set`.
		/// </remarks>
		public (TFOutput result_indices, TFOutput result_values, TFOutput result_shape) SparseToSparseSetOperation (TFOutput set1_indices, TFOutput set1_values, TFOutput set1_shape, TFOutput set2_indices, TFOutput set2_values, TFOutput set2_shape, string set_operation, bool? validate_indices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SparseToSparseSetOperation", MakeName ("SparseToSparseSetOperation", operName));
			desc.AddInput (set1_indices);
			desc.AddInput (set1_values);
			desc.AddInput (set1_shape);
			desc.AddInput (set2_indices);
			desc.AddInput (set2_values);
			desc.AddInput (set2_shape);
			desc.SetAttr ("set_operation", set_operation);
			if (validate_indices.HasValue)
				desc.SetAttr ("validate_indices", validate_indices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var result_indices = new TFOutput (op, _idx++);
			var result_values = new TFOutput (op, _idx++);
			var result_shape = new TFOutput (op, _idx++);
			return (result_indices, result_values, result_shape);
		}

		/// <summary>
		///   Splits a tensor into `num_split` tensors along one dimension.
		/// </summary>
		/// <param name="split_dim">
		///   0-D.  The dimension along which to split.  Must be in the range
		///   `[0, rank(value))`.
		/// </param>
		/// <param name="value">
		///   The tensor to split.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Split'.
		/// </param>
		/// <param name="num_split">
		///   The number of ways to split.  Must evenly divide
		///   `value.shape[split_dim]`.
		/// </param>
		/// <returns>
		///   They are identically shaped tensors, whose shape matches that of `value`
		///   except along `split_dim`, where their sizes are
		///   `values.shape[split_dim] / num_split`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput[] Split (TFOutput split_dim, TFOutput value, long num_split, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Split", MakeName ("Split", operName));
			desc.AddInput (split_dim);
			desc.AddInput (value);
			desc.SetAttr ("num_split", num_split);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output");
			var output = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output [i] = new TFOutput (op, _idx++);
			
			return output;
		}

		/// <summary>
		///   Splits a tensor into `num_split` tensors along one dimension.
		/// </summary>
		/// <param name="value">
		///   The tensor to split.
		/// </param>
		/// <param name="size_splits">
		///   list containing the sizes of each output tensor along the split
		///   dimension. Must sum to the dimension of value along split_dim.
		///   Can contain one -1 indicating that dimension is to be inferred.
		/// </param>
		/// <param name="split_dim">
		///   0-D.  The dimension along which to split.  Must be in the range
		///   `[0, rank(value))`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SplitV'.
		/// </param>
		/// <param name="num_split">
		/// </param>
		/// <returns>
		///   Tensors whose shape matches that of `value`
		///   except along `split_dim`, where their sizes are
		///   `size_splits[i]`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput[] SplitV (TFOutput value, TFOutput size_splits, TFOutput split_dim, long num_split, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SplitV", MakeName ("SplitV", operName));
			desc.AddInput (value);
			desc.AddInput (size_splits);
			desc.AddInput (split_dim);
			desc.SetAttr ("num_split", num_split);
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output");
			var output = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output [i] = new TFOutput (op, _idx++);
			
			return output;
		}

		/// <summary>
		///   Computes square root of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sqrt'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = \sqrt{x} = x^{1/2}\\).
		/// </remarks>
		public TFOutput Sqrt (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sqrt", MakeName ("Sqrt", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient for the sqrt of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SqrtGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = dy * 0.5 / y`, where `y = sqrt(x)`, and `dy`
		///   is the corresponding input gradient.
		/// </remarks>
		public TFOutput SqrtGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SqrtGrad", MakeName ("SqrtGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Computes square of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Square'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   I.e., \\(y = x * x = x^2\\).
		/// </remarks>
		public TFOutput Square (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Square", MakeName ("Square", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns (x - y)(x - y) element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'SquaredDifference'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `SquaredDifference` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput SquaredDifference (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "SquaredDifference", MakeName ("SquaredDifference", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Removes dimensions of size 1 from the shape of a tensor.
		/// </summary>
		/// <param name="input">
		///   The `input` to squeeze.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Squeeze'.
		/// </param>
		/// <param name="squeeze_dims">
		///   Optional argument
		///   If specified, only squeezes the dimensions listed. The dimension
		///   index starts at 0. It is an error to squeeze a dimension that is not 1.
		/// </param>
		/// <returns>
		///   Contains the same data as `input`, but has one or more dimensions of
		///   size 1 removed.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Given a tensor `input`, this operation returns a tensor of the same type with
		///   all dimensions of size 1 removed. If you don't want to remove all size 1
		///   dimensions, you can remove specific size 1 dimensions by specifying
		///   `squeeze_dims`.
		///   
		///   For example:
		///   
		///   ```
		///   # 't' is a tensor of shape [1, 2, 1, 3, 1, 1]
		///   shape(squeeze(t)) ==&amp;gt; [2, 3]
		///   ```
		///   
		///   Or, to remove specific size 1 dimensions:
		///   
		///   ```
		///   # 't' is a tensor of shape [1, 2, 1, 3, 1, 1]
		///   shape(squeeze(t, [2, 4])) ==&amp;gt; [1, 2, 3, 1]
		///   ```
		/// </remarks>
		public TFOutput Squeeze (TFOutput input, long[] squeeze_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Squeeze", MakeName ("Squeeze", operName));
			desc.AddInput (input);
			if (squeeze_dims != null)
				desc.SetAttr ("squeeze_dims", squeeze_dims);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Stage values similar to a lightweight Enqueue.
		/// </summary>
		/// <param name="values">
		///   a list of tensors
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Stage'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this queue is placed in the given container. Otherwise,
		///   a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   It is necessary to match this name to the matching Unstage Op.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   The basic functionality of this Op is similar to a queue with many
		///   fewer capabilities and options.  This Op is optimized for performance.
		/// </remarks>
		public TFOperation Stage (TFOutput[] values, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Stage", MakeName ("Stage", operName));
			desc.AddInputs (values);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Outputs deterministic pseudorandom values from a normal distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="seed">
		///   2 seeds (shape [2]).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StatelessRandomNormal'.
		/// </param>
		/// <param name="dtype">
		///   Optional argument
		///   The type of the output.
		/// </param>
		/// <returns>
		///   Random values with specified shape.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values will have mean 0 and standard deviation 1.
		///   
		///   The outputs are a deterministic function of `shape` and `seed`.
		/// </remarks>
		public TFOutput StatelessRandomNormal (TFOutput shape, TFOutput seed, TFDataType? dtype = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StatelessRandomNormal", MakeName ("StatelessRandomNormal", operName));
			desc.AddInput (shape);
			desc.AddInput (seed);
			if (dtype.HasValue)
				desc.SetAttrType ("dtype", dtype.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs deterministic pseudorandom random values from a uniform distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="seed">
		///   2 seeds (shape [2]).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StatelessRandomUniform'.
		/// </param>
		/// <param name="dtype">
		///   Optional argument
		///   The type of the output.
		/// </param>
		/// <returns>
		///   Random values with specified shape.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values follow a uniform distribution in the range `[0, 1)`. The
		///   lower bound 0 is included in the range, while the upper bound 1 is excluded.
		///   
		///   The outputs are a deterministic function of `shape` and `seed`.
		/// </remarks>
		public TFOutput StatelessRandomUniform (TFOutput shape, TFOutput seed, TFDataType? dtype = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StatelessRandomUniform", MakeName ("StatelessRandomUniform", operName));
			desc.AddInput (shape);
			desc.AddInput (seed);
			if (dtype.HasValue)
				desc.SetAttrType ("dtype", dtype.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Outputs deterministic pseudorandom values from a truncated normal distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="seed">
		///   2 seeds (shape [2]).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StatelessTruncatedNormal'.
		/// </param>
		/// <param name="dtype">
		///   Optional argument
		///   The type of the output.
		/// </param>
		/// <returns>
		///   Random values with specified shape.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values follow a normal distribution with mean 0 and standard
		///   deviation 1, except that values whose magnitude is more than 2 standard
		///   deviations from the mean are dropped and re-picked.
		///   
		///   The outputs are a deterministic function of `shape` and `seed`.
		/// </remarks>
		public TFOutput StatelessTruncatedNormal (TFOutput shape, TFOutput seed, TFDataType? dtype = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StatelessTruncatedNormal", MakeName ("StatelessTruncatedNormal", operName));
			desc.AddInput (shape);
			desc.AddInput (seed);
			if (dtype.HasValue)
				desc.SetAttrType ("dtype", dtype.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Stops gradient computation.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StopGradient'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   When executed in a graph, this op outputs its input tensor as-is.
		///   
		///   When building ops to compute gradients, this op prevents the contribution of
		///   its inputs to be taken into account.  Normally, the gradient generator adds ops
		///   to a graph to compute the derivatives of a specified 'loss' by recursively
		///   finding out inputs that contributed to its computation.  If you insert this op
		///   in the graph it inputs are masked from the gradient generator.  They are not
		///   taken into account for computing gradients.
		///   
		///   This is useful any time you want to compute a value with TensorFlow but need
		///   to pretend that the value was a constant. Some examples include:
		///   
		///   *  The *EM* algorithm where the *M-step* should not involve backpropagation
		///      through the output of the *E-step*.
		///   *  Contrastive divergence training of Boltzmann machines where, when
		///      differentiating the energy function, the training must not backpropagate
		///      through the graph that generated the samples from the model.
		///   *  Adversarial training, where no backprop should happen through the adversarial
		///      example generation process.
		/// </remarks>
		public TFOutput StopGradient (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StopGradient", MakeName ("StopGradient", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Return a strided slice from `input`.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="begin">
		///   `begin[k]` specifies the offset into the `k`th range specification.
		///   The exact dimension this corresponds to will be determined by context.
		///   Out-of-bounds values will be silently clamped. If the `k`th bit of
		///   `begin_mask` then `begin[k]` is ignored and the full range of the
		///   appropriate dimension is used instead. Negative values causes indexing
		///   to start from the highest element e.g. If `foo==[1,2,3]` then `foo[-1]==3`.
		/// </param>
		/// <param name="end">
		///   `end[i]` is like `begin` with the exception that `end_mask` is
		///   used to determine full ranges.
		/// </param>
		/// <param name="strides">
		///   `strides[i]` specifies the increment in the `i`th specification
		///   after extracting a given element. Negative indices will reverse
		///   the original order. Out or range values are
		///   clamped to `[0,dim[i]) if slice[i]&amp;gt;0` or `[-1,dim[i]-1] if slice[i] &amp;lt; 0`
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StridedSlice'.
		/// </param>
		/// <param name="begin_mask">
		///   Optional argument
		///   a bitmask where a bit i being 1 means to ignore the begin
		///   value and instead use the largest interval possible. At runtime
		///   begin[i] will be replaced with `[0, n-1) if `stride[i] &amp;gt; 0` or
		///   `[-1, n-1]` if `stride[i] &amp;lt; 0`
		/// </param>
		/// <param name="end_mask">
		///   Optional argument
		///   analogous to `begin_mask`
		/// </param>
		/// <param name="ellipsis_mask">
		///   Optional argument
		///   a bitmask where bit `i` being 1 means the `i`th
		///   position is actually an ellipsis. One bit at most can be 1.
		///   If `ellipsis_mask == 0`, then an implicit ellipsis mask of `1 &amp;lt;&amp;lt; (m+1)`
		///   is provided. This means that `foo[3:5] == foo[3:5, ...]`. An ellipsis
		///   implicitly creates as many range specifications as necessary to fully
		///   specify the sliced range for every dimension. For example for a 4-dimensional
		///   tensor `foo` the slice `foo[2, ..., 5:8]` implies `foo[2, :, :, 5:8]`.
		/// </param>
		/// <param name="new_axis_mask">
		///   Optional argument
		///   a bitmask where bit `i` being 1 means the `i`th
		///   specification creates a new shape 1 dimension. For example
		///   `foo[:4, tf.newaxis, :2]` would produce a shape `(4, 1, 2)` tensor.
		/// </param>
		/// <param name="shrink_axis_mask">
		///   Optional argument
		///   a bitmask where bit `i` implies that the `i`th
		///   specification should shrink the dimensionality. begin and end
		///   must imply a slice of size 1 in the dimension. For example in
		///   python one might do `foo[:, 3, :]` which would result in
		///   `shrink_axis_mask` being 2.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Note, most python users will want to use the Python `Tensor.__getitem__`
		///   or `Variable.__getitem__` rather than this op directly.
		///   
		///   The goal of this op is to produce a new tensor with a subset of
		///   the elements from the `n` dimensional `input` tensor. The subset is chosen using
		///   a sequence of `m` sparse range specifications encoded into the arguments
		///   of this function. Note, in some cases
		///   `m` could be equal to `n`, but this need not be the case. Each
		///   range specification entry can be one of the following:
		///   
		///   - An ellipsis (...). Ellipses are used to imply zero or more
		///     dimensions of full-dimension selection and are produced using
		///     `ellipsis_mask`. For example, `foo[...]` is the identity slice.
		///   
		///   - A new axis. This is used to insert a new shape=1 dimension and is
		///     produced using `new_axis_mask`. For example, `foo[:, ...]` where
		///     `foo` is shape `(3, 4)` produces a `(1, 3, 4)` tensor.
		///   
		///   
		///   - A range `begin:end:stride`. This is used to specify how much to choose from
		///     a given dimension. `stride` can be any integer but 0.  `begin` is an integer
		///     which represents the index of the first value to select while `end` represents
		///     the index of the last value to select. The number of values selected in each
		///     dimension is `end - begin` if `stride &amp;gt; 0` and `begin - end` if `stride &amp;lt; 0`.
		///     `begin` and `end` can be negative where `-1` is the last element, `-2` is
		///     the second to last. `begin_mask` controls whether to replace the explicitly
		///     given `begin` with an implicit effective value of `0` if `stride &amp;gt; 0` and
		///     `-1` if `stride &amp;lt; 0`. `end_mask` is analogous but produces the number
		///     required to create the largest open interval. For example, given a shape
		///     `(3,)` tensor `foo[:]`, the effective `begin` and `end` are `0` and `3`. Do
		///     not assume this is equivalent to `foo[0:-1]` which has an effective `begin`
		///     and `end` of `0` and `2`. Another example is `foo[-2::-1]` which reverses the
		///     first dimension of a tensor while dropping the last two (in the original
		///     order elements). For example `foo = [1,2,3,4]; foo[-2::-1]` is `[4,3]`.
		///   
		///   - A single index. This is used to keep only elements that have a given
		///     index. For example (`foo[2, :]` on a shape `(5,6)` tensor produces a
		///     shape `(6,)` tensor. This is encoded in `begin` and `end` and
		///     `shrink_axis_mask`.
		///   
		///   Each conceptual range specification is encoded in the op's argument. This
		///   encoding is best understand by considering a non-trivial example. In
		///   particular,
		///   `foo[1, 2:4, None, ..., :-3:-1, :]` will be encoded as
		///   
		///   ```
		///   begin = [1, 2, x, x, 0, x] # x denotes don't care (usually 0)
		///   end = [2, 4, x, x, -3, x]
		///   strides = [1, 1, x, x, -1, 1]
		///   begin_mask = 1&amp;lt;&amp;lt;4 | 1 &amp;lt;&amp;lt; 5 = 48
		///   end_mask = 1&amp;lt;&amp;lt;5 = 32
		///   ellipsis_mask = 1&amp;lt;&amp;lt;3 = 8
		///   new_axis_mask = 1&amp;lt;&amp;lt;2 4
		///   shrink_axis_mask = 1&amp;lt;&amp;lt;0
		///   ```
		///   
		///   In this case if `foo.shape` is (5, 5, 5, 5, 5, 5) the final shape of
		///   the slice becomes (2, 1, 5, 5, 2, 5).
		///   Let us walk step by step through each argument specification.
		///   
		///   1.  The first argument in the example slice is turned into `begin = 1` and
		///   `end = begin + 1 = 2`. To disambiguate from the original spec `2:4` we
		///   also set the appropriate bit in `shrink_axis_mask`.
		///   
		///   2. `2:4` is contributes 2, 4, 1 to begin, end, and stride. All masks have
		///   zero bits contributed.
		///   
		///   3. None is a synonym for `tf.newaxis`. This means insert a dimension of size 1
		///   dimension in the final shape. Dummy values are contributed to begin,
		///   end and stride, while the new_axis_mask bit is set.
		///   
		///   4. `...` grab the full ranges from as many dimensions as needed to
		///   fully specify a slice for every dimension of the input shape.
		///   
		///   5. `:-3:-1` shows the use of negative indices. A negative index `i` associated
		///   with a dimension that has shape `s` is converted to a positive index
		///   `s + i`. So `-1` becomes `s-1` (i.e. the last element). This conversion
		///   is done internally so begin, end and strides receive x, -3, and -1.
		///   The appropriate begin_mask bit is set to indicate the start range is the
		///   full range (ignoring the x).
		///   
		///   6. `:` indicates that the entire contents of the corresponding dimension
		///   is selected. This is equivalent to `::` or `0::1`. begin, end, and strides
		///   receive 0, 0, and 1, respectively. The appropriate bits in `begin_mask` and
		///   `end_mask` are also set.
		///   
		///   *Requirements*:
		///     `0 != strides[i] for i in [0, m)`
		///     `ellipsis_mask must be a power of two (only one ellipsis)`
		/// </remarks>
		public TFOutput StridedSlice (TFOutput input, TFOutput begin, TFOutput end, TFOutput strides, long? begin_mask = null, long? end_mask = null, long? ellipsis_mask = null, long? new_axis_mask = null, long? shrink_axis_mask = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StridedSlice", MakeName ("StridedSlice", operName));
			desc.AddInput (input);
			desc.AddInput (begin);
			desc.AddInput (end);
			desc.AddInput (strides);
			if (begin_mask.HasValue)
				desc.SetAttr ("begin_mask", begin_mask.Value);
			
			if (end_mask.HasValue)
				desc.SetAttr ("end_mask", end_mask.Value);
			
			if (ellipsis_mask.HasValue)
				desc.SetAttr ("ellipsis_mask", ellipsis_mask.Value);
			
			if (new_axis_mask.HasValue)
				desc.SetAttr ("new_axis_mask", new_axis_mask.Value);
			
			if (shrink_axis_mask.HasValue)
				desc.SetAttr ("shrink_axis_mask", shrink_axis_mask.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the gradient of `StridedSlice`.
		/// </summary>
		/// <param name="shape">
		/// </param>
		/// <param name="begin">
		/// </param>
		/// <param name="end">
		/// </param>
		/// <param name="strides">
		/// </param>
		/// <param name="dy">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StridedSliceGrad'.
		/// </param>
		/// <param name="begin_mask">
		///   Optional argument
		/// </param>
		/// <param name="end_mask">
		///   Optional argument
		/// </param>
		/// <param name="ellipsis_mask">
		///   Optional argument
		/// </param>
		/// <param name="new_axis_mask">
		///   Optional argument
		/// </param>
		/// <param name="shrink_axis_mask">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Since `StridedSlice` cuts out pieces of its `input` which is size
		///   `shape`, its gradient will have the same shape (which is passed here
		///   as `shape`). The gradient will be zero in any element that the slice
		///   does not select.
		///   
		///   Arguments are the same as StridedSliceGrad with the exception that
		///   `dy` is the input gradient to be propagated and `shape` is the
		///   shape of `StridedSlice`'s `input`.
		/// </remarks>
		public TFOutput StridedSliceGrad (TFOutput shape, TFOutput begin, TFOutput end, TFOutput strides, TFOutput dy, long? begin_mask = null, long? end_mask = null, long? ellipsis_mask = null, long? new_axis_mask = null, long? shrink_axis_mask = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StridedSliceGrad", MakeName ("StridedSliceGrad", operName));
			desc.AddInput (shape);
			desc.AddInput (begin);
			desc.AddInput (end);
			desc.AddInput (strides);
			desc.AddInput (dy);
			if (begin_mask.HasValue)
				desc.SetAttr ("begin_mask", begin_mask.Value);
			
			if (end_mask.HasValue)
				desc.SetAttr ("end_mask", end_mask.Value);
			
			if (ellipsis_mask.HasValue)
				desc.SetAttr ("ellipsis_mask", ellipsis_mask.Value);
			
			if (new_axis_mask.HasValue)
				desc.SetAttr ("new_axis_mask", new_axis_mask.Value);
			
			if (shrink_axis_mask.HasValue)
				desc.SetAttr ("shrink_axis_mask", shrink_axis_mask.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Joins the strings in the given list of string tensors into one tensor;
		/// </summary>
		/// <param name="inputs">
		///   A list of string tensors.  The tensors must all have the same shape,
		///   or be scalars.  Scalars may be mixed in; these will be broadcast to the shape
		///   of non-scalar inputs.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringJoin'.
		/// </param>
		/// <param name="separator">
		///   Optional argument
		///   string, an optional join separator.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   with the given separator (default is an empty separator).
		/// </remarks>
		public TFOutput StringJoin (TFOutput[] inputs, string separator = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringJoin", MakeName ("StringJoin", operName));
			desc.AddInputs (inputs);
			if (separator != null)
				desc.SetAttr ("separator", separator);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Split elements of `input` based on `delimiter` into a `SparseTensor`.
		/// </summary>
		/// <param name="input">
		///   1-D. Strings to split.
		/// </param>
		/// <param name="delimiter">
		///   0-D. Delimiter characters (bytes), or empty string.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringSplit'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   indices: A dense matrix of int64 representing the indices of the sparse tensor.
		///   values: A vector of strings corresponding to the splited values.
		///   shape: a length-2 vector of int64 representing the shape of the sparse
		///   tensor, where the first value is N and the second value is the maximum number
		///   of tokens in a single input entry.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Let N be the size of source (typically N will be the batch size). Split each
		///   element of `input` based on `delimiter` and return a `SparseTensor`
		///   containing the splitted tokens. Empty tokens are ignored.
		///   
		///   `delimiter` can be empty, or a string of split characters. If `delimiter` is an
		///    empty string, each element of `input` is split into individual single-byte
		///    character strings, including splitting of UTF-8 multibyte sequences. Otherwise
		///    every character of `delimiter` is a potential split point.
		///   
		///   For example:
		///     N = 2, input[0] is 'hello world' and input[1] is 'a b c', then the output
		///     will be
		///   
		///     indices = [0, 0;
		///                0, 1;
		///                1, 0;
		///                1, 1;
		///                1, 2]
		///     shape = [2, 3]
		///     values = ['hello', 'world', 'a', 'b', 'c']
		/// </remarks>
		public (TFOutput indices, TFOutput values, TFOutput shape) StringSplit (TFOutput input, TFOutput delimiter, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringSplit", MakeName ("StringSplit", operName));
			desc.AddInput (input);
			desc.AddInput (delimiter);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var indices = new TFOutput (op, _idx++);
			var values = new TFOutput (op, _idx++);
			var shape = new TFOutput (op, _idx++);
			return (indices, values, shape);
		}

		/// <summary>
		///   Converts each string in the input Tensor to its hash mod by a number of buckets.
		/// </summary>
		/// <param name="string_tensor">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringToHashBucket'.
		/// </param>
		/// <param name="num_buckets">
		///   The number of buckets.
		/// </param>
		/// <returns>
		///   A Tensor of the same shape as the input `string_tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The hash function is deterministic on the content of the string within the
		///   process.
		///   
		///   Note that the hash function may change from time to time.
		///   This functionality will be deprecated and it's recommended to use
		///   `tf.string_to_hash_bucket_fast()` or `tf.string_to_hash_bucket_strong()`.
		/// </remarks>
		public TFOutput StringToHashBucket (TFOutput string_tensor, long num_buckets, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringToHashBucket", MakeName ("StringToHashBucket", operName));
			desc.AddInput (string_tensor);
			desc.SetAttr ("num_buckets", num_buckets);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Converts each string in the input Tensor to its hash mod by a number of buckets.
		/// </summary>
		/// <param name="input">
		///   The strings to assign a hash bucket.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringToHashBucketFast'.
		/// </param>
		/// <param name="num_buckets">
		///   The number of buckets.
		/// </param>
		/// <returns>
		///   A Tensor of the same shape as the input `string_tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The hash function is deterministic on the content of the string within the
		///   process and will never change. However, it is not suitable for cryptography.
		///   This function may be used when CPU time is scarce and inputs are trusted or
		///   unimportant. There is a risk of adversaries constructing inputs that all hash
		///   to the same bucket. To prevent this problem, use a strong hash function with
		///   `tf.string_to_hash_bucket_strong`.
		/// </remarks>
		public TFOutput StringToHashBucketFast (TFOutput input, long num_buckets, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringToHashBucketFast", MakeName ("StringToHashBucketFast", operName));
			desc.AddInput (input);
			desc.SetAttr ("num_buckets", num_buckets);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Converts each string in the input Tensor to its hash mod by a number of buckets.
		/// </summary>
		/// <param name="input">
		///   The strings to assign a hash bucket.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringToHashBucketStrong'.
		/// </param>
		/// <param name="num_buckets">
		///   The number of buckets.
		/// </param>
		/// <param name="key">
		///   The key for the keyed hash function passed as a list of two uint64
		///   elements.
		/// </param>
		/// <returns>
		///   A Tensor of the same shape as the input `string_tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The hash function is deterministic on the content of the string within the
		///   process. The hash function is a keyed hash function, where attribute `key`
		///   defines the key of the hash function. `key` is an array of 2 elements.
		///   
		///   A strong hash is important when inputs may be malicious, e.g. URLs with
		///   additional components. Adversaries could try to make their inputs hash to the
		///   same bucket for a denial-of-service attack or to skew the results. A strong
		///   hash prevents this by making it difficult, if not infeasible, to compute inputs
		///   that hash to the same bucket. This comes at a cost of roughly 4x higher compute
		///   time than `tf.string_to_hash_bucket_fast`.
		/// </remarks>
		public TFOutput StringToHashBucketStrong (TFOutput input, long num_buckets, long[] key, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringToHashBucketStrong", MakeName ("StringToHashBucketStrong", operName));
			desc.AddInput (input);
			desc.SetAttr ("num_buckets", num_buckets);
			desc.SetAttr ("key", key);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Converts each string in the input Tensor to the specified numeric type.
		/// </summary>
		/// <param name="string_tensor">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'StringToNumber'.
		/// </param>
		/// <param name="out_type">
		///   Optional argument
		///   The numeric type to interpret each string in `string_tensor` as.
		/// </param>
		/// <returns>
		///   A Tensor of the same shape as the input `string_tensor`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   (Note that int32 overflow results in an error while float overflow
		///   results in a rounded value.)
		/// </remarks>
		public TFOutput StringToNumber (TFOutput string_tensor, TFDataType? out_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "StringToNumber", MakeName ("StringToNumber", operName));
			desc.AddInput (string_tensor);
			if (out_type.HasValue)
				desc.SetAttrType ("out_type", out_type.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns x - y element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sub'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   *NOTE*: `Sub` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput Sub (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sub", MakeName ("Sub", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Return substrings from `Tensor` of strings.
		/// </summary>
		/// <param name="input">
		///   Tensor of strings
		/// </param>
		/// <param name="pos">
		///   Scalar defining the position of first character in each substring
		/// </param>
		/// <param name="len">
		///   Scalar defining the number of characters to include in each substring
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Substr'.
		/// </param>
		/// <returns>
		///   Tensor of substrings
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   For each string in the input `Tensor`, creates a substring starting at index
		///   `pos` with a total length of `len`.
		///   
		///   If `len` defines a substring that would extend beyond the length of the input
		///   string, then as many characters as possible are used.
		///   
		///   If `pos` is negative or specifies a character index larger than any of the input
		///   strings, then an `InvalidArgumentError` is thrown.
		///   
		///   `pos` and `len` must have the same shape, otherwise a `ValueError` is thrown on
		///   Op creation.
		///   
		///   *NOTE*: `Substr` supports broadcasting up to two dimensions. More about
		///   broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		///   
		///   ---
		///   
		///   Examples
		///   
		///   Using scalar `pos` and `len`:
		///   
		///   ```python
		///   input = [b'Hello', b'World']
		///   position = 1
		///   length = 3
		///   
		///   output = [b'ell', b'orl']
		///   ```
		///   
		///   Using `pos` and `len` with same shape as `input`:
		///   
		///   ```python
		///   input = [[b'ten', b'eleven', b'twelve'],
		///            [b'thirteen', b'fourteen', b'fifteen'],
		///            [b'sixteen', b'seventeen', b'eighteen']]
		///   position = [[1, 2, 3],
		///               [1, 2, 3],
		///               [1, 2, 3]]
		///   length =   [[2, 3, 4],
		///               [4, 3, 2],
		///               [5, 5, 5]]
		///   
		///   output = [[b'en', b'eve', b'lve'],
		///             [b'hirt', b'urt', b'te'],
		///             [b'ixtee', b'vente', b'hteen']]
		///   ```
		///   
		///   Broadcasting `pos` and `len` onto `input`:
		///   
		///   ```
		///   input = [[b'ten', b'eleven', b'twelve'],
		///            [b'thirteen', b'fourteen', b'fifteen'],
		///            [b'sixteen', b'seventeen', b'eighteen'],
		///            [b'nineteen', b'twenty', b'twentyone']]
		///   position = [1, 2, 3]
		///   length =   [1, 2, 3]
		///   
		///   output = [[b'e', b'ev', b'lve'],
		///             [b'h', b'ur', b'tee'],
		///             [b'i', b've', b'hte'],
		///             [b'i', b'en', b'nty']]
		///   ```
		///   
		///   Broadcasting `input` onto `pos` and `len`:
		///   
		///   ```
		///   input = b'thirteen'
		///   position = [1, 5, 7]
		///   length =   [3, 2, 1]
		///   
		///   output = [b'hir', b'ee', b'n"]
		///   ```
		/// </remarks>
		public TFOutput Substr (TFOutput input, TFOutput pos, TFOutput len, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Substr", MakeName ("Substr", operName));
			desc.AddInput (input);
			desc.AddInput (pos);
			desc.AddInput (len);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum of elements across dimensions of a tensor.
		/// </summary>
		/// <param name="input">
		///   The tensor to reduce.
		/// </param>
		/// <param name="reduction_indices">
		///   The dimensions to reduce.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Sum'.
		/// </param>
		/// <param name="keep_dims">
		///   Optional argument
		///   If true, retain reduced dimensions with length 1.
		/// </param>
		/// <returns>
		///   The reduced tensor.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Reduces `input` along the dimensions given in `reduction_indices`. Unless
		///   `keep_dims` is true, the rank of the tensor is reduced by 1 for each entry in
		///   `reduction_indices`. If `keep_dims` is true, the reduced dimensions are
		///   retained with length 1.
		/// </remarks>
		public TFOutput Sum (TFOutput input, TFOutput reduction_indices, bool? keep_dims = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Sum", MakeName ("Sum", operName));
			desc.AddInput (input);
			desc.AddInput (reduction_indices);
			if (keep_dims.HasValue)
				desc.SetAttr ("keep_dims", keep_dims.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the singular value decompositions of one or more matrices.
		/// </summary>
		/// <param name="input">
		///   A tensor of shape `[..., M, N]` whose inner-most 2 dimensions
		///   form matrices of size `[M, N]`. Let `P` be the minimum of `M` and `N`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Svd'.
		/// </param>
		/// <param name="compute_uv">
		///   Optional argument
		///   If true, left and right singular vectors will be
		///   computed and returned in `u` and `v`, respectively.
		///   If false, `u` and `v` are not set and should never referenced.
		/// </param>
		/// <param name="full_matrices">
		///   Optional argument
		///   If true, compute full-sized `u` and `v`. If false
		///   (the default), compute only the leading `P` singular vectors.
		///   Ignored if `compute_uv` is `False`.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   s: Singular values. Shape is `[..., P]`.
		///   u: Left singular vectors. If `full_matrices` is `False` then shape is
		///   `[..., M, P]`; if `full_matrices` is `True` then shape is
		///   `[..., M, M]`. Undefined if `compute_uv` is `False`.
		///   v: Left singular vectors. If `full_matrices` is `False` then shape is
		///   `[..., N, P]`. If `full_matrices` is `True` then shape is `[..., N, N]`.
		///   Undefined if `compute_uv` is false.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Computes the SVD of each inner matrix in `input` such that
		///   `input[..., :, :] = u[..., :, :] * diag(s[..., :, :]) * transpose(v[..., :, :])`
		///   
		///   ```prettyprint
		///   # a is a tensor containing a batch of matrices.
		///   # s is a tensor of singular values for each matrix.
		///   # u is the tensor containing of left singular vectors for each matrix.
		///   # v is the tensor containing of right singular vectors for each matrix.
		///   s, u, v = svd(a)
		///   s, _, _ = svd(a, compute_uv=False)
		///   ```
		/// </remarks>
		public (TFOutput s, TFOutput u, TFOutput v) Svd (TFOutput input, bool? compute_uv = null, bool? full_matrices = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Svd", MakeName ("Svd", operName));
			desc.AddInput (input);
			if (compute_uv.HasValue)
				desc.SetAttr ("compute_uv", compute_uv.Value);
			
			if (full_matrices.HasValue)
				desc.SetAttr ("full_matrices", full_matrices.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var s = new TFOutput (op, _idx++);
			var u = new TFOutput (op, _idx++);
			var v = new TFOutput (op, _idx++);
			return (s, u, v);
		}

		/// <summary>
		///   Forwards `data` to the output port determined by `pred`.
		/// </summary>
		/// <param name="data">
		///   The tensor to be forwarded to the appropriate output.
		/// </param>
		/// <param name="pred">
		///   A scalar that specifies which output port will receive data.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Switch'.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   output_false: If `pred` is false, data will be forwarded to this output.
		///   output_true: If `pred` is true, data will be forwarded to this output.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   If `pred` is true, the `data` input is forwarded to `output_true`. Otherwise,
		///   the data goes to `output_false`.
		///   
		///   See also `RefSwitch` and `Merge`.
		/// </remarks>
		public (TFOutput output_false, TFOutput output_true) Switch (TFOutput data, TFOutput pred, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Switch", MakeName ("Switch", operName));
			desc.AddInput (data);
			desc.AddInput (pred);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output_false = new TFOutput (op, _idx++);
			var output_true = new TFOutput (op, _idx++);
			return (output_false, output_true);
		}

		/// <summary>
		///   Creates a dataset that contains `count` elements from the `input_dataset`.
		/// </summary>
		/// <param name="input_dataset">
		/// </param>
		/// <param name="count">
		///   A scalar representing the number of elements from the `input_dataset`
		///   that should be taken. A value of `-1` indicates that all of `input_dataset`
		///   is taken.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TakeDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TakeDataset (TFOutput input_dataset, TFOutput count, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TakeDataset", MakeName ("TakeDataset", operName));
			desc.AddInput (input_dataset);
			desc.AddInput (count);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Read `SparseTensors` from a `SparseTensorsMap` and concatenate them.
		/// </summary>
		/// <param name="sparse_handles">
		///   1-D, The `N` serialized `SparseTensor` objects.
		///   Shape: `[N]`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TakeManySparseFromTensorsMap'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   The container name for the `SparseTensorsMap` read by this op.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   The shared name for the `SparseTensorsMap` read by this op.
		///   It should not be blank; rather the `shared_name` or unique Operation name
		///   of the Op that created the original `SparseTensorsMap` should be used.
		/// </param>
		/// <param name="dtype">
		///   The `dtype` of the `SparseTensor` objects stored in the
		///   `SparseTensorsMap`.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sparse_indices: 2-D.  The `indices` of the minibatch `SparseTensor`.
		///   sparse_values: 1-D.  The `values` of the minibatch `SparseTensor`.
		///   sparse_shape: 1-D.  The `shape` of the minibatch `SparseTensor`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   The input `sparse_handles` must be an `int64` matrix of shape `[N, 1]` where
		///   `N` is the minibatch size and the rows correspond to the output handles of
		///   `AddSparseToTensorsMap` or `AddManySparseToTensorsMap`.  The ranks of the
		///   original `SparseTensor` objects that went into the given input ops must all
		///   match.  When the final `SparseTensor` is created, it has rank one
		///   higher than the ranks of the incoming `SparseTensor` objects
		///   (they have been concatenated along a new row dimension on the left).
		///   
		///   The output `SparseTensor` object's shape values for all dimensions but the
		///   first are the max across the input `SparseTensor` objects' shape values
		///   for the corresponding dimensions.  Its first shape value is `N`, the minibatch
		///   size.
		///   
		///   The input `SparseTensor` objects' indices are assumed ordered in
		///   standard lexicographic order.  If this is not the case, after this
		///   step run `SparseReorder` to restore index ordering.
		///   
		///   For example, if the handles represent an input, which is a `[2, 3]` matrix
		///   representing two original `SparseTensor` objects:
		///   
		///   ```
		///       index = [ 0]
		///               [10]
		///               [20]
		///       values = [1, 2, 3]
		///       shape = [50]
		///   ```
		///   
		///   and
		///   
		///   ```
		///       index = [ 2]
		///               [10]
		///       values = [4, 5]
		///       shape = [30]
		///   ```
		///   
		///   then the final `SparseTensor` will be:
		///   
		///   ```
		///       index = [0  0]
		///               [0 10]
		///               [0 20]
		///               [1  2]
		///               [1 10]
		///       values = [1, 2, 3, 4, 5]
		///       shape = [2 50]
		///   ```
		/// </remarks>
		public (TFOutput sparse_indices, TFOutput sparse_values, TFOutput sparse_shape) TakeManySparseFromTensorsMap (TFOutput sparse_handles, TFDataType dtype, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TakeManySparseFromTensorsMap", MakeName ("TakeManySparseFromTensorsMap", operName));
			desc.AddInput (sparse_handles);
			desc.SetAttrType ("dtype", dtype);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sparse_indices = new TFOutput (op, _idx++);
			var sparse_values = new TFOutput (op, _idx++);
			var sparse_shape = new TFOutput (op, _idx++);
			return (sparse_indices, sparse_values, sparse_shape);
		}

		/// <summary>
		///   Computes tan of x element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Tan'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Tan (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Tan", MakeName ("Tan", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes hyperbolic tangent of `x` element-wise.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Tanh'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput Tanh (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Tanh", MakeName ("Tanh", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Computes the gradient for the tanh of `x` wrt its input.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TanhGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Specifically, `grad = dy * (1 - y*y)`, where `y = tanh(x)`, and `dy`
		///   is the corresponding input gradient.
		/// </remarks>
		public TFOutput TanhGrad (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TanhGrad", MakeName ("TanhGrad", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Deprecated. Use TensorArrayCloseV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayCloseV2'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation TensorArrayCloseV2 (TFOutput handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayCloseV2", MakeName ("TensorArrayCloseV2", operName));
			desc.AddInput (handle);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Delete the TensorArray from its resource container.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray (output of TensorArray or TensorArrayGrad).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayCloseV3'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		/// <remarks>
		///   This enables the user to close and release the resource in the middle
		///   of a step/run.
		/// </remarks>
		public TFOperation TensorArrayCloseV3 (TFOutput handle, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayCloseV3", MakeName ("TensorArrayCloseV3", operName));
			desc.AddInput (handle);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Deprecated. Use TensorArrayConcatV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayConcatV2'.
		/// </param>
		/// <param name="element_shape_except0">
		///   Optional argument
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   value: 
		///   lengths: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		public (TFOutput value, TFOutput lengths) TensorArrayConcatV2 (TFOutput handle, TFOutput flow_in, TFDataType dtype, TFShape element_shape_except0 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayConcatV2", MakeName ("TensorArrayConcatV2", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape_except0 != null)
				desc.SetAttrShape ("element_shape_except0", element_shape_except0);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			var lengths = new TFOutput (op, _idx++);
			return (value, lengths);
		}

		/// <summary>
		///   Concat the elements from the TensorArray into value `value`.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayConcatV3'.
		/// </param>
		/// <param name="element_shape_except0">
		///   Optional argument
		///   The expected shape of an element, if known,
		///   excluding the first dimension. Used to validate the shapes of
		///   TensorArray elements. If this shape is not fully specified, concatenating
		///   zero-size TensorArrays is an error.
		/// </param>
		/// <param name="dtype">
		///   The type of the elem that is returned.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   value: All of the elements in the TensorArray, concatenated along the first
		///   axis.
		///   lengths: A vector of the row sizes of the original T elements in the
		///   value output.  In the example above, this would be the values:
		///   `(n1, n2, ..., n(T-1))`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Takes `T` elements of shapes
		///   
		///     ```
		///     (n0 x d0 x d1 x ...), (n1 x d0 x d1 x ...), ..., (n(T-1) x d0 x d1 x ...)
		///     ```
		///   
		///   and concatenates them into a Tensor of shape:
		///   
		///     ```(n0 + n1 + ... + n(T-1) x d0 x d1 x ...)```
		///   
		///   All elements must have the same shape (excepting the first dimension).
		/// </remarks>
		public (TFOutput value, TFOutput lengths) TensorArrayConcatV3 (TFOutput handle, TFOutput flow_in, TFDataType dtype, TFShape element_shape_except0 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayConcatV3", MakeName ("TensorArrayConcatV3", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape_except0 != null)
				desc.SetAttrShape ("element_shape_except0", element_shape_except0);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			var lengths = new TFOutput (op, _idx++);
			return (value, lengths);
		}

		/// <summary>
		///   Deprecated. Use TensorArrayGatherV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="indices">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayGatherV2'.
		/// </param>
		/// <param name="element_shape">
		///   Optional argument
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayGatherV2 (TFOutput handle, TFOutput indices, TFOutput flow_in, TFDataType dtype, TFShape element_shape = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayGatherV2", MakeName ("TensorArrayGatherV2", operName));
			desc.AddInput (handle);
			desc.AddInput (indices);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape != null)
				desc.SetAttrShape ("element_shape", element_shape);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Gather specific elements from the TensorArray into output `value`.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="indices">
		///   The locations in the TensorArray from which to read tensor elements.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayGatherV3'.
		/// </param>
		/// <param name="element_shape">
		///   Optional argument
		///   The expected shape of an element, if known. Used to
		///   validate the shapes of TensorArray elements. If this shape is not
		///   fully specified, gathering zero-size TensorArrays is an error.
		/// </param>
		/// <param name="dtype">
		///   The type of the elem that is returned.
		/// </param>
		/// <returns>
		///   All of the elements in the TensorArray, concatenated along a new
		///   axis (the new dimension 0).
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   All elements selected by `indices` must have the same shape.
		/// </remarks>
		public TFOutput TensorArrayGatherV3 (TFOutput handle, TFOutput indices, TFOutput flow_in, TFDataType dtype, TFShape element_shape = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayGatherV3", MakeName ("TensorArrayGatherV3", operName));
			desc.AddInput (handle);
			desc.AddInput (indices);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape != null)
				desc.SetAttrShape ("element_shape", element_shape);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Deprecated. Use TensorArrayGradV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayGradV2'.
		/// </param>
		/// <param name="source">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayGradV2 (TFOutput handle, TFOutput flow_in, string source, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayGradV2", MakeName ("TensorArrayGradV2", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			desc.SetAttr ("source", source);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var grad_handle = new TFOutput (op, _idx++);
			return grad_handle;
		}

		/// <summary>
		///   Creates a TensorArray for storing the gradients of values in the given handle.
		/// </summary>
		/// <param name="handle">
		///   The handle to the forward TensorArray.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayGradV3'.
		/// </param>
		/// <param name="source">
		///   The gradient source string, used to decide which gradient TensorArray
		///   to return.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   grad_handle: 
		///   flow_out: 
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   If the given TensorArray gradient already exists, returns a reference to it.
		///   
		///   Locks the size of the original TensorArray by disabling its dynamic size flag.
		///   
		///   **A note about the input flow_in:**
		///   
		///   The handle flow_in forces the execution of the gradient lookup to occur
		///   only after certain other operations have occurred.  For example, when
		///   the forward TensorArray is dynamically sized, writes to this TensorArray
		///   may resize the object.  The gradient TensorArray is statically sized based
		///   on the size of the forward TensorArray when this operation executes.
		///   Furthermore, the size of the forward TensorArray is frozen by this call.
		///   As a result, the flow is used to ensure that the call to generate the gradient
		///   TensorArray only happens after all writes are executed.
		///   
		///   In the case of dynamically sized TensorArrays, gradient computation should
		///   only be performed on read operations that have themselves been chained via
		///   flow to occur only after all writes have executed. That way the final size
		///   of the forward TensorArray is known when this operation is called.
		///   
		///   **A note about the source attribute:**
		///   
		///   TensorArray gradient calls use an accumulator TensorArray object.  If
		///   multiple gradients are calculated and run in the same session, the multiple
		///   gradient nodes may accidentally flow throuth the same accumulator TensorArray.
		///   This double counts and generally breaks the TensorArray gradient flow.
		///   
		///   The solution is to identify which gradient call this particular
		///   TensorArray gradient is being called in.  This is performed by identifying
		///   a unique string (e.g. "gradients", "gradients_1", ...) from the input
		///   gradient Tensor's name.  This string is used as a suffix when creating
		///   the TensorArray gradient object here (the attribute `source`).
		///   
		///   The attribute `source` is added as a suffix to the forward TensorArray's
		///   name when performing the creation / lookup, so that each separate gradient
		///   calculation gets its own TensorArray accumulator.
		/// </remarks>
		public (TFOutput grad_handle, TFOutput flow_out) TensorArrayGradV3 (TFOutput handle, TFOutput flow_in, string source, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayGradV3", MakeName ("TensorArrayGradV3", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			desc.SetAttr ("source", source);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var grad_handle = new TFOutput (op, _idx++);
			var flow_out = new TFOutput (op, _idx++);
			return (grad_handle, flow_out);
		}

		/// <summary>
		///   Deprecated. Use TensorArrayReadV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="index">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayReadV2'.
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayReadV2 (TFOutput handle, TFOutput index, TFOutput flow_in, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayReadV2", MakeName ("TensorArrayReadV2", operName));
			desc.AddInput (handle);
			desc.AddInput (index);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Read an element from the TensorArray into output `value`.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="index">
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayReadV3'.
		/// </param>
		/// <param name="dtype">
		///   The type of the elem that is returned.
		/// </param>
		/// <returns>
		///   The tensor that is read from the TensorArray.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayReadV3 (TFOutput handle, TFOutput index, TFOutput flow_in, TFDataType dtype, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayReadV3", MakeName ("TensorArrayReadV3", operName));
			desc.AddInput (handle);
			desc.AddInput (index);
			desc.AddInput (flow_in);
			desc.SetAttrType ("dtype", dtype);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var value = new TFOutput (op, _idx++);
			return value;
		}

		/// <summary>
		///   Deprecated. Use TensorArrayScatterV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="indices">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayScatterV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayScatterV2 (TFOutput handle, TFOutput indices, TFOutput value, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayScatterV2", MakeName ("TensorArrayScatterV2", operName));
			desc.AddInput (handle);
			desc.AddInput (indices);
			desc.AddInput (value);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Scatter the data from the input value into specific TensorArray elements.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="indices">
		///   The locations at which to write the tensor elements.
		/// </param>
		/// <param name="value">
		///   The concatenated tensor to write to the TensorArray.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayScatterV3'.
		/// </param>
		/// <returns>
		///   A float scalar that enforces proper chaining of operations.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   `indices` must be a vector, its length must match the first dim of `value`.
		/// </remarks>
		public TFOutput TensorArrayScatterV3 (TFOutput handle, TFOutput indices, TFOutput value, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayScatterV3", MakeName ("TensorArrayScatterV3", operName));
			desc.AddInput (handle);
			desc.AddInput (indices);
			desc.AddInput (value);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Deprecated. Use TensorArraySizeV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArraySizeV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArraySizeV2 (TFOutput handle, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArraySizeV2", MakeName ("TensorArraySizeV2", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var size = new TFOutput (op, _idx++);
			return size;
		}

		/// <summary>
		///   Get the current size of the TensorArray.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray (output of TensorArray or TensorArrayGrad).
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArraySizeV3'.
		/// </param>
		/// <returns>
		///   The current size of the TensorArray.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArraySizeV3 (TFOutput handle, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArraySizeV3", MakeName ("TensorArraySizeV3", operName));
			desc.AddInput (handle);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var size = new TFOutput (op, _idx++);
			return size;
		}

		/// <summary>
		///   Deprecated. Use TensorArraySplitV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <param name="lengths">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArraySplitV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArraySplitV2 (TFOutput handle, TFOutput value, TFOutput lengths, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArraySplitV2", MakeName ("TensorArraySplitV2", operName));
			desc.AddInput (handle);
			desc.AddInput (value);
			desc.AddInput (lengths);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Split the data from the input value into TensorArray elements.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="value">
		///   The concatenated tensor to write to the TensorArray.
		/// </param>
		/// <param name="lengths">
		///   The vector of lengths, how to split the rows of value into the
		///   TensorArray.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArraySplitV3'.
		/// </param>
		/// <returns>
		///   A float scalar that enforces proper chaining of operations.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Assuming that `lengths` takes on values
		///   
		///     ```(n0, n1, ..., n(T-1))```
		///   
		///   and that `value` has shape
		///   
		///     ```(n0 + n1 + ... + n(T-1) x d0 x d1 x ...)```,
		///   
		///   this splits values into a TensorArray with T tensors.
		///   
		///   TensorArray index t will be the subtensor of values with starting position
		///   
		///     ```(n0 + n1 + ... + n(t-1), 0, 0, ...)```
		///   
		///   and having size
		///   
		///     ```nt x d0 x d1 x ...```
		/// </remarks>
		public TFOutput TensorArraySplitV3 (TFOutput handle, TFOutput value, TFOutput lengths, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArraySplitV3", MakeName ("TensorArraySplitV3", operName));
			desc.AddInput (handle);
			desc.AddInput (value);
			desc.AddInput (lengths);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Deprecated. Use TensorArrayV3
		/// </summary>
		/// <param name="size">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayV2'.
		/// </param>
		/// <param name="element_shape">
		///   Optional argument
		/// </param>
		/// <param name="dynamic_size">
		///   Optional argument
		/// </param>
		/// <param name="clear_after_read">
		///   Optional argument
		/// </param>
		/// <param name="tensor_array_name">
		///   Optional argument
		/// </param>
		/// <param name="dtype">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayV2 (TFOutput size, TFDataType dtype, TFShape element_shape = null, bool? dynamic_size = null, bool? clear_after_read = null, string tensor_array_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayV2", MakeName ("TensorArrayV2", operName));
			desc.AddInput (size);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape != null)
				desc.SetAttrShape ("element_shape", element_shape);
			
			if (dynamic_size.HasValue)
				desc.SetAttr ("dynamic_size", dynamic_size.Value);
			
			if (clear_after_read.HasValue)
				desc.SetAttr ("clear_after_read", clear_after_read.Value);
			
			if (tensor_array_name != null)
				desc.SetAttr ("tensor_array_name", tensor_array_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   An array of Tensors of given size.
		/// </summary>
		/// <param name="size">
		///   The size of the array.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayV3'.
		/// </param>
		/// <param name="element_shape">
		///   Optional argument
		///   The expected shape of an element, if known. Used to
		///   validate the shapes of TensorArray elements. If this shape is not
		///   fully specified, gathering zero-size TensorArrays is an error.
		/// </param>
		/// <param name="dynamic_size">
		///   Optional argument
		///   A boolean that determines whether writes to the TensorArray
		///   are allowed to grow the size.  By default, this is not allowed.
		/// </param>
		/// <param name="clear_after_read">
		///   Optional argument
		///   If true (default), Tensors in the TensorArray are cleared
		///   after being read.  This disables multiple read semantics but allows early
		///   release of memory.
		/// </param>
		/// <param name="tensor_array_name">
		///   Optional argument
		///   Overrides the name used for the temporary tensor_array
		///   resource. Default value is the name of the 'TensorArray' op (which
		///   is guaranteed unique).
		/// </param>
		/// <param name="dtype">
		///   The type of the elements on the tensor_array.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   handle: The handle to the TensorArray.
		///   flow: A scalar used to control gradient flow.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   Write data via Write and read via Read or Pack.
		/// </remarks>
		public (TFOutput handle, TFOutput flow) TensorArrayV3 (TFOutput size, TFDataType dtype, TFShape element_shape = null, bool? dynamic_size = null, bool? clear_after_read = null, string tensor_array_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayV3", MakeName ("TensorArrayV3", operName));
			desc.AddInput (size);
			desc.SetAttrType ("dtype", dtype);
			if (element_shape != null)
				desc.SetAttrShape ("element_shape", element_shape);
			
			if (dynamic_size.HasValue)
				desc.SetAttr ("dynamic_size", dynamic_size.Value);
			
			if (clear_after_read.HasValue)
				desc.SetAttr ("clear_after_read", clear_after_read.Value);
			
			if (tensor_array_name != null)
				desc.SetAttr ("tensor_array_name", tensor_array_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			var flow = new TFOutput (op, _idx++);
			return (handle, flow);
		}

		/// <summary>
		///   Deprecated. Use TensorArrayGradV3
		/// </summary>
		/// <param name="handle">
		/// </param>
		/// <param name="index">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <param name="flow_in">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayWriteV2'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayWriteV2 (TFOutput handle, TFOutput index, TFOutput value, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayWriteV2", MakeName ("TensorArrayWriteV2", operName));
			desc.AddInput (handle);
			desc.AddInput (index);
			desc.AddInput (value);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Push an element onto the tensor_array.
		/// </summary>
		/// <param name="handle">
		///   The handle to a TensorArray.
		/// </param>
		/// <param name="index">
		///   The position to write to inside the TensorArray.
		/// </param>
		/// <param name="value">
		///   The tensor to write to the TensorArray.
		/// </param>
		/// <param name="flow_in">
		///   A float scalar that enforces proper chaining of operations.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorArrayWriteV3'.
		/// </param>
		/// <returns>
		///   A float scalar that enforces proper chaining of operations.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorArrayWriteV3 (TFOutput handle, TFOutput index, TFOutput value, TFOutput flow_in, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorArrayWriteV3", MakeName ("TensorArrayWriteV3", operName));
			desc.AddInput (handle);
			desc.AddInput (index);
			desc.AddInput (value);
			desc.AddInput (flow_in);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var flow_out = new TFOutput (op, _idx++);
			return flow_out;
		}

		/// <summary>
		///   Creates a dataset that emits `components` as a tuple of tensors once.
		/// </summary>
		/// <param name="components">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorDataset'.
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorDataset (TFOutput[] components, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorDataset", MakeName ("TensorDataset", operName));
			desc.AddInputs (components);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Creates a dataset that emits each dim-0 slice of `components` once.
		/// </summary>
		/// <param name="components">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorSliceDataset'.
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorSliceDataset (TFOutput[] components, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorSliceDataset", MakeName ("TensorSliceDataset", operName));
			desc.AddInputs (components);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   Outputs a `Summary` protocol buffer with a tensor.
		/// </summary>
		/// <param name="tensor">
		///   A tensor to serialize.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TensorSummary'.
		/// </param>
		/// <param name="description">
		///   Optional argument
		///   A json-encoded SummaryDescription proto.
		/// </param>
		/// <param name="labels">
		///   Optional argument
		///   An unused list of strings.
		/// </param>
		/// <param name="display_name">
		///   Optional argument
		///   An unused string.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TensorSummary (TFOutput tensor, string description = null, string[] labels = null, string display_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TensorSummary", MakeName ("TensorSummary", operName));
			desc.AddInput (tensor);
			if (description != null)
				desc.SetAttr ("description", description);
			
			if (labels != null)
				desc.SetAttr ("labels", labels);
			
			if (display_name != null)
				desc.SetAttr ("display_name", display_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var summary = new TFOutput (op, _idx++);
			return summary;
		}

		/// <summary>
		///   Creates a dataset that emits the lines of one or more text files.
		/// </summary>
		/// <param name="filenames">
		///   A scalar or a vector containing the name(s) of the file(s) to be
		///   read.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TextLineDataset'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TextLineDataset (TFOutput filenames, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TextLineDataset", MakeName ("TextLineDataset", operName));
			desc.AddInput (filenames);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   A Reader that outputs the lines of a file delimited by '\n'.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TextLineReaderV2'.
		/// </param>
		/// <param name="skip_header_lines">
		///   Optional argument
		///   Number of lines to skip from the beginning of every file.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this reader is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this reader is named in the given bucket
		///   with this shared_name. Otherwise, the node name is used instead.
		/// </param>
		/// <returns>
		///   The handle to reference the Reader.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TextLineReaderV2 (long? skip_header_lines = null, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TextLineReaderV2", MakeName ("TextLineReaderV2", operName));
			if (skip_header_lines.HasValue)
				desc.SetAttr ("skip_header_lines", skip_header_lines.Value);
			
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var reader_handle = new TFOutput (op, _idx++);
			return reader_handle;
		}

		/// <summary>
		///   Creates a dataset that emits the records from one or more TFRecord files.
		/// </summary>
		/// <param name="filenames">
		///   A scalar or vector containing the name(s) of the file(s) to be
		///   read.
		/// </param>
		/// <param name="compression_type">
		///   A scalar containing either (i) the empty string (no
		///   compression), (ii) "ZLIB", or (iii) "GZIP".
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TFRecordDataset'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TFRecordDataset (TFOutput filenames, TFOutput compression_type, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TFRecordDataset", MakeName ("TFRecordDataset", operName));
			desc.AddInput (filenames);
			desc.AddInput (compression_type);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

		/// <summary>
		///   A Reader that outputs the records from a TensorFlow Records file.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TFRecordReaderV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this reader is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this reader is named in the given bucket
		///   with this shared_name. Otherwise, the node name is used instead.
		/// </param>
		/// <param name="compression_type">
		///   Optional argument
		/// </param>
		/// <returns>
		///   The handle to reference the Reader.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput TFRecordReaderV2 (string container = null, string shared_name = null, string compression_type = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TFRecordReaderV2", MakeName ("TFRecordReaderV2", operName));
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			if (compression_type != null)
				desc.SetAttr ("compression_type", compression_type);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var reader_handle = new TFOutput (op, _idx++);
			return reader_handle;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a learned unigram distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ThreadUnsafeUnigramCandidateSampler'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to randomly sample.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <param name="range_max">
		///   The sampler will sample integers from the interval [0, range_max).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See explanations of candidate sampling and the data formats at
		///   go/candidate-sampling.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) ThreadUnsafeUnigramCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long range_max, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ThreadUnsafeUnigramCandidateSampler", MakeName ("ThreadUnsafeUnigramCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			desc.SetAttr ("range_max", range_max);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Constructs a tensor by tiling a given tensor.
		/// </summary>
		/// <param name="input">
		///   1-D or higher.
		/// </param>
		/// <param name="multiples">
		///   1-D. Length must be the same as the number of dimensions in `input`
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Tile'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation creates a new tensor by replicating `input` `multiples` times.
		///   The output tensor's i'th dimension has `input.dims(i) * multiples[i]` elements,
		///   and the values of `input` are replicated `multiples[i]` times along the 'i'th
		///   dimension. For example, tiling `[a b c d]` by `[2]` produces
		///   `[a b c d a b c d]`.
		/// </remarks>
		public TFOutput Tile (TFOutput input, TFOutput multiples, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Tile", MakeName ("Tile", operName));
			desc.AddInput (input);
			desc.AddInput (multiples);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns the gradient of `Tile`.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="multiples">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TileGrad'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Since `Tile` takes an input and repeats the input `multiples` times
		///   along each dimension, `TileGrad` takes in `multiples` and aggregates
		///   each repeated tile of `input` into `output`.
		/// </remarks>
		public TFOutput TileGrad (TFOutput input, TFOutput multiples, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TileGrad", MakeName ("TileGrad", operName));
			desc.AddInput (input);
			desc.AddInput (multiples);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Finds values and indices of the `k` largest elements for the last dimension.
		/// </summary>
		/// <param name="input">
		///   1-D or higher with last dimension at least `k`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TopK'.
		/// </param>
		/// <param name="sorted">
		///   Optional argument
		///   If true the resulting `k` elements will be sorted by the values in
		///   descending order.
		/// </param>
		/// <param name="k">
		///   Number of top elements to look for along the last dimension (along each
		///   row for matrices).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   values: The `k` largest elements along each last dimensional slice.
		///   indices: The indices of `values` within the last dimension of `input`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   If the input is a vector (rank-1), finds the `k` largest entries in the vector
		///   and outputs their values and indices as vectors.  Thus `values[j]` is the
		///   `j`-th largest entry in `input`, and its index is `indices[j]`.
		///   
		///   For matrices (resp. higher rank input), computes the top `k` entries in each
		///   row (resp. vector along the last dimension).  Thus,
		///   
		///       values.shape = indices.shape = input.shape[:-1] + [k]
		///   
		///   If two elements are equal, the lower-index element appears first.
		///   
		///   If `k` varies dynamically, use `TopKV2` below.
		/// </remarks>
		public (TFOutput values, TFOutput indices) TopK (TFOutput input, long k, bool? sorted = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TopK", MakeName ("TopK", operName));
			desc.AddInput (input);
			desc.SetAttr ("k", k);
			if (sorted.HasValue)
				desc.SetAttr ("sorted", sorted.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var values = new TFOutput (op, _idx++);
			var indices = new TFOutput (op, _idx++);
			return (values, indices);
		}

		/// <summary>
		///   Finds values and indices of the `k` largest elements for the last dimension.
		/// </summary>
		/// <param name="input">
		///   1-D or higher with last dimension at least `k`.
		/// </param>
		/// <param name="k">
		///   0-D.  Number of top elements to look for along the last dimension (along each
		///   row for matrices).
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TopKV2'.
		/// </param>
		/// <param name="sorted">
		///   Optional argument
		///   If true the resulting `k` elements will be sorted by the values in
		///   descending order.
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   values: The `k` largest elements along each last dimensional slice.
		///   indices: The indices of `values` within the last dimension of `input`.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   If the input is a vector (rank-1), finds the `k` largest entries in the vector
		///   and outputs their values and indices as vectors.  Thus `values[j]` is the
		///   `j`-th largest entry in `input`, and its index is `indices[j]`.
		///   
		///   For matrices (resp. higher rank input), computes the top `k` entries in each
		///   row (resp. vector along the last dimension).  Thus,
		///   
		///       values.shape = indices.shape = input.shape[:-1] + [k]
		///   
		///   If two elements are equal, the lower-index element appears first.
		/// </remarks>
		public (TFOutput values, TFOutput indices) TopKV2 (TFOutput input, TFOutput k, bool? sorted = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TopKV2", MakeName ("TopKV2", operName));
			desc.AddInput (input);
			desc.AddInput (k);
			if (sorted.HasValue)
				desc.SetAttr ("sorted", sorted.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var values = new TFOutput (op, _idx++);
			var indices = new TFOutput (op, _idx++);
			return (values, indices);
		}

		/// <summary>
		///   Shuffle dimensions of x according to a permutation.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="perm">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Transpose'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The output `y` has the same rank as `x`. The shapes of `x` and `y` satisfy:
		///     `y.shape[i] == x.shape[perm[i]] for i in [0, 1, ..., rank(x) - 1]`
		/// </remarks>
		public TFOutput Transpose (TFOutput x, TFOutput perm, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Transpose", MakeName ("Transpose", operName));
			desc.AddInput (x);
			desc.AddInput (perm);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Returns x / y element-wise for integer types.
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TruncateDiv'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Truncation designates that negative numbers will round fractional quantities
		///   toward zero. I.e. -7 / 5 = 1. This matches C semantics but it is different
		///   than Python semantics. See `FloorDiv` for a division function that matches
		///   Python Semantics.
		///   
		///   *NOTE*: `TruncateDiv` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput TruncateDiv (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TruncateDiv", MakeName ("TruncateDiv", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Outputs random values from a truncated normal distribution.
		/// </summary>
		/// <param name="shape">
		///   The shape of the output tensor.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TruncatedNormal'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either `seed` or `seed2` are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   A second seed to avoid seed collision.
		/// </param>
		/// <param name="dtype">
		///   The type of the output.
		/// </param>
		/// <returns>
		///   A tensor of the specified shape filled with random truncated normal
		///   values.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The generated values follow a normal distribution with mean 0 and standard
		///   deviation 1, except that values whose magnitude is more than 2 standard
		///   deviations from the mean are dropped and re-picked.
		/// </remarks>
		public TFOutput TruncatedNormal (TFOutput shape, TFDataType dtype, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TruncatedNormal", MakeName ("TruncatedNormal", operName));
			desc.AddInput (shape);
			desc.SetAttrType ("dtype", dtype);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Returns element-wise remainder of division. This emulates C semantics in that
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'TruncateMod'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   the result here is consistent with a truncating divide. E.g. `truncate(x / y) *
		///   y + truncate_mod(x, y) = x`.
		///   
		///   *NOTE*: `TruncateMod` supports broadcasting. More about broadcasting
		///   [here](http://docs.scipy.org/doc/numpy/user/basics.broadcasting.html)
		/// </remarks>
		public TFOutput TruncateMod (TFOutput x, TFOutput y, string operName = null)
		{
			var desc = new TFOperationDesc (this, "TruncateMod", MakeName ("TruncateMod", operName));
			desc.AddInput (x);
			desc.AddInput (y);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Generates labels for candidate sampling with a uniform distribution.
		/// </summary>
		/// <param name="true_classes">
		///   A batch_size * num_true matrix, in which each row contains the
		///   IDs of the num_true target_classes in the corresponding original label.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'UniformCandidateSampler'.
		/// </param>
		/// <param name="seed">
		///   Optional argument
		///   If either seed or seed2 are set to be non-zero, the random number
		///   generator is seeded by the given seed.  Otherwise, it is seeded by a
		///   random seed.
		/// </param>
		/// <param name="seed2">
		///   Optional argument
		///   An second seed to avoid seed collision.
		/// </param>
		/// <param name="num_true">
		///   Number of true labels per context.
		/// </param>
		/// <param name="num_sampled">
		///   Number of candidates to randomly sample.
		/// </param>
		/// <param name="unique">
		///   If unique is true, we sample with rejection, so that all sampled
		///   candidates in a batch are unique. This requires some approximation to
		///   estimate the post-rejection sampling probabilities.
		/// </param>
		/// <param name="range_max">
		///   The sampler will sample integers from the interval [0, range_max).
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   sampled_candidates: A vector of length num_sampled, in which each element is
		///   the ID of a sampled candidate.
		///   true_expected_count: A batch_size * num_true matrix, representing
		///   the number of times each candidate is expected to occur in a batch
		///   of sampled candidates. If unique=true, then this is a probability.
		///   sampled_expected_count: A vector of length num_sampled, for each sampled
		///   candidate representing the number of times the candidate is expected
		///   to occur in a batch of sampled candidates.  If unique=true, then this is a
		///   probability.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   See explanations of candidate sampling and the data formats at
		///   go/candidate-sampling.
		///   
		///   For each batch, this op picks a single set of sampled candidate labels.
		///   
		///   The advantages of sampling candidates per-batch are simplicity and the
		///   possibility of efficient dense matrix multiplication. The disadvantage is that
		///   the sampled candidates must be chosen independently of the context and of the
		///   true labels.
		/// </remarks>
		public (TFOutput sampled_candidates, TFOutput true_expected_count, TFOutput sampled_expected_count) UniformCandidateSampler (TFOutput true_classes, long num_true, long num_sampled, bool unique, long range_max, long? seed = null, long? seed2 = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "UniformCandidateSampler", MakeName ("UniformCandidateSampler", operName));
			desc.AddInput (true_classes);
			desc.SetAttr ("num_true", num_true);
			desc.SetAttr ("num_sampled", num_sampled);
			desc.SetAttr ("unique", unique);
			desc.SetAttr ("range_max", range_max);
			if (seed.HasValue)
				desc.SetAttr ("seed", seed.Value);
			
			if (seed2.HasValue)
				desc.SetAttr ("seed2", seed2.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var sampled_candidates = new TFOutput (op, _idx++);
			var true_expected_count = new TFOutput (op, _idx++);
			var sampled_expected_count = new TFOutput (op, _idx++);
			return (sampled_candidates, true_expected_count, sampled_expected_count);
		}

		/// <summary>
		///   Finds unique elements in a 1-D tensor.
		/// </summary>
		/// <param name="x">
		///   1-D.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Unique'.
		/// </param>
		/// <param name="out_idx">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   y: 1-D.
		///   idx: 1-D.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This operation returns a tensor `y` containing all of the unique elements of `x`
		///   sorted in the same order that they occur in `x`. This operation also returns a
		///   tensor `idx` the same size as `x` that contains the index of each value of `x`
		///   in the unique output `y`. In other words:
		///   
		///   `y[idx[i]] = x[i] for i in [0, 1,...,rank(x) - 1]`
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'x' is [1, 1, 2, 4, 4, 4, 7, 8, 8]
		///   y, idx = unique(x)
		///   y ==&amp;gt; [1, 2, 4, 7, 8]
		///   idx ==&amp;gt; [0, 0, 1, 2, 2, 2, 3, 4, 4]
		///   ```
		/// </remarks>
		public (TFOutput y, TFOutput idx) Unique (TFOutput x, TFDataType? out_idx = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Unique", MakeName ("Unique", operName));
			desc.AddInput (x);
			if (out_idx.HasValue)
				desc.SetAttrType ("out_idx", out_idx.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			var idx = new TFOutput (op, _idx++);
			return (y, idx);
		}

		/// <summary>
		///   Finds unique elements in a 1-D tensor.
		/// </summary>
		/// <param name="x">
		///   1-D.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'UniqueWithCounts'.
		/// </param>
		/// <param name="out_idx">
		///   Optional argument
		/// </param>
		/// <returns>
		///   Returns a tuple with multiple values, as follows:
		///   y: 1-D.
		///   idx: 1-D.
		///   count: 1-D.
		///   The TFOperation can be fetched from any of the TFOutputs returned in the tuple values, by fethching the Operation property.
		/// </returns>
		/// <remarks>
		///   This operation returns a tensor `y` containing all of the unique elements of `x`
		///   sorted in the same order that they occur in `x`. This operation also returns a
		///   tensor `idx` the same size as `x` that contains the index of each value of `x`
		///   in the unique output `y`. Finally, it returns a third tensor `count` that
		///   contains the count of each element of `y` in `x`. In other words:
		///   
		///   `y[idx[i]] = x[i] for i in [0, 1,...,rank(x) - 1]`
		///   
		///   For example:
		///   
		///   ```
		///   # tensor 'x' is [1, 1, 2, 4, 4, 4, 7, 8, 8]
		///   y, idx, count = unique_with_counts(x)
		///   y ==&amp;gt; [1, 2, 4, 7, 8]
		///   idx ==&amp;gt; [0, 0, 1, 2, 2, 2, 3, 4, 4]
		///   count ==&amp;gt; [2, 1, 3, 1, 2]
		///   ```
		/// </remarks>
		public (TFOutput y, TFOutput idx, TFOutput count) UniqueWithCounts (TFOutput x, TFDataType? out_idx = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "UniqueWithCounts", MakeName ("UniqueWithCounts", operName));
			desc.AddInput (x);
			if (out_idx.HasValue)
				desc.SetAttrType ("out_idx", out_idx.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			var idx = new TFOutput (op, _idx++);
			var count = new TFOutput (op, _idx++);
			return (y, idx, count);
		}

		/// <summary>
		///   Unpacks a given dimension of a rank-`R` tensor into `num` rank-`(R-1)` tensors.
		/// </summary>
		/// <param name="value">
		///   1-D or higher, with `axis` dimension size equal to `num`.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Unpack'.
		/// </param>
		/// <param name="axis">
		///   Optional argument
		///   Dimension along which to unpack.  Negative values wrap around, so the
		///   valid range is `[-R, R)`.
		/// </param>
		/// <param name="num">
		/// </param>
		/// <returns>
		///   The list of tensors unpacked from `value`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Unpacks `num` tensors from `value` by chipping it along the `axis` dimension.
		///   For example, given a tensor of shape `(A, B, C, D)`;
		///   
		///   If `axis == 0` then the i'th tensor in `output` is the slice `value[i, :, :, :]`
		///     and each tensor in `output` will have shape `(B, C, D)`. (Note that the
		///     dimension unpacked along is gone, unlike `split`).
		///   
		///   If `axis == 1` then the i'th tensor in `output` is the slice `value[:, i, :, :]`
		///     and each tensor in `output` will have shape `(A, C, D)`.
		///   Etc.
		///   
		///   This is the opposite of `pack`.
		/// </remarks>
		public TFOutput[] Unpack (TFOutput value, long num, long? axis = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Unpack", MakeName ("Unpack", operName));
			desc.AddInput (value);
			desc.SetAttr ("num", num);
			if (axis.HasValue)
				desc.SetAttr ("axis", axis.Value);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("output");
			var output = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				output [i] = new TFOutput (op, _idx++);
			
			return output;
		}

		/// <summary>
		///   Computes the Max along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A 1-D tensor whose rank is equal to the rank of `data`'s
		///   first dimension.
		/// </param>
		/// <param name="num_segments">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'UnsortedSegmentMax'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for dimension 0 which
		///   has size `num_segments`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   This operator is similar to the [unsorted segment sum operator](../../../api_docs/python/math_ops.md#UnsortedSegmentSum).
		///   Instead of computing the sum over segments, it computes the maximum
		///   such that:
		///   
		///   \\(output_i = \max_j data_j\\) where max is over `j` such
		///   that `segment_ids[j] == i`.
		///   
		///   If the maximum is empty for a given segment ID `i`, it outputs the smallest possible value for specific numeric type,
		///    `output[i] = numeric_limits&amp;lt;T&amp;gt;::min()`.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/UnsortedSegmentSum.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput UnsortedSegmentMax (TFOutput data, TFOutput segment_ids, TFOutput num_segments, string operName = null)
		{
			var desc = new TFOperationDesc (this, "UnsortedSegmentMax", MakeName ("UnsortedSegmentMax", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			desc.AddInput (num_segments);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Computes the sum along segments of a tensor.
		/// </summary>
		/// <param name="data">
		/// </param>
		/// <param name="segment_ids">
		///   A tensor whose shape is a prefix of `data.shape`.
		/// </param>
		/// <param name="num_segments">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'UnsortedSegmentSum'.
		/// </param>
		/// <returns>
		///   Has same shape as data, except for the first `segment_ids.rank`
		///   dimensions, which are replaced with a single dimension which has size
		///   `num_segments`.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   Read @{$math_ops#segmentation$the section on segmentation} for an explanation of
		///   segments.
		///   
		///   Computes a tensor such that
		///   `(output[i] = sum_{j...} data[j...]` where the sum is over tuples `j...` such
		///   that `segment_ids[j...] == i`.  Unlike `SegmentSum`, `segment_ids`
		///   need not be sorted and need not cover all values in the full
		///   range of valid values.
		///   
		///   If the sum is empty for a given segment ID `i`, `output[i] = 0`.
		///   
		///   `num_segments` should equal the number of distinct segment IDs.
		///   
		///   &amp;lt;div style="width:70%; margin:auto; margin-bottom:10px; margin-top:20px;"&amp;gt;
		///   &amp;lt;img style="width:100%" src="https://www.tensorflow.org/images/UnsortedSegmentSum.png" alt&amp;gt;
		///   &amp;lt;/div&amp;gt;
		/// </remarks>
		public TFOutput UnsortedSegmentSum (TFOutput data, TFOutput segment_ids, TFOutput num_segments, string operName = null)
		{
			var desc = new TFOperationDesc (this, "UnsortedSegmentSum", MakeName ("UnsortedSegmentSum", operName));
			desc.AddInput (data);
			desc.AddInput (segment_ids);
			desc.AddInput (num_segments);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var output = new TFOutput (op, _idx++);
			return output;
		}

		/// <summary>
		///   Op is similar to a lightweight Dequeue.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Unstage'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		/// </param>
		/// <param name="dtypes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The basic funtionality is similar to dequeue with many fewer
		///   capabilities and options.  This Op is optimized for performance.
		/// </remarks>
		public TFOutput[] Unstage (TFDataType[] dtypes, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Unstage", MakeName ("Unstage", operName));
			desc.SetAttrType ("dtypes", dtypes);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			int _n = 0;
			_n = op.OutputListLength ("values");
			var values = new TFOutput [_n];
			for (int i = 0; i < _n; i++)
				values [i] = new TFOutput (op, _idx++);
			
			return values;
		}

		/// <summary>
		///   Creates a handle to a Variable resource.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'VarHandleOp'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   the container this variable is placed in.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   the name by which this variable is referred to.
		/// </param>
		/// <param name="dtype">
		///   the type of this variable. Must agree with the dtypes
		///   of all ops using this variable.
		/// </param>
		/// <param name="shape">
		///   The (possibly partially specified) shape of this variable.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput VarHandleOp (TFDataType dtype, TFShape shape, string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "VarHandleOp", MakeName ("VarHandleOp", operName));
			desc.SetAttrType ("dtype", dtype);
			desc.SetAttrShape ("shape", shape);
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var resource = new TFOutput (op, _idx++);
			return resource;
		}

		/// <summary>
		///   Checks whether a resource handle-based variable has been initialized.
		/// </summary>
		/// <param name="resource">
		///   the input resource handle.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'VarIsInitializedOp'.
		/// </param>
		/// <returns>
		///   a scalar boolean which is true if the variable has been
		///   initialized.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput VarIsInitializedOp (TFOutput resource, string operName = null)
		{
			var desc = new TFOperationDesc (this, "VarIsInitializedOp", MakeName ("VarIsInitializedOp", operName));
			desc.AddInput (resource);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var is_initialized = new TFOutput (op, _idx++);
			return is_initialized;
		}

		/// <summary>
		///   Returns locations of true values in a boolean tensor.
		/// </summary>
		/// <param name="input">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Where'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   This operation returns the coordinates of true elements in `input`. The
		///   coordinates are returned in a 2-D tensor where the first dimension (rows)
		///   represents the number of true elements, and the second dimension (columns)
		///   represents the coordinates of the true elements. Keep in mind, the shape of
		///   the output tensor can vary depending on how many true values there are in
		///   `input`. Indices are output in row-major order.
		///   
		///   For example:
		///   
		///   ```
		///   # 'input' tensor is [[True, False]
		///   #                    [True, False]]
		///   # 'input' has two true values, so output has two coordinates.
		///   # 'input' has rank of 2, so coordinates have two indices.
		///   where(input) ==&amp;gt; [[0, 0],
		///                     [1, 0]]
		///   
		///   # `input` tensor is [[[True, False]
		///   #                     [True, False]]
		///   #                    [[False, True]
		///   #                     [False, True]]
		///   #                    [[False, False]
		///   #                     [False, True]]]
		///   # 'input' has 5 true values, so output has 5 coordinates.
		///   # 'input' has rank of 3, so coordinates have three indices.
		///   where(input) ==&amp;gt; [[0, 0, 0],
		///                     [0, 1, 0],
		///                     [1, 0, 1],
		///                     [1, 1, 1],
		///                     [2, 1, 1]]
		///   ```
		/// </remarks>
		public TFOutput Where (TFOutput input, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Where", MakeName ("Where", operName));
			desc.AddInput (input);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var index = new TFOutput (op, _idx++);
			return index;
		}

		/// <summary>
		///   A Reader that outputs the entire contents of a file as a value.
		/// </summary>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'WholeFileReaderV2'.
		/// </param>
		/// <param name="container">
		///   Optional argument
		///   If non-empty, this reader is placed in the given container.
		///   Otherwise, a default container is used.
		/// </param>
		/// <param name="shared_name">
		///   Optional argument
		///   If non-empty, this reader is named in the given bucket
		///   with this shared_name. Otherwise, the node name is used instead.
		/// </param>
		/// <returns>
		///   The handle to reference the Reader.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   To use, enqueue filenames in a Queue.  The output of ReaderRead will
		///   be a filename (key) and the contents of that file (value).
		/// </remarks>
		public TFOutput WholeFileReaderV2 (string container = null, string shared_name = null, string operName = null)
		{
			var desc = new TFOperationDesc (this, "WholeFileReaderV2", MakeName ("WholeFileReaderV2", operName));
			if (container != null)
				desc.SetAttr ("container", container);
			
			if (shared_name != null)
				desc.SetAttr ("shared_name", shared_name);
			
			var op = desc.FinishOperation ();
			int _idx = 0;
			var reader_handle = new TFOutput (op, _idx++);
			return reader_handle;
		}

		/// <summary>
		///   Writes contents to the file at input filename. Creates file if not existing.
		/// </summary>
		/// <param name="filename">
		///   scalar. The name of the file to which we write the contents.
		/// </param>
		/// <param name="contents">
		///   scalar. The content to be written to the output file.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'WriteFile'.
		/// </param>
		/// <returns>
		///   Returns the description of the operation
		/// </returns>
		public TFOperation WriteFile (TFOutput filename, TFOutput contents, string operName = null)
		{
			var desc = new TFOperationDesc (this, "WriteFile", MakeName ("WriteFile", operName));
			desc.AddInput (filename);
			desc.AddInput (contents);
			var op = desc.FinishOperation ();
			return op;
		}

		/// <summary>
		///   Returns a tensor of zeros with the same shape and type as x.
		/// </summary>
		/// <param name="x">
		///   a tensor of type T.
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ZerosLike'.
		/// </param>
		/// <returns>
		///   a tensor of the same shape and type as x but filled with zeros.
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ZerosLike (TFOutput x, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ZerosLike", MakeName ("ZerosLike", operName));
			desc.AddInput (x);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var y = new TFOutput (op, _idx++);
			return y;
		}

		/// <summary>
		///   Compute the Hurwitz zeta function \\(\zeta(x, q)\\).
		/// </summary>
		/// <param name="x">
		/// </param>
		/// <param name="q">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'Zeta'.
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		/// <remarks>
		///   The Hurwitz zeta function is defined as:
		///   
		///   
		///   \\(\zeta(x, q) = \sum_{n=0}^{\infty} (q + n)^{-x}\\)
		/// </remarks>
		public TFOutput Zeta (TFOutput x, TFOutput q, string operName = null)
		{
			var desc = new TFOperationDesc (this, "Zeta", MakeName ("Zeta", operName));
			desc.AddInput (x);
			desc.AddInput (q);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var z = new TFOutput (op, _idx++);
			return z;
		}

		/// <summary>
		///   Creates a dataset that zips together `input_datasets`.
		/// </summary>
		/// <param name="input_datasets">
		/// </param>
		/// <param name="operName">
		///   If specified, the created operation in the graph will be this one, otherwise it will be named 'ZipDataset'.
		/// </param>
		/// <param name="output_types">
		/// </param>
		/// <param name="output_shapes">
		/// </param>
		/// <returns>
		///   The TFOperation can be fetched from the resulting TFOutput, by fethching the Operation property from the result.
		/// </returns>
		public TFOutput ZipDataset (TFOutput[] input_datasets, TFDataType[] output_types, TFShape[] output_shapes, string operName = null)
		{
			var desc = new TFOperationDesc (this, "ZipDataset", MakeName ("ZipDataset", operName));
			desc.AddInputs (input_datasets);
			desc.SetAttrType ("output_types", output_types);
			desc.SetAttrShape ("output_shapes", output_shapes);
			var op = desc.FinishOperation ();
			int _idx = 0;
			var handle = new TFOutput (op, _idx++);
			return handle;
		}

	}
}
